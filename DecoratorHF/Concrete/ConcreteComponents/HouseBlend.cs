using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF.Concrete
{
    public class HouseBlend : IBeverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
        }
        public string Description { get; set; }
        public Size Size { get; set; }

        public double Cost()
        {
            return 0.89;
        }

    }
}
