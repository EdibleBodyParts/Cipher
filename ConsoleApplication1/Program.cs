using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            string plainInput = null;
            string plainUpper = null;
            string cipherWord = null;
            string encryptUpper = null;
            string encryptIn = null;
            string choice = null;
            int check = 0;
            int badCount = 0; //count of non alphabet characters in strings so they can be skipped without moving the cipher

            while (!(int.TryParse(choice, out check) && check >= 1 && check <= 3)) //sees if choice is could be an int, if so, makes check that int
            {
                //find an easy IF for Console.Write("Invalid Input. Try Again\n");
                Console.Write("[1] Encrypt text\n[2] Decrypt text\n[3] Find cipher\n");
                choice = Console.ReadLine();
            }

            if (choice != "2")
            {
                Console.Write("Enter the unencrypted phrase:\n");
                plainInput = Console.ReadLine();
                plainUpper = plainInput.ToUpper();
            }

            if (choice != "1")
            {
                Console.Write("Enter the encrypted phrase:\n");
                encryptIn = Console.ReadLine();
                encryptUpper = encryptIn.ToUpper();
            }

            if (choice != "3")
            {
                Console.Write("Enter the cipher word:\n");
                cipherWord = Console.ReadLine();
                cipherWord = cipherWord.ToUpper();
            }

            if (choice == "1")
            {
                for (int i = 0; i < plainUpper.Length; i++)
                {
                    if (char.IsLetter(plainUpper[i]))
                    {
                        char c = plainUpper[i];
                        int letterValue1 = c - 65;
                        char c2 = cipherWord[(i - badCount) % cipherWord.Length];
                        int letterValue2 = c2 - 65;
                        int asciiValue = (letterValue1 + letterValue2) % 26 + 65;
                        encryptUpper += (char)asciiValue;
                    }
                    else
                    {
                        encryptUpper += plainUpper[i];
                        badCount++;
                    }
                }

                Console.Write("\nEncrypted message:\n");
                Console.Write(encryptUpper + "\n");
            }

            if (choice == "2")
            {
                for (int i = 0; i < encryptUpper.Length; i++)
                {
                    if (char.IsLetter(encryptUpper[i]))
                    {
                        char c = encryptUpper[i];
                        int letterValue1 = c - 65;
                        char c2 = cipherWord[(i - badCount) % cipherWord.Length];
                        int letterValue2 = c2 - 65;
                        int asciiValue = (26 + letterValue1 - letterValue2) % 26 + 65; //add 26 to avoid negatives
                        plainUpper += (char)asciiValue;
                    }
                    else
                    {
                        plainUpper += encryptUpper[i];
                        badCount++;
                    }
                }

                Console.Write("\nDecrypted message:\n");
                Console.Write(plainUpper + "\n");
            }

            if (choice == "3")
            {
                for (int i = 0; i < encryptUpper.Length; i++) //no check for bad characters because lazy
                {
                    cipherWord += (char)( (26 + encryptUpper[i] - plainUpper[i]) % 26 + 65); //add 26 to avoid negatives
                }

                Console.Write("\nCipher:\n");
                Console.Write(cipherWord + "\n");
            }

            Console.ReadKey();
        }
    }
}
