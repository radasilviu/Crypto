using OldCrypto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OldCrypto
{
    class Rot13:BaseImpl,Result
    {

        public override char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }

        public override string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        public override string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }


        public void Result()
        {
            Console.WriteLine("ROOT 13");

            Console.WriteLine("Type a string to encrypt:");
            string UserString = Console.ReadLine();

            Console.WriteLine("\n");

            Console.Write("Key = 13 ");
            int key = 13;
            Console.WriteLine("\n");


            Console.WriteLine("Encrypted Data");


            string cipherText = Encipher(UserString, key);
            Console.WriteLine(cipherText);
            Console.Write("\n");

            Console.WriteLine("Decrypted Data:");

            string t = Decipher(cipherText, key);
            Console.WriteLine(t);
            Console.Write("\n");
        }
    }
}
