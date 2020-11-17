using System;

namespace DiffieHellman
{
    class Program
    {
        static void Main(string[] args)
        {
            RunDiffieHellmanEncrypt();
        }
        public static string RunDiffieHellmanEncrypt()
        {
            long primeNumber = 60000049;
            Console.WriteLine("Prime number : " + primeNumber);
            Console.WriteLine("Base number.");
            Console.Write(">");
            var baseNumberText = Console.ReadLine()?.Trim() ?? "";

            long baseNumber = 0;
            if (!long.TryParse(baseNumberText, out baseNumber))
            {
                Console.WriteLine("Error " + baseNumberText + " isn't a number!!");
            }

            Console.WriteLine("Secret Number A.");
            Console.Write(">");
            var secretAText = Console.ReadLine()?.Trim() ?? "";

            long secretA = 0;

            if (!long.TryParse(secretAText, out secretA))
            {
                Console.WriteLine("Error" + secretAText + " isn't a number!!");
            }

            Console.WriteLine("Secret Number B.");
            Console.Write(">");
            var secretBText = Console.ReadLine()?.Trim() ?? "";

            long secretB = 0;
            if (!long.TryParse(secretBText, out secretB))
            {
                Console.WriteLine("Error" + secretBText + " isn't a number!!");
            }

            long entityADiffie = DiffieHellmanEncrypt(baseNumber, secretA, primeNumber);

            long temp = entityADiffie;

            long entityBDiffie = DiffieHellmanEncrypt(baseNumber, secretB, primeNumber);

            entityADiffie = entityBDiffie;
            entityBDiffie = temp;
            entityADiffie = DiffieHellmanEncrypt(entityADiffie, secretA, primeNumber);
            entityBDiffie = DiffieHellmanEncrypt(entityBDiffie, secretB, primeNumber);

            if (entityADiffie == entityBDiffie)
            {
                Console.WriteLine("Shared Secret:  {0} ", entityADiffie);
            }
            else
            {
                Console.WriteLine("Something's Wrong: Please check if prime number really is a prime number!'");
            }

            return "";
        }
        public static long DiffieHellmanEncrypt(long generator, long secret, long prime)
        {
            if (secret == 0)
            {
                return 1;
            }
            else if (secret % 2 == 0) // if even
            {
                long recurs = DiffieHellmanEncrypt(generator, secret / 2, prime);
                return (recurs * recurs) % prime;
            }
            else
            {
                return ((generator % prime) * DiffieHellmanEncrypt(generator, secret - 1, prime)) % prime;
            }
        }
    }
}