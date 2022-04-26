// See https://aka.ms/new-console-template for more information
using DecoratorHF;
using DecoratorHF.Concrete;
using DecoratorHF.Concrete.ConcreteDecorators;

//Factory and Builder ile iyileştirilecek

Console.WriteLine("Hello, World!");


IBeverage beverage = new Espresso();
Console.WriteLine(beverage.GetDescription() + " $" + beverage.Cost());

IBeverage beverage1 = new HouseBlend();
beverage1 = new Mocha(beverage1);
beverage1 = new Mocha(beverage1);
beverage1 = new Whip(beverage1);
Console.WriteLine(beverage1.GetDescription() + " $" + beverage1.Cost());

IBeverage beverage2 = new Espresso();
beverage2 = new Soy(beverage2);
beverage2 = new Mocha(beverage2);
beverage2 = new Whip(beverage2);
Console.WriteLine(beverage2.GetDescription() + " $" + beverage2.Cost());


Console.WriteLine();