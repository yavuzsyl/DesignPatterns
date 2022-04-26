using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF.Concrete
{
    internal class Espresso : IBeverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }
        public string Description { get; set; }
        public Size Size { get; set; }

        public double Cost()
        {
            return 1.99;
        }
    }
}
