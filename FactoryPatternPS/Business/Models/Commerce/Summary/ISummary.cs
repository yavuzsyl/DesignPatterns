using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Pattern_First_Look.Business.Models.Commerce.Summary
{
    public interface ISummary
    {
        public string CreateOrderSummary();
        public void Send();
    }

    public class EmailSummary : ISummary
    {
        public string CreateOrderSummary()
        {
            return "Email Summary";
        }

        public void Send()
        {
            return;
        }
    }

    public class SMSSummary : ISummary
    {
        public string CreateOrderSummary()
        {
            return "SMS Summary";
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
