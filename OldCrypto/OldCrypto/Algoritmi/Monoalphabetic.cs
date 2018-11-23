using OldCrypto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OldCrypto.Algoritmi
{
    class Monoalphabetic:BaseImplTwo,Result
    {
         public override string Encrypt(string plainText, string key)
        {
            char[] chars = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] == ' ')
                {
                    chars[i] = ' ';
                }

                else
                {
                    int j = plainText[i] - 97;
                    chars[i] = key[j];
                }
            }

            return new string(chars);
        }


        public string reverse(string cipherText)
        {
            char[] charArray = cipherText.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }


        public override string Decrypt(string cipherText, string key)
        {
            char[] chars = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] == ' ')
                {
                    chars[i] = ' ';
                }
                else
                {
                    int j = key.IndexOf(cipherText[i]) + 97;
                    chars[i] = (char)j;
                }
            }
            return new string(chars);
        }

        public void Result()
        {
           

            Console.WriteLine("MONOALPHABETIC ALGORITHM");

            string key = "zyxwvutsrqponmlkjihgfedcbaABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Console.WriteLine("Enter your String:");
            Console.Write("\n");
            string plainText = Console.ReadLine();
            Console.Write("\n");

            string cipherText = Encrypt(plainText, key);
            Console.WriteLine("Your Encrypted Data:\t" + cipherText);

            Console.Write("\n");

            string decryptedText = Decrypt(cipherText, key);
            Console.WriteLine("Your Decrypted Data:\t" + decryptedText);
            Console.ReadKey();
        }
    }
}
