using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF
{
    //Decorator
    public abstract class CondimentDecorator : IBeverage
    {
        public Size Size { get; set; }
        public string Description { get; set; }
        public IBeverage Beverage { get; set; }

        public abstract double Cost();
        public abstract string GetDescription();

        public Size GetSize()
        {
            return Beverage.GetSize();
        }
    }

}
