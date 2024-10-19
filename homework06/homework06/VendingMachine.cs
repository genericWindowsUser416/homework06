﻿namespace homework06
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

        public double SugarPerCuo { get; private set; } = 60;
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

        public void buyLatte(double userCoinInput, double cupSize)
        {
            if (WaterLeft - (cupSize / WaterUsedPerLatte) >= 0 && CoffeeLeft - CoffeeUsedPerCup >= 0 && MilkLeft - (cupSize / MilkUsedPerLatte) >= 0)
            {
                if (eatCoins(userCoinInput, LatteCost))
                {
                    WaterLeft -= (cupSize / WaterUsedPerLatte);
                    CoffeeLeft -= (cupSize / CoffeeUsedPerCup);
                    MilkLeft -= (cupSize / MilkUsedPerLatte);
                    PrintInfo();
                }
            }

            else Console.WriteLine("Недостаточно ингредиентов. Пополните запас.");
        }
    }
}