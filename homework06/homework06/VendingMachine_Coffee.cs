namespace homework06
{
    public class VendingMachine_Coffee
    {
        public string? Name { get; private set; }
        public double Balance { get; private set; }
        public double WaterLeft { get; private set; }
        public double CoffeeLeft { get; private set; }
        public double MilkLeft { get; private set; }
        public double SugarLeft { get; private set; }
        public double TotalSells { get; private set; } = 0;
        public double LatteCost { get; private set; } = 1.2;
        public double SugarPerCup { get; private set; } = 5;
        public double CappuccinoCost { get; private set; } = 1.1;
        public double AmericanoCost { get; private set; } = 1;
        public double BigCupSize { get; private set; } = 1.4;
        public double MediumCupSize { get; private set; } = 1.2;
        public double SmallCupSize { get; private set; } = 1;
        public double SugarForThisCup { get; private set; } = -1;
        public bool doAddSugar { get; private set; } = false;
        public double finalCost { get; private set; } = 0;
        private List<CoffeeReceipt> _coffeeReceipts { get; set; }
        public VendingMachine_Coffee(List<CoffeeReceipt> coffeeReceipts, string inputtedName, double balance)
        {
            _coffeeReceipts = _coffeeReceipts;
            if (balance > 0)
            {
                Balance = balance;
            }
            else
            {
                Balance = 0;
            }
            Name = inputtedName;
            WaterLeft = CoffeeOptions.WaterMax;
            CoffeeLeft = CoffeeOptions.CoffeeMax;
            MilkLeft = CoffeeOptions.MilkMax;
            SugarLeft = CoffeeOptions.SugarMax;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Имя автомата: {Name}\nБаланс: {Balance}\nПродано: {TotalSells}\nВода: {WaterLeft}/{CoffeeOptions.WaterMax}\nКофе: {CoffeeLeft}/{CoffeeOptions.CoffeeMax}\nМолоко: {MilkLeft}/{CoffeeOptions.MilkMax}\nСахар: {SugarLeft}/{CoffeeOptions.SugarMax}");
        }

        public void Refuel()
        {
            WaterLeft = CoffeeOptions.WaterMax;
            CoffeeLeft = CoffeeOptions.CoffeeMax;
            MilkLeft = CoffeeOptions.MilkMax;
            SugarLeft = CoffeeOptions.SugarMax;
        }

        public void giveChangeAndCountSells(double userCoinInput, double change, double neededCoins, int chosenCoffee)
        {
            CoffeeReceipt crnt = CoffeeOptions.GetBaseCoffeeRecieptList()[chosenCoffee - 1];
            if (WaterLeft >= crnt.Water && CoffeeLeft >= crnt.Coffee && MilkLeft >= crnt.Milk)
            {
                WaterLeft -= crnt.Water;
                CoffeeLeft -= crnt.Coffee;
                MilkLeft -= crnt.Milk;
                if (SugarForThisCup > 0)
                {
                    SugarLeft -= SugarForThisCup;
                }
                Balance += userCoinInput;
                if (change > 0)
                {
                    Console.WriteLine($"Ваша сдача: {change}");
                }
                Console.WriteLine("Кофе приготовлен успешно");
                Balance -= change;
                TotalSells += neededCoins;
            }
            else
            {
                Console.WriteLine("Недостаточно ингредиентов для кофе");
            }
            PrintInfo();
        }

        public void eatCoins(double userCoinInput, double neededCoins, int chosenCoffee)
        {
            if (userCoinInput >= neededCoins)
            {
                double change = userCoinInput - neededCoins;
                if (Balance >= change)
                {
                    giveChangeAndCountSells(userCoinInput, change, neededCoins, chosenCoffee);
                }
                else
                {
                    Console.WriteLine("В автомате недостаточно сдачи");
                }
            }
            else
            {
                Console.WriteLine("Внесено недостаточно средств");
                PrintInfo();
            }
        }

        public void chooseCoffee()
        {
            Console.WriteLine($"Выберите кофе (1-3)\nКапучино (1)\nЛатте (2)\nАмерикано (3)");
            int chosenCoffee = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Выберите размер порции (1-3)\n120 мл (1)\n240 мл (2)\n480 мл (3)");
            double chosenSize = Convert.ToDouble(Console.ReadLine());
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
                    break;
            }

            Console.WriteLine($"Добавить сахар?\nДа (1)\nНет (2)");
            if (Convert.ToDouble(Console.ReadLine()) == 1)
            {
                SugarForThisCup = chosenSize * SugarPerCup;
                finalCost += SugarForThisCup;
            }

            finalCost += chosenSize * CoffeeOptions.GetBaseCoffeeRecieptList()[chosenCoffee - 1].Cost;
            Console.WriteLine($"Стоимость: {finalCost}");
            eatCoins(Convert.ToDouble(Console.ReadLine()), finalCost, chosenCoffee);
        }
    }
}