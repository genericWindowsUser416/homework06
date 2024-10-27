namespace homework06
{
    public class VendingMachine
    {
        protected string? Name { get; set; }
        protected double Balance { get; set; }
        protected double WaterLeft { get; set; }
        protected double CoffeeLeft { get; set; }
        protected double MilkLeft { get; set; }
        protected double SugarLeft { get; set; }
        protected double TotalSells { get; private set; } = 0;
        protected double LatteCost { get; private set; } = 1.2;
        protected double SugarPerCup { get; private set; } = 5;
        protected double CappuccinoCost { get; private set; } = 1.1;
        protected double AmericanoCost { get; private set; } = 1;
        protected double BigCupSize { get; private set; } = 1.4;
        protected double MediumCupSize { get; private set; } = 1.2;
        protected double SmallCupSize { get; private set; } = 1;
        protected double SugarForThisCup { get; private set; } = -1;
        protected bool doAddSugar { get; private set; } = false;
        protected double finalCost { get; private set; } = 0;
        protected List<CoffeeReceipt> _coffeeReceipts { get; set; }
        public VendingMachine(string inputtedName, double balance)
        {
            // _coffeeReceipts = _coffeeReceipts;
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

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Имя автомата: {Name}\nБаланс: {Balance}\nПродано: {TotalSells}");
        }

        public virtual void Refuel()
        {

        }

        public void giveChangeAndCountSells(double userCoinInput, double change, double neededCoins, int chosenCoffee)
        {
            CoffeeReceipt crnt = CoffeeOptions.GetBaseCoffeeReceiptList()[chosenCoffee - 1];
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
                Console.WriteLine("Недостаточно ингредиентов для напитка");
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

            finalCost += chosenSize * CoffeeOptions.GetBaseCoffeeReceiptList()[chosenCoffee - 1].Cost;
            Console.WriteLine($"Стоимость: {finalCost}");
            eatCoins(Convert.ToDouble(Console.ReadLine()), finalCost, chosenCoffee);
        }
    }
}