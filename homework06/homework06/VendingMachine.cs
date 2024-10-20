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
        public double WaterUsedPerAmericano { get; private set; } = 1.5;

        public double MilkUsedPerCappuccino { get; private set; } = 3;
        public double MilkUsedPerLatte { get; private set; } = 2;
        public double MilkUsedPerAmericano { get; private set; } = -1;

        public double LatteCost { get; private set; } = 1.2;
        public double CappuccinoCost { get; private set; } = 1.1;
        public double AmericanoCost { get; private set; } = 1;

        public double BigCupSize { get; private set; } = 480;
        public double MediumCupSize { get; private set; } = 240;
        public double SmallCupSize { get; private set; } = 120;

        public double CoffeeUsedPerCup { get; private set; } = 3;
        public double SugarPerCup { get; private set; } = 60;
        public bool doAddSugar { get; private set; } = false;
        public double finalCost { get; private set; } = 0;
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
            Console.WriteLine($"Имя автомата: {Name}\nБаланс: {Balance}\nПродано: {TotalSells}\nВода: {WaterLeft}/{WaterMax}\nКофе: {CoffeeLeft}/{CoffeeMax}\nМолоко: {MilkLeft}/{MilkMax}\nСахар: {SugarLeft}/{SugarMax}");
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

                    if (change > 0) Console.WriteLine($"Ваша сдача: {change}");
                    Console.WriteLine("Кофе приготовлен успешно");
                    Balance -= change;
                    TotalSells += neededCoins;
                }
                else Console.WriteLine("В автомате недостаточно сдачи");
            }
            else Console.WriteLine("Внесено недостаточно средств");
            return result;
        }

        public void buyCoffee(double userCoinInput, double cupSize, double WaterForThisCup, double CoffeeForThisCup, double MilkForThisCup, double CoffeeCost, double SugarForThisCup)
        {
            if (checkIfEnoughIngredientsAndCoins(userCoinInput, cupSize, WaterForThisCup, CoffeeForThisCup, MilkForThisCup, CoffeeCost, SugarForThisCup))
            {
                WaterLeft -= (cupSize / WaterForThisCup);
                CoffeeLeft -= (cupSize / CoffeeForThisCup);
                if (MilkForThisCup > 0) MilkLeft -= (cupSize / MilkForThisCup);
                if (doAddSugar) SugarLeft -= (cupSize / SugarPerCup);
                PrintInfo();
            }
        }

        public void ingredientsError()
        {
            Console.WriteLine($"Недостаточно ингредиентов для кофе. Пополните запас.");
            PrintInfo();
        }

        public bool checkIngredients(double CoffeeCost, double cupSize, double WaterUsedPerCup, double MilkUsedPerCup, double SugarForThisCup)
        {
            if (WaterLeft - (cupSize / WaterUsedPerCup) >= 0 && (CoffeeLeft - CoffeeUsedPerCup) >= 0 && MilkLeft - (cupSize / MilkUsedPerCup) >= 0 && SugarLeft - (cupSize / SugarForThisCup) >= 0)
                return true;
            else return false;
        }

        public bool checkIfEnoughIngredientsAndCoins(double userCoinInput, double cupSize, double WaterForThisCup, double CoffeeForThisCup, double MilkForThisCup, double CoffeeCost, double SugarForThisCup)
        {
            bool resultOfCheck = false;
            if (checkIngredients(CoffeeCost, cupSize, WaterForThisCup, MilkForThisCup, SugarForThisCup))
            {
                if (eatCoins(userCoinInput, CoffeeCost))
                {
                    resultOfCheck = true;
                }
            }
            else
            {
                resultOfCheck = false;
                ingredientsError();
            }
            return resultOfCheck;
        }

        public void chooseCoffee()
        {
            Console.WriteLine($"Выберите кофе (1-3)\nКапучино (1)\nЛатте (2)\nАмерикано (3)");
            double chosenCoffee = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Выберите размер порции (1-3)\n120 мл (1)\n240 мл (2)\n480 мл (3)");
            double chosenSize = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Добавить сахар?\nДа (1)\nНет (2)");
            doAddSugar = Convert.ToDouble(Console.ReadLine()) == 1;
            switch (chosenSize)
            {
                case 1:
                    chosenSize = SmallCupSize;
                    break;
                case 2:
                    chosenSize = MediumCupSize;
                    break;
                case 3:
                    chosenSize = BigCupSize;
                    break;
                default:
                    chosenSize = MediumCupSize;
                    return;
            }
            double SugarForThisCup = -1;
            if (doAddSugar)
            {
                SugarForThisCup = chosenSize / SugarPerCup;
                finalCost += SugarForThisCup;
            }

            double cost = 0;
            double waterUsed = 0;
            double milkUsed = 0;
            switch (chosenCoffee)
            {
                case 1:
                    cost = CappuccinoCost;
                    waterUsed = WaterUsedPerCappuccino;
                    milkUsed = MilkUsedPerCappuccino;
                    break;
                case 2:
                    cost = LatteCost;
                    waterUsed = WaterUsedPerLatte;
                    milkUsed = MilkUsedPerLatte;
                    break;
                case 3:
                    cost = AmericanoCost;
                    waterUsed = WaterUsedPerAmericano;
                    milkUsed = MilkUsedPerAmericano;
                    break;
                default:
                    Console.WriteLine("Неверный выбор кофе.");
                    return;
            }
            finalCost += chosenSize * cost;
            Console.WriteLine($"Стоимость: {finalCost}");
            buyCoffee(Convert.ToDouble(Console.ReadLine()), chosenSize, waterUsed, CoffeeUsedPerCup, milkUsed, finalCost, SugarForThisCup);
        }
    }
}