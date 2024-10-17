using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3RouteCipher
{
    public class RouteCipher
    {
        #region Constructor and Property
        private int key;

        public RouteCipher(int key)
        {
            Key = key;
        }
        public int Key
        {
            get { return key; }
            set { key = value == 0 ? 1 : value; }
        }
        #endregion

        #region Functions
        #region Helper functions for encryption and decryption
        /// <summary>
        /// function to put "ciphertextChars" into bottom left of table "a" for decryptio
        /// </summary>
        /// <param name="a"></param>
        /// <param name="coords"></param>
        /// <param name="ciphertextChars"></param>
        /// <param name="charCounter"></param>
        private void BottomLeftDecrypt(char[,] a, (int x1, int y1, int x2, int y2) coords, char[] ciphertextChars, int charCounter)
        {
            int i = 0, j = 0;

            // print values in the column.
            for (i = coords.y1; i <= coords.y2; i++)
            {
                a[i, coords.x1] = ciphertextChars[charCounter++];
            }

            // print values in the row.
            for (j = coords.x1 + 1; j <= coords.x2; j++)
            {
                a[coords.y2, j] = ciphertextChars[charCounter++];
            }

            // see if more layers need to be printed.
            if (coords.x2 - coords.x1 > 0 && coords.y2 - coords.y1 > 0)
            {
                // if yes recursively call the function to 
                // print the bottom left of the sub matrix.
                UpperRightDecrypt(a, (coords.x1 + 1, coords.y1, coords.x2, coords.y2 - 1), ciphertextChars, charCounter);
            }
        }
        /// <summary>
        /// function to put "ciphertextChars" into upper right reverse of table "a" for decryptio
        /// </summary>
        /// <param name="a"></param>
        /// <param name="coords"></param>
        /// <param name="ciphertextChars"></param>
        /// <param name="charCounter"></param>
        void UpperRightDecrypt(char[,] a, (int x1, int y1, int x2, int y2) coords, char[] ciphertextChars, int charCounter)
        {
            int i = 0, j = 0;

            // print the values in the col in reverse order.
            for (i = coords.y2; i >= coords.y1; i--)
            {
                a[i, coords.x2] = ciphertextChars[charCounter++];
            }

            // print the values in the row in reverse order.
            for (j = coords.x2 - 1; j >= coords.x1; j--)
            {
                a[coords.y1, j] = ciphertextChars[charCounter++];
            }

            // see if more layers need to be printed.
            if (coords.x2 - coords.x1 > 0 && coords.y2 - coords.y1 > 0)
            {
                // if yes recursively call the function to 
                // print the top right of the sub matrix.
                BottomLeftDecrypt(a, (coords.x1, coords.y1 + 1, coords.x2 - 1, coords.y2), ciphertextChars, charCounter);
            }
        }
        /// <summary>
        /// function to take from bottom left of table "a" and put into "ciphertextChars" for encryptio
        /// </summary>
        /// <param name="a"></param>
        /// <param name="coords"></param>
        /// <param name="ciphertextChars"></param>
        /// <param name="charCounter"></param>
        private void BottomLeft(char[,] a, (int x1, int y1, int x2, int y2) coords, char[] ciphertextChars, int charCounter)
        {
            int i = 0, j = 0;

            // print values in the column.
            for (i = coords.y1; i <= coords.y2; i++)
            {
                ciphertextChars[charCounter++] = a[i, coords.x1];
            }

            // print values in the row.
            for (j = coords.x1 + 1; j <= coords.x2; j++)
            {
                ciphertextChars[charCounter++] = a[coords.y2, j];
            }

            // see if more layers need to be printed.
            if (coords.x2 - coords.x1 > 0 && coords.y2 - coords.y1 > 0)
            {
                // if yes recursively call the function to 
                // print the bottom left of the sub matrix.
                UpperRight(a, (coords.x1 + 1, coords.y1, coords.x2, coords.y2 - 1), ciphertextChars, charCounter);
            }
        }

        /// <summary>
        /// function to take from upper right reverce of table  "a" and put into "ciphertextChars" for encryptio
        /// </summary>
        /// <param name="a"></param>
        /// <param name="coords"></param>
        /// <param name="ciphertextChars"></param>
        /// <param name="charCounter"></param>
        void UpperRight(char[,] a, (int x1, int y1, int x2, int y2) coords, char[] ciphertextChars, int charCounter)
        {
            int i = 0, j = 0;

            // print the values in the col in reverse order.
            for (i = coords.y2; i >= coords.y1; i--)
            {
                ciphertextChars[charCounter++] = a[i, coords.x2];
            }

            // print the values in the row in reverse order.
            for (j = coords.x2 - 1; j >= coords.x1; j--)
            {
                ciphertextChars[charCounter++] = a[coords.y1, j];
            }

            // see if more layers need to be printed.
            if (coords.x2 - coords.x1 > 0 && coords.y2 - coords.y1 > 0)
            {
                // if yes recursively call the function to 
                // print the top right of the sub matrix.
                BottomLeft(a, (coords.x1, coords.y1 + 1, coords.x2 - 1, coords.y2), ciphertextChars, charCounter);
            }
        }

        #endregion
        public string Encrypt(string plaintext)
        {
            //declarations
            char[] plaintextChars;
            char[] ciphertextChars;
            char[,] chipherTable;
            int rows;
            int cols;
            int charCounter;

            //init
            plaintextChars = plaintext.ToCharArray();
            cols = Math.Abs(key);
            rows = (int)Math.Ceiling((decimal)plaintextChars.Length / cols);
            chipherTable = new char[rows, cols];
            ciphertextChars = new char[rows * cols];
            charCounter = 0;

            //process encryption
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i * cols + j < plaintextChars.Length)
                        chipherTable[i, j] = plaintextChars[i * cols + j];
                    else
                        chipherTable[i, j] = 'X';
                }
            }

            if (key > 0)
                BottomLeft(chipherTable, (0, 0, cols - 1, rows - 1), ciphertextChars, charCounter);
            else if (key < 0)
                UpperRight(chipherTable, (0, 0, cols - 1, rows - 1), ciphertextChars, charCounter);

            return new string(ciphertextChars);

        }
        public string Decrypt(string ciphertext)
        {
            //declarations
            char[] plaintextChars;
            char[] ciphertextChars;
            char[,] chipherTable;
            int rows;
            int cols;
            int charCounter;

            //init
            ciphertextChars = ciphertext.ToCharArray();
            cols = Math.Abs(key);
            rows = ciphertextChars.Length / cols;
            chipherTable = new char[rows, cols];
            plaintextChars = new char[rows * cols];
            charCounter = 0;

            //process decryptiop           
            if (key > 0)
                BottomLeftDecrypt(chipherTable, (0, 0, cols - 1, rows - 1), ciphertextChars, charCounter);
            else if (key < 0)
                UpperRightDecrypt(chipherTable, (0, 0, cols - 1, rows - 1), ciphertextChars, charCounter);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    plaintextChars[i * cols + j] = chipherTable[i, j];
                }
            }

            for (int i = plaintextChars.Length - 1; i >= 0; i--)
            {
                if (plaintextChars[i] == 'X')
                    plaintextChars[i] = '\0';
                else
                    break;
            }
            return new string(plaintextChars);

        }
        public override string ToString()
        {
            return $"current key: +{key}";
        }

        #endregion


    }
}
