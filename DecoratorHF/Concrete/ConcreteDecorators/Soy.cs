using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF.Concrete.ConcreteDecorators
{
    public class Soy : ICondimentDecorator
    {
        public Soy(IBeverage bevarage)
        {
            Beverage = bevarage;
        }
        public IBeverage Beverage { get; set; }
        public string Description { get; set; }
        public Size Size { get; set; }

        public double Cost()
        {
            return Beverage.Cost() + 0.15;
        }
        public string GetDescription()
        {
            return Beverage.GetDescription() + ", Soy";
        }
    }
}
