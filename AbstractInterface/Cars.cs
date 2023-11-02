using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInterface
{
    //public abstract class Cars
    //{
    //    //Abstract Methods
    //    public abstract double price();
    //    public abstract int getTotalSeat();
    //}

    public class Cars
    {
        public string Wheel()
        {
            return "4 wheeler";
        }
        public string CheckAC()
        {
            return "AC is available";
        }
        public string CallFacility()
        {
            return "Call Facility  supported";
        }
    }

    public class Hyundai : Cars
    {
        
    }

    public class Toyota : Cars
    {
        public string DiscountPrice()
        {
            return "20% discount on buying Toyoya Cars";
        }
    }
}
