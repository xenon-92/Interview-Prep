using System;

namespace L1_Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine sm = new CoffeeMachine();
            var res = sm.BrewCoffee(CoffeeSelection.Espresso);
            System.Console.WriteLine($"Here is your desired {res.selection.ToString()}");
        }
    }
    enum CoffeeSelection
    {
        FilterCoffee, Espresso, Cappuccino
    }

    class Coffee
    {
        public CoffeeSelection selection;
        public int quantity;
        public Coffee(CoffeeSelection selection, int quantity)
        {
            this.selection = selection;
            this.quantity = quantity;
        }
    }

    class CoffeeMachine
    {
        public Coffee BrewCoffee(CoffeeSelection selection)
        {
            Coffee coffee = new Coffee(selection, 1000);
            System.Console.WriteLine($"Making your {selection.ToString()} coffee......");
            return coffee;
        }
    }

}
