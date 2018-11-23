using OldCrypto.Algoritmi;
using System;

namespace OldCrypto
{
    class Program
    {
      
        static void Main(string[] args)
        {
            
            Plus3Crypto pl3 = new Plus3Crypto();
            pl3.Result();
            Console.WriteLine();

            PlusNCrypto pln = new PlusNCrypto();
            pln.Result();

            Console.WriteLine();

            Rot13 r13 = new Rot13();
            r13.Result();

            Console.WriteLine();

            PlayFair playF = new PlayFair();
            playF.Result();

            Console.WriteLine();

            Monoalphabetic monoAplha = new Monoalphabetic();
            monoAplha.Result();

            Console.ReadKey();

        }
    }
}
