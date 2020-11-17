using System;
using System.Text;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vigenere Cipher");

            Console.WriteLine("Input plaintext to encrypt:");
            var plaintext = Console.ReadLine();

            Console.WriteLine("Input the key:");
            var key = Console.ReadLine();

            var ciphertext = EncryptString(plaintext, key, Encoding.Default);
            Console.WriteLine(ciphertext);

            var decrypted = DecryptString(ciphertext, key, Encoding.Default);
            Console.WriteLine(decrypted);
        }

        static byte[] Encrypt(byte[] plaintext, byte[] key)
        {
            var cipherText = new byte[plaintext.Length];
            var shiftKey = ShiftKey(key, plaintext.Length);

            for (int i = 0; i < plaintext.Length; i++)
            {
                var newCharValue = (plaintext[i] + shiftKey[i]) % byte.MaxValue;
                if (newCharValue == 0)
                {
                    newCharValue = byte.MaxValue;
                }

                cipherText[i] = (byte) newCharValue;
            }

            return cipherText;
        }

        static string EncryptString(string plaintext, string key, Encoding encoding)
        {
            var plaintextBytes = encoding.GetBytes(plaintext);
            var keyBytes = encoding.GetBytes(key);
            var ciphertextBytes = Encrypt(plaintextBytes, keyBytes);
            var ciphertext = Convert.ToBase64String(ciphertextBytes);
            return ciphertext;
        }

        static byte[] Decrypt(byte[] ciphertext, byte[] key)
        {
            var plaintext = new byte[ciphertext.Length];
            var shiftKey = ShiftKey(key, ciphertext.Length);
            for (int i = 0; i < ciphertext.Length; i++)
            {
                var newCharValue = (ciphertext[i] - shiftKey[i]) % byte.MaxValue;
                if (newCharValue == 0)
                {
                    newCharValue = byte.MaxValue;
                }

                plaintext[i] = (byte) newCharValue;
            }

            return plaintext;
        }
        
        static string DecryptString(string ciphertext, string key, Encoding encoding)
        {
            var ciphertextBytes = Convert.FromBase64String(ciphertext);
            var keyBytes = encoding.GetBytes(key);
            var plaintextBytes = Decrypt(ciphertextBytes, keyBytes);
            var plaintext = encoding.GetString(plaintextBytes);
            return plaintext;
        }
        
        static byte[] ShiftKey(byte[] key, int len)
        {
            var newKey = new byte[len];
            for (int i = 0; i < len; i++)
            {
                newKey[i] = key[i % key.Length];
            }
            return newKey;
        }
    }
}