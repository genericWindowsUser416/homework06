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
        public double MilkUsedPerAmericano { get; private set; } = -1;

        public double CoffeeUsedPerCup { get; private set; } = 3;

        public double LatteCost { get; private set; } = 3;
        public double CappuccinoCost { get; private set; } = 3;
        public double AmericanoCost { get; private set; } = 3;

        public double BigCupSize { get; private set; } = 480;
        public double MediumCupSize { get; private set; } = 240;
        public double SmallCupSize { get; private set; } = 120;

        public double SugarPerCup { get; private set; } = 60;
        public bool doAddSugar { get; private set; } = false;
        public VendingMachine(
            string name,
            double balance,
            double watermax,
            double coffeemax,
            double milkmax,
            double sugarmax,
            double totalsells)
        {
            if (balance >= 0) Balance = balance;
            else Balance = 0;
            Name = name;
            WaterLeft = WaterMax = watermax;
            CoffeeLeft = CoffeeMax = coffeemax;
            MilkLeft = MilkMax = milkmax;
            SugarLeft = SugarMax = sugarmax;
            TotalSells = totalsells;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name} \nБаланс: {Balance}\nПродано: {TotalSells}\nВода: {WaterLeft}\nКофе: {CoffeeLeft}\nМолоко: {MilkLeft}\nСахар: {SugarLeft}");
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
                    TotalSells += neededCoins;

                }
                else Console.WriteLine("В автомате недостаточно сдачи");
            }
            else Console.WriteLine("Недостаточно средств");
            return result;
        }

        public void buyCoffee(double userCoinInput, double cupSize, double WaterForThisCup, double CoffeeForThisCup, double MilkForThisCup, double CoffeeCost)
        {

            if (checkIngredients(userCoinInput, CoffeeCost, WaterLeft, cupSize, WaterForThisCup, MilkForThisCup))
            {
                WaterLeft -= (cupSize / WaterForThisCup);
                CoffeeLeft -= (cupSize / CoffeeForThisCup);
                if (MilkForThisCup > 0) MilkLeft -= (cupSize / MilkForThisCup);
                if (doAddSugar) SugarLeft -= (cupSize / SugarPerCup);
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
            Console.WriteLine($"Выберите кофе (1-3)" +
                "\nКапучино (1)" +
                "\nЛатте (2)" +
                "\nАмерикано (3)");
            double chosenCoffee = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Выберите размер порции (1-3)" +
                "\n120 мл (1)" +
                "\n240 мл (2)" +
                "\n480 мл (3)");
            double chosenSize = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Добавить сахар?" +
                "\nДа (1)" +
                "\nНет (2)");

            doAddSugar = Convert.ToDouble(Console.ReadLine()) == 1;

            if (chosenSize == 1) chosenSize = SmallCupSize;
            else if (chosenSize == 2) chosenSize = MediumCupSize;
            else if (chosenSize == 3) chosenSize = BigCupSize;

            if (chosenCoffee == 1) buyCoffee(Convert.ToDouble(Console.ReadLine()), chosenSize, WaterUsedPerCappuccino, CoffeeUsedPerCup, MilkUsedPerCappuccino, CappuccinoCost);
            else if (chosenCoffee == 2) buyCoffee(Convert.ToDouble(Console.ReadLine()), chosenSize, WaterUsedPerLatte, CoffeeUsedPerCup, MilkUsedPerLatte, LatteCost);
            else if (chosenCoffee == 3) buyCoffee(Convert.ToDouble(Console.ReadLine()), chosenSize, WaterUsedPerAmericano, CoffeeUsedPerCup, MilkUsedPerAmericano, AmericanoCost);
        }
    }
}