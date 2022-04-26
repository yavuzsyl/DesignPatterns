using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorHF
{
    public interface IBeverage//Component
    {
        public Size Size { get; set; }
        public string Description { get; set; }
        public string GetDescription() { return Description; }
        public double Cost();

        public void SetSize(Size size) { Size = size; }
        public Size GetSize() { return Size; }

    }


    public enum Size
    {
        TALL, GRANDE, VENTI
    }
}
