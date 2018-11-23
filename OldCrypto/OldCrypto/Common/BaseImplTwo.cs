using System;
using System.Collections.Generic;
using System.Text;

namespace OldCrypto.Common
{
    abstract class BaseImplTwo 
    {

        public abstract string Encrypt(string input, string key);
        public abstract string Decrypt(string input, string key);

    }
}
