using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Transaction
    {   // Create unique transaction ID
        public readonly string TRANSACTION_ID;//  A0000012345F
        private static int counter = 1;
        private object TransactionData { get; set; }
        public Transaction(object transactionData)
        {
            TransactionData = transactionData;
            TRANSACTION_ID = $"A{counter++:D010}F";

        }
        public Transaction() : this(new object())
        {

        }
        public Transaction(Transaction transaction) : this(transaction.TransactionData)
        {

        }

    } 
}
