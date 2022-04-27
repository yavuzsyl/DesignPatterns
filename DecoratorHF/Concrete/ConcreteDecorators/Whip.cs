using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF.Concrete.ConcreteDecorators
{
    public class Whip : CondimentDecorator
    {
        public Whip(IBeverage beverage)
        {
            this.Beverage = beverage;
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + ", Whip";
        }

        public override double Cost()
        {
            return .10 + Beverage.Cost();
        }

    }

}
