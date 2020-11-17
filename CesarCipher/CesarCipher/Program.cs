using System;
using System.Text;

namespace CesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caesar Cipher");
            
            Console.WriteLine("Input the string you want to encrypt:");
            var plaintext = Console.ReadLine();
            
            Console.WriteLine("Input the shift amount:");
            
            if (Int32.TryParse(Console.ReadLine(), out var shiftAmount))
            {
                shiftAmount = shiftAmount % 255;
                if (shiftAmount == 0)
                {
                    Console.WriteLine("Shift amount cannot be multiples of 255 or 0");
                }
                else
                {
                    Console.WriteLine($"Caesar key is {shiftAmount}");
                }
            }
            else
            {
                Console.WriteLine("Input must be an integer!");
                return;
            }

            var ciphertext = EncryptString(plaintext, shiftAmount, Encoding.Default);
            Console.WriteLine("ciphertext: "+ciphertext);

            var decrypted = DecryptString(ciphertext, shiftAmount, Encoding.Default);
            Console.WriteLine("decrypted plaintext: "+ decrypted);
        }
        static byte[] Encrypt(byte[] plaintext, byte shiftAmount)
        {
            var ciphertext = new byte[plaintext.Length];
            for (int i = 0; i < plaintext.Length; i++)
            {
                var newCharValue = (plaintext[i] + shiftAmount) % byte.MaxValue;
                if (newCharValue == 0)
                {
                    newCharValue = byte.MaxValue;
                }
                ciphertext[i] = (byte)newCharValue;
            }
            return ciphertext;
        }
        static string EncryptString(string plaintext, int shiftAmount, Encoding encoding)
        {
            var plaintextBytes = encoding.GetBytes(plaintext);
            byte key = (byte) shiftAmount;
            var ciphertextBytes = Encrypt(plaintextBytes, key);
            string ciphertext = Convert.ToBase64String(ciphertextBytes);
            return ciphertext;
        }
        static byte[] Decrypt(byte[] ciphertext, byte shiftAmount)
        {
            var plaintext = new byte[ciphertext.Length];
            for (int i = 0; i < ciphertext.Length; i++)
            {
                var newCharValue = (ciphertext[i] - shiftAmount) % byte.MaxValue;
                if (newCharValue == 0)
                {
                    newCharValue = byte.MaxValue;
                }
                plaintext[i] = (byte) newCharValue;
            }
            return plaintext;
        }
        static string DecryptString(string ciphertext, int shiftAmount, Encoding encoding)
        {
            var ciphertextBytes = Convert.FromBase64String(ciphertext);
            byte key = (byte) shiftAmount;
            var plaintextBytes = Decrypt(ciphertextBytes, key);
            var plaintext = encoding.GetString(plaintextBytes);
            return plaintext;
        }
    }
}