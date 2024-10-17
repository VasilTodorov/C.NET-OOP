using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12SampleCode
{
    

    public class BankAccount
    {

        private double interestRate;
        private double balance;
        private string name;
        public BankAccount(string name, double interestRate)
        {
            this.interestRate = interestRate;
            this.name = name;
            this.balance = 0.0;
        }

        public double Balance
        {
            get
            {
                return balance;
            }
        }
        public string Name
        {
            get { return name; }
        }
        public void Withdraw(double amount)
        {
            balance -= amount;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void AddInterests()
        {
            balance = balance + balance * interestRate;
        }

        public override string ToString()
        {
            return "The " + name+ "'s account holds " +
                  +balance + " USD";
        }
    } 
}
