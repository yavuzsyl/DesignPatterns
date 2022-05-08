using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Factory_Pattern_First_Look.Business
{
    internal class PurchaseProviderFactoryProvider
    {
        private IEnumerable<Type> factories;

        public PurchaseProviderFactoryProvider()
        {
            factories = Assembly.GetAssembly(typeof(PurchaseProviderFactoryProvider))
                .GetTypes()
                .Where(t => typeof(IPurchaseProviderFactory).IsAssignableFrom(t));
        }

        public IPurchaseProviderFactory CreateFactoryFor(string name)
        {
            var factory = factories.Single(f => f.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            return (IPurchaseProviderFactory)Activator.CreateInstance(factory);
        }
    }
}
