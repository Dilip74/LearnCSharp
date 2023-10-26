using System;

namespace DependencyInjectionExample
{
    // 1. Client Class = > The client class is a class which depends on the service class.
    // 2. Service Class = > The service class is a class that provides service to the client class.
    // 3. Injector Class = > The injector class injects the service class object into the client class.

    class Program
    {
        static void Main(string[] args)
        {
            SwitchService ACS = new SwitchService(new ACService());
            ACS.ON();
            ACS.OFF();

            SwitchService TVS = new SwitchService(new TVService());
            TVS.ON();
            TVS.OFF();

            Console.ReadKey();
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

    // Client Class
    public class SwitchService
    {
        private ISwitch iSwitch;

        public SwitchService(ISwitch _iSwitch)
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
}
