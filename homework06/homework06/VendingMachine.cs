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

        public double MilkUsedPerCappuccino { get; private set; } = 0.2;
        public double MilkUsedPerLatte { get; private set; } = 0.25;
        public double CoffeeUsedPerCup { get; private set; } = 0.5;

        public double LatteCost { get; private set; } = 3;
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
        }
        public bool eatCoins(double userCoinInput, double neededCoins)
        {
            bool result = false;
            if (userCoinInput >= neededCoins)
            {
                Balance += userCoinInput;
                result = true;
                if (userCoinInput > neededCoins)
                {
                    Console.WriteLine($"Ваша сдача {userCoinInput - neededCoins} монет");
                }
            }
            return result;
        }
        public double buyLatte(double userCoinInput)
        {
            if (WaterLeft - WaterUsedPerCoffee >= 0 && CoffeeLeft - CoffeeUsedPerCup >= 0 && MilkLeft - MilkUsedPerLatte >= 0)
            {
                if (eatCoins(userCoinInput, LatteCost))
                {
                    WaterLeft -= WaterUsedPerCoffee;
                    CoffeeLeft -= CoffeeUsedPerCup;
                    MilkLeft -= MilkUsedPerLatte;
                    PrintInfo();
                }
                else Console.WriteLine("Недостаточно средств");
            }
            
            else Console.WriteLine("Недостаточно ингредиентов. Пополните запас.");
            return 0;
        }
    }
}