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
}
