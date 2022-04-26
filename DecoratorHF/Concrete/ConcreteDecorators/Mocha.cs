using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF.Concrete.ConcreteDecorators
{
    public class Mocha : ICondimentDecorator
    {
        public Mocha(IBeverage beverage)
        {
            Beverage = beverage;
        }
        public string Description { get; set; }
        public IBeverage Beverage { get; set; }
        public Size Size { get; set; }

        public double Cost()
        {
            return Beverage.Cost() + 0.20;
        }

        public string GetDescription()
        {
            return Beverage.GetDescription() + ", Mocha";
        }

    }
}
