using System;
using System.Collections.Generic;
using System.Text;

namespace OldCrypto
{
    abstract class BaseImpl
    {

        public abstract char cipher(char ch, int key);

        public abstract string Encipher( string input, int key);

        public abstract string Decipher(string input, int key);


    }

}
