using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF
{
    //Decorator
    public interface ICondimentDecorator : IBeverage
    {
        IBeverage Beverage { get; set; }
        
        public new Size GetSize()
        {
            return Beverage.GetSize();
        }
    }

}
