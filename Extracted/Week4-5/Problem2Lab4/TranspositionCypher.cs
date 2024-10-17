using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab4
{
    public class TranspositionCypher
    {
        /// <summary>
        /// Implements tghe Transposition cypher
        /// Problem 2 in Lab4
        /// </summary>
        #region Properties and Constructor
        private int cypherKey;

        public int CypherKey
        {
            get { return cypherKey; }
            set { cypherKey = value > 0 ? value : 3; }
        }

        public TranspositionCypher(string word)
        {
            cypherKey = word.Length;
        }
        #endregion

        public string Encrypt(string plaintext)
        {
            // declaration
            char[] plaintextChars;
            char[] cyphertextChars;
            char[,] cypherTemplate;
            int rows;  // template rows
            int cols;  // template cols
            int charCounter; // index current char  in plaintext

            // init
            plaintextChars = plaintext.ToCharArray();
            rows = (int)Math.Ceiling((decimal)plaintextChars.Length / cypherKey);
            cols = cypherKey;
            cypherTemplate = new char[rows, cols];
            cyphertextChars = new char[rows * cols];

            charCounter = 0;
            // process encryption
            for (int i = 0; i < cypherTemplate.GetLength(0); i++)
            {
                for (int j = 0; j < cypherTemplate.GetLength(1); j++)
                {
                    if (charCounter < plaintextChars.Length)
                    {
                        cypherTemplate[i, j] = plaintextChars[charCounter++];
                    }
                    else
                    {
                        cypherTemplate[i, j] = ' ';
                    }
                }

            }
            charCounter = 0;
            for (int i = 0; i < cypherTemplate.GetLength(1); i++)
            {

                for (int j = 0; j < cypherTemplate.GetLength(0); j++)
                {
                    cyphertextChars[charCounter++] = cypherTemplate[j, i];
                }
            }
            return new string(cyphertextChars);
        }

        public string Decrypt(string cyphertext)
        {
            // declaration
            char[] plaintextChars;
            char[] cyphertextChars;
            char[,] cypherTemplate;
            int rows;  // template rows
            int cols;  // template cols
            int charCounter; // index current char  in plaintext

            // init
            cyphertextChars = cyphertext.ToCharArray();
            rows = (int)Math.Ceiling((decimal)cyphertextChars.Length / cypherKey);
            cols = cypherKey;
            cypherTemplate = new char[rows, cols];
            plaintextChars = new char[rows * cols];

            charCounter = 0;
            // process encryption
            // write by cols
            for (int i = 0; i < cypherTemplate.GetLength(1); i++)
            {
                for (int j = 0; j < cypherTemplate.GetLength(0); j++)
                {
                    if (charCounter < cyphertextChars.Length)
                    {
                        cypherTemplate[j, i] = cyphertextChars[charCounter++];
                    }
                    else
                    {
                        cypherTemplate[j, i] = ' ';
                    }
                }
            }
            // read by rows
            charCounter = 0;
            for (int i = 0; i < cypherTemplate.GetLength(0); i++)
            {

                for (int j = 0; j < cypherTemplate.GetLength(1); j++)
                {
                    plaintextChars[charCounter++] = cypherTemplate[i, j];
                }
            }
            return new string(plaintextChars);
        }
    }
}
