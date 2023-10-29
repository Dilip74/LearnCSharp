using System;

namespace DependencyInjectionExample
{
    // Client Class
    class DependencyInjection
    {
        private ISwitch iSwitch;

        public DependencyInjection(ISwitch _iSwitch)
        {
            iSwitch = _iSwitch;
        }

        public void ON()
        {
            iSwitch.ON();
        }
        public void OFF()
        {
            iSwitch.OFF();
        }
    }

    public interface ISwitch
    {
        void ON();
        void OFF();
    }

    // Service Class
    public class ACService : ISwitch
    {
        public void ON()
        {
            Console.WriteLine("AC ON Method");
        }
        public void OFF()
        {
            Console.WriteLine("AC OFF Method");
        }
    }

    // Service Class
    public class TVService : ISwitch
    {
        public void ON()
        {
            Console.WriteLine("TV ON Method");
        }
        public void OFF()
        {
            Console.WriteLine("TV OFF Method");
        }
    }
}
