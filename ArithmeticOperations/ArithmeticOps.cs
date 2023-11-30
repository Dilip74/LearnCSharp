using System;

namespace ArithmeticOperations
{
    public class ArithmeticOps
    {
        public int Sum(int i, int j)
        {
            return i + j;
        }

        public int Sub(int i, int j)
        {
            return i - j;
        }

        public int Mul(int i, int j)
        {
            return i * j;
        }

        public int Div(int i, int j)
        {
            return i / j;
        }


        public virtual bool CheckDigitsOnly()
        {
            return false;
        }
    }

    public class Account
    {
        public double Balance { get; private set; }
        public double OverdraftLimit { get; private set; }

        public Account(double overdraftLimit)
        {
            this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
            this.Balance = 0;
        }

        public bool Deposit(double amount)
        {
            if (amount >= 0)
            {
                this.Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(double amount)
        {
            if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
