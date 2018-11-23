using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace NewCrypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Scrie.Text = null;
            Citeste.Text = null;

            try
            {

                StreamReader sr = new StreamReader(@"../../TextFile1.txt");

                string rl;
                while ((rl = sr.ReadLine()) != null)
                {
                    String line = rl;
                    Citeste.Text += line + "\n";
                }
            }
            catch (Exception exc)
            {
                Citeste.Text = ("The file could not be read");
                Citeste.Text = (exc.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Scrie.Text = null;
            byte[] KEY = new byte[KeyToInsert.Text.Length];
            byte[] IV = new byte[KeyToInsert.Text.Length];

            string initialText = Citeste.Text;
            try
            {

              
                using (Aes myAes = Aes.Create())
                {
                    myAes.Mode = chooseMode;
                    myAes.Padding = choosePadding;
                    if (this.KeyToInsert.Text != "")
                    {
                        KEY = Encoding.ASCII.GetBytes(chooseKey);
                    }
                    else
                    {
                        KEY = myAes.Key;
                    }

                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = myAesImpl.EncryptStringToBytes_Aes(initialText, KEY, IV,chooseMode,choosePadding);

                    // Decrypt the bytes to a string.
                    string roundtrip = myAesImpl.DecryptStringFromBytes_Aes(encrypted, KEY, IV, chooseMode, choosePadding);

                    //Display the  data and the ecnrypted data.

                    Scrie.Text += "Encrypted text : ";
                    string str = Encoding.UTF8.GetString(encrypted, 0, encrypted.Length);
                    Scrie.Text += str;

                    /*for (int i = 0; i < encrypted.Length; i++)
                    {
                        Scrie.Text += encrypted[i].ToString();
                    }*/
                    Scrie.Text += "\n";
                    //Display the decrypted data.

                    Scrie.Text += ("Decrypted:  " + roundtrip);
                }
            }
            catch (Exception exc)
            {
                Scrie.Text = ("The file could not be read");
                Scrie.Text = (exc.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Scrie.Text = null;
            byte[] KEY = new byte[KeyToInsert.Text.Length];
            byte[] IV = new byte[KeyToInsert.Text.Length];

            try
            {

                string initialText = Citeste.Text;

                
                using (Rijndael myRijndael = Rijndael.Create())
                {

                    myRijndael.Mode = chooseMode;
                    myRijndael.Padding = choosePadding;

                
                     KEY = Encoding.ASCII.GetBytes(chooseKey);
                  
                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = NewCrypto.myRijndael.EncryptStringToBytes(initialText, KEY, IV, chooseMode, choosePadding);

                    // Decrypt the bytes to a string.
                    string roundtrip = NewCrypto.myRijndael.DecryptStringFromBytes(encrypted, KEY, IV, chooseMode, choosePadding);

                    //Display the  data and the ecnrypted data.

                    Scrie.Text += "Encrypted text : ";

                    string str = Encoding.UTF8.GetString(encrypted, 0, encrypted.Length);
                    Scrie.Text += str;

                    /*for (int i = 0; i < encrypted.Length; i++)
                    {
                        Scrie.Text += encrypted[i].ToString();
                    }*/
                    Scrie.Text += "\n";
                    //Display  the decrypted data.

                    Scrie.Text += ("Decrypted:  " + roundtrip);


                }
            }
            catch (Exception exc)
            {
                Scrie.Text = ("The file could not be read");
                Scrie.Text = (exc.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Scrie.Text = null;
            byte[] KEY = new byte[KeyToInsert.Text.Length];
            byte[] IV = new byte[KeyToInsert.Text.Length];

            try
            {

                string initialText = Citeste.Text;

                // Create a new instance of the DES
                using (DES myDes = DES.Create())
                {

                    myDes.Mode = chooseMode;
                    myDes.Padding = choosePadding;


                    KEY = Encoding.ASCII.GetBytes(chooseKey);




                    // Encrypt the string to an array of bytes.
                    byte[] Data = myDESImpl.EncryptStringToBytes_Des(initialText, KEY, IV,chooseMode, choosePadding);

                    // Decrypt the bytes to a string.
                    string Final = myDESImpl.DecryptStringFromBytes_Des(Data, KEY, IV, chooseMode, choosePadding);

                    //Display the  data and the ecnrypted data.

                    Scrie.Text += "Encrypted text : ";
                    string str = Encoding.UTF8.GetString(Data, 0, Data.Length);

                    // for (int i = 0; i < encrypted.Length; i++)
                    //  {
                    // Scrie.Text += encrypted[i].ToString();
                    // }

                    Scrie.Text += str;
                    Scrie.Text += "\n";
                    //Display the decrypted data.

                    Scrie.Text += ("Decrypted:  " + Final);


                }
            }
            catch (Exception exc)
            {
                Scrie.Text = ("The file could not be read");
                Scrie.Text = (exc.Message);
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Scrie.Text = null;
            byte[] KEY = new byte[KeyToInsert.Text.Length];
            byte[] IV = new byte[KeyToInsert.Text.Length];
            try
            {

                // Create a string to encrypt.
                string initialText = Citeste.Text;

               
                using (RC2 RC2alg = RC2.Create("RC2"))
                {

               
                    RC2alg.Mode = chooseMode;
                    RC2alg.Padding = choosePadding;

                 
                    KEY = Encoding.ASCII.GetBytes(chooseKey);
                 
                            


                     // Encrypt the string to an in-memory buffer.
                     byte[] Data = myRc2Impl.EncryptTextToMemory(initialText, KEY, IV, chooseMode, choosePadding);


                    // Decrypt the buffer back to a string.
                    string Final = myRc2Impl.DecryptTextFromMemory(Data, KEY, IV, chooseMode, choosePadding);


                    //Display the  data and the ecnrypted data.

                    Scrie.Text += "Encrypted text : ";
                    string str = Encoding.UTF8.GetString(Data, 0, Data.Length);

                    // for (int i = 0; i < encrypted.Length; i++)
                    //  {
                    // Scrie.Text += encrypted[i].ToString();
                    // }

                    Scrie.Text += str;
                    Scrie.Text += "\n";
                    //Display the decrypted data.

                    Scrie.Text += ("Decrypted:  " + Final);
                }

            }
            catch (Exception exc)
            {
                Scrie.Text = ("The file could not be read");
                Scrie.Text = (exc.Message);
            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Scrie.Text = null;
            byte[] KEY = new byte[KeyToInsert.Text.Length];
            byte[] IV = new byte[KeyToInsert.Text.Length];

            try
            {
               
                TripleDES TripleDESalg = TripleDES.Create("TripleDES");
             
                TripleDESalg.Mode = chooseMode;
                TripleDESalg.Padding = choosePadding;

                KEY = Encoding.ASCII.GetBytes(chooseKey);
             

                // Create a string to encrypt.
                string initialText = Citeste.Text;

                // Encrypt the string to an in-memory buffer.
                byte[] Data =CryptoClasses.myTripleDES.EncryptTextToMemory(initialText, KEY, IV, chooseMode, choosePadding);

                // Decrypt the buffer back to a string.
                string Final = CryptoClasses.myTripleDES.DecryptTextFromMemory(Data, KEY, IV, chooseMode, choosePadding);

                //Display the  data and the ecnrypted data.

                Scrie.Text += "Encrypted text : ";
                string str = Encoding.UTF8.GetString(Data, 0, Data.Length);

                // for (int i = 0; i < encrypted.Length; i++)
                //  {
                // Scrie.Text += encrypted[i].ToString();
                // }

                Scrie.Text += str;
                Scrie.Text += "\n";
                //Display the decrypted data.

                Scrie.Text += ("Decrypted:  " + Final);
            }
            catch (Exception exc)
            {
                Scrie.Text = ("The file could not be read");
                Scrie.Text = (exc.Message);
            }
        }
        private CipherMode chooseMode;
        private string chooseMode1;

        private void ComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            chooseMode1 = (string)((ComboBoxItem)((ComboBox)sender).SelectedValue).Content;
            switch(chooseMode1)
            {
                case "CBC":
                    {
                        chooseMode = CipherMode.CBC;
                        break;
                    }
                case "CFB":
                    {
                        chooseMode = CipherMode.CFB;
                        break;
                    }
                case "ECB":
                    {
                        chooseMode = CipherMode.ECB;
                        break;
                    }
                case "OFB":
                    {
                        chooseMode = CipherMode.OFB;
                        break;
                    }
            }
        }
     

        private PaddingMode choosePadding;
        private string choosePadding1;

        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {

            choosePadding1 = (string)((ComboBoxItem)((ComboBox)sender).SelectedValue).Content;
            switch (choosePadding1)
            {
                case "ANSIX923":
                    {
                        choosePadding = PaddingMode.ANSIX923;
                        break;
                    }
                case "ISO10126":
                    {
                        choosePadding = PaddingMode.ISO10126;
                        break;
                    }
                case "None":
                    {
                        choosePadding = PaddingMode.None;
                        break;
                    }
                case "PKCS7":
                    {
                        choosePadding = PaddingMode.PKCS7;
                        break;
                    }
                case "Zeros":
                    {
                        choosePadding = PaddingMode.Zeros;
                        break;
                    }
            }

        }
       // private char chooseKey1;
        private string chooseKey;

        private void KeyToInsert_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (KeyToInsert.Text is string)
            {
                chooseKey = KeyToInsert.Text;
            }

            /*if(Uri.IsHexDigit(chooseKey1) ==true )
            {
                string keyToInsertConvert = KeyToInsert.Text;
                for (int i = 0; i < keyToInsertConvert.Length; i++)
                    chooseKey1 = keyToInsertConvert[i];
            }*/



        }
        
    }
}
