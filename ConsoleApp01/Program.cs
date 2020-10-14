using System;
using System.Text;

namespace ConsoleApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nics0031-2020f Secure Programming Cem Hasgören\n");
            var userInput = "";
            
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1) Cesar Cypher");
                Console.WriteLine("2) Vinegere Cypher");
                Console.WriteLine("X) Exit");
                Console.WriteLine("---- ---- ----");

                userInput = Console.ReadLine()?.ToLower();
            
                //validation part
                switch (userInput)
                {
                    case "1":
                        Cesar();
                        break;
                    case "2":
                        Vigenere();
                        break;
                    case "x":
                        Console.WriteLine("Closing now...");
                        break;
                    default:
                        Console.WriteLine($"Don't have this '{userInput}' as an option!");
                        break;
                }
            } while (userInput != "x");
        }

        
        static void Cesar()
        {
            Console.WriteLine("Cesar Cypher");
            
            /*
            byte per character
            0-255
            0-127 | latin
            128-255 | change what you want
            ABCD | A 189, B 195, C 196, D 202 
            unicode
            ÜĞİÜĞÇÖ
            */
            
            var userInput = "";
            var key = 0;
            do
            {
                Console.Write("Please enter your shift amount (X to exit): ");
                userInput = Console.ReadLine()?.ToLower().Trim();
                
                if (userInput != "x")
                {
                    if (int.TryParse(userInput, out var userValue))
                    {
                        key = userValue % 255;
                        if (key == 0)
                        {
                            Console.WriteLine("0(zero) or multiples of 255 is no cypher");
                        }
                        else
                        {
                            Console.WriteLine($"Cesar key is: {key}");
                        }
                    }
                }
            } while (userInput != "x" && key == 0);
            if(userInput == "x") return; 
            
            Console.Write("Please enter your plain text:");
            var plainText = Console.ReadLine();
            if (plainText != null)
            {
                Console.WriteLine($"Length of the text is {plainText.Length}\n");
                
                /*
                ShowEncoding(plainText,Encoding.UTF7);
                ShowEncoding(plainText,Encoding.UTF8);
                ShowEncoding(plainText,Encoding.UTF32);
                ShowEncoding(plainText,Encoding.ASCII);
                ShowEncoding(plainText,Encoding.Unicode);
                ShowEncoding(plainText,Encoding.Default); //most likely UTF-8
                */
                
                Console.WriteLine("Your cipher text is: dgdfyhghfhjf");
            }
            else
            {
                Console.WriteLine("Plain text is null!");    
            }
        }

        static void Vigenere()
        {
            
        }

        static void ShowEncoding(string text, Encoding encoding)
        {
            Console.WriteLine(encoding.EncodingName);
            
            Console.Write("Preamble");
            foreach (var preambleByte in encoding.Preamble)
            {
                Console.Write(preambleByte + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"{text[i]} ");
                foreach (var byteValue in encoding.GetBytes(text.Substring(i,1)))
                {
                    Console.Write(byteValue + " ");
                }    
            }
            
            Console.WriteLine();
        }
    }
    
}