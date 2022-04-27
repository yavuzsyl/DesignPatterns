using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF.Concrete.ConcreteDecorators
{
    public class Soy : CondimentDecorator
    {
        public Soy(IBeverage bevarage)
        {
            Beverage = bevarage;
        }

        public override double Cost()
        {
            var cost = Beverage.Cost() + 0.15;
            cost = Beverage.Size switch
            {
                Size.TALL => cost += 0.10,
                Size.GRANDE => cost += 0.15,
                Size.VENTI => cost += 0.20,
                _ => cost
            };

            return cost; ;
        }
        public override string GetDescription()
        {
            return Beverage.GetDescription() + ", Soy";
        }
    }
}
