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

        public double WaterUsedPerCappuccino { get; private set; } = 3;
        public double WaterUsedPerLatte { get; private set; } = 4;
        public double WaterUsedPerAmericano { get; private set; } = 2;

        public double MilkUsedPerCappuccino { get; private set; } = 3;
        public double MilkUsedPerLatte { get; private set; } = 2;

        public double CoffeeUsedPerCup { get; private set; } = 3;

        public double LatteCost { get; private set; } = 3;
        public double CappuccinoCost { get; private set; } = 3;
        public double AmericanoCost { get; private set; } = 3;

        public double BigCupSize { get; private set; } = 480;
        public double MediumCupSize { get; private set; } = 240;
        public double SmallCupSize { get; private set; } = 120;

        public double SugarPerCup { get; private set; } = 60;
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
            WaterLeft = WaterMax;
            CoffeeLeft = CoffeeMax;
            MilkLeft = MilkMax;
            SugarLeft = SugarMax;
        }

        public bool eatCoins(double userCoinInput, double neededCoins)
        {
            bool result = false;
            if (userCoinInput >= neededCoins)
            {
                double change = userCoinInput - neededCoins;
                if (Balance >= change)
                {
                    Balance += userCoinInput;
                    result = true;

                    Console.WriteLine($"Ваша сдача {change} монет");

                    Balance -= change;
                    Console.WriteLine($"баланс {Balance}");

                    TotalSells += neededCoins;
                    Console.WriteLine($"продано {TotalSells}");
                }
                else Console.WriteLine("В автомате недостаточно сдачи");
            }
            else Console.WriteLine("Недостаточно средств");
            return result;
        }

        public void buyCoffee(double userCoinInput, double cupSize, double WaterUsedPerCup, double CoffeeUsedPerCup, double MilkUsedPerCup, double CoffeeCost)
        {

            if (checkIngredients(userCoinInput, CoffeeCost, WaterLeft, cupSize, WaterUsedPerCup, MilkUsedPerCup))
            {
                WaterLeft -= (cupSize / WaterUsedPerCup);
                CoffeeLeft -= (cupSize / CoffeeUsedPerCup);
                if (MilkUsedPerCup > 0) MilkLeft -= (cupSize / MilkUsedPerCup);
                PrintInfo();
            }
            else Console.WriteLine("Недостаточно ингредиентов. Пополните запас.");
        }

        public bool checkIngredients(double userCoinInput, double CoffeeCost, double WaterLeft, double cupSize, double WaterUsedPerCup, double MilkUsedPerCup)
        {
            if (WaterLeft - (cupSize / WaterUsedPerCup) >= 0 &&
                CoffeeLeft - CoffeeUsedPerCup >= 0 &&
                MilkLeft - (cupSize / MilkUsedPerCup) >= 0 && 
                eatCoins(userCoinInput, CoffeeCost))
                return true;
            else return false;
        }

        public void chooseCoffee()
        {
            Console.WriteLine("Выберите кофе (1-3)");
            Console.WriteLine("Капучино (1)");
            Console.WriteLine("Латте (2)");
            Console.WriteLine("Американо (3)");
            double chosenCoffee = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Выберите размер порции (1-3)");
            Console.WriteLine("120 мл (1)");
            Console.WriteLine("240 мл (2)");
            Console.WriteLine("480 мл (3)");
            double chosenSize = Convert.ToDouble(Console.ReadLine());

            if (chosenSize == 1) chosenSize = SmallCupSize;
            else if (chosenSize == 2) chosenSize = MediumCupSize;
            else if (chosenSize == 3) chosenSize = BigCupSize;

            if (chosenCoffee == 1) buyCoffee(Convert.ToDouble(Console.ReadLine()), chosenSize, WaterUsedPerCappuccino, CoffeeUsedPerCup, MilkUsedPerCappuccino, CappuccinoCost);
            if (chosenCoffee == 2) buyCoffee(Convert.ToDouble(Console.ReadLine()), chosenSize, WaterUsedPerLatte, CoffeeUsedPerCup, MilkUsedPerLatte, LatteCost);
            if (chosenCoffee == 3) buyCoffee(Convert.ToDouble(Console.ReadLine()), chosenSize, WaterUsedPerAmericano, CoffeeUsedPerCup, -1, AmericanoCost);
        }
    }
}