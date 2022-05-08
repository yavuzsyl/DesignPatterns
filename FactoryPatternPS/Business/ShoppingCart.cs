using Factory_Pattern_First_Look.Business.Models.Commerce;
using Factory_Pattern_First_Look.Business.Models.Shipping;
using Factory_Pattern_First_Look.Business.Models.Shipping.Factories;
using System;

namespace Factory_Pattern_First_Look.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly IPurchaseProviderFactory purchaseProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
            this.order = order;
            this.purchaseProviderFactory = purchaseProviderFactory;
        }

        public string Finalize()    
        {
            #region Create Shipping Provider
            var shippingProvider = purchaseProviderFactory.CreateShippingProvider(order);
            #endregion

            var invoice = purchaseProviderFactory.CreateInvoice(order);
            invoice.GenerateInvoice();

            var summary = purchaseProviderFactory.CreateSummary(order);
            summary.Send();

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
