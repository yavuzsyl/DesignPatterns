using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF.Concrete.ConcreteDecorators
{
    public class Whip : ICondimentDecorator
    {
        public IBeverage Beverage { get; set; }
        public string Description { get; set; }
        public Size Size { get; set; }

        public Whip(IBeverage beverage)
        {
            this.Beverage = beverage;
        }

        public string GetDescription()
        {
            return Beverage.GetDescription() + ", Whip";
        }

        public double Cost()
        {
            return .10 + Beverage.Cost();
        }
    }

}
