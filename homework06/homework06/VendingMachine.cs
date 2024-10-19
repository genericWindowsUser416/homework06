namespace homework06
{
    public class VendingMachine
    {
        public string? Name { get; private set; }
        public double Balance { get; private set; }
        public double WaterLeft { get; private set; }
        public double WaterMax { get; private set; }
        public double CoffeeLeft { get; private set; }
        public double CoffeeMax { get; private set; }
        public double MilkLeft { get; private set; }
        public double MilkMax { get; private set; }
        public double SugarLeft { get; private set; }
        public double SugarMax { get; private set; }
        public double TotalSells { get; private set; }

        public double WaterUsedPerCoffee { get; private set; } = 0.5;
        public VendingMachine(
            string name,
            double balance,
            double waterleft, double watermax,
            double coffeeleft, double coffeemax,
            double milkleft, double milkmax,
            double sugarleft, double sugarmax,
            double totalsells)
        {
            if (balance >= 0) Balance = balance;
            else Balance = 0;
            Name = name;
            WaterLeft = waterleft;
            CoffeeLeft = coffeeleft;
            MilkLeft = milkleft;
            SugarLeft = sugarleft;
            TotalSells = totalsells;
            WaterMax = watermax;
            CoffeeMax = coffeemax;
            MilkMax = milkmax;
            SugarMax = sugarmax;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name} {WaterLeft} {CoffeeLeft} {MilkLeft} {SugarLeft}");
        }

        public void Refuel()
        {
            WaterLeft += WaterMax - WaterLeft;
            CoffeeLeft += CoffeeMax - CoffeeLeft;
            MilkLeft += MilkMax - MilkLeft;
            SugarLeft += SugarMax - SugarLeft;
            Console.WriteLine($"{Name} {WaterLeft} {CoffeeLeft} {MilkLeft} {SugarLeft}");
        }
        public void buyLatte()
        {
            if (WaterLeft - WaterUsedPerCoffee >= 0)
            {
                WaterLeft -= WaterUsedPerCoffee;
                PrintInfo();
            }
        }
    }
}
