namespace homework06
{
    internal class VendingMachine_Coffee : VendingMachine
    {
        protected double WaterLeft { get; set; }
        protected double CoffeeLeft { get; set; }
        protected double MilkLeft { get; set; }
        protected double SugarLeft { get; set; }
        protected double LatteCost { get; private set; } = 1.2;
        protected double SugarPerCup { get; private set; } = 5;
        protected double CappuccinoCost { get; private set; } = 1.1;
        protected double AmericanoCost { get; private set; } = 1;
        protected double BigCupSize { get; private set; } = 1.4;
        protected double MediumCupSize { get; private set; } = 1.2;
        protected double SmallCupSize { get; private set; } = 1;
        protected double SugarForThisCup { get; private set; } = -1;
        protected List<CoffeeReceipt> _coffeeReceipts { get; set; }
        public VendingMachine_Coffee(List<CoffeeReceipt> coffeeReceipts, string inputtedName, double balance) : base(inputtedName, balance)
        {
            _coffeeReceipts = _coffeeReceipts;
            WaterLeft = CoffeeOptions.WaterMax;
            CoffeeLeft = CoffeeOptions.CoffeeMax;
            MilkLeft = CoffeeOptions.MilkMax;
            SugarLeft = CoffeeOptions.SugarMax;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Имя автомата: {Name}\nБаланс: {Balance}\nПродано: {TotalSells}\nВода: {WaterLeft}/{CoffeeOptions.WaterMax}\nКофе: {CoffeeLeft}/{CoffeeOptions.CoffeeMax}\nМолоко: {MilkLeft}/{CoffeeOptions.MilkMax}\nСахар: {SugarLeft}/{CoffeeOptions.SugarMax}");
        }
        public override void Refuel()
        {
            WaterLeft = CoffeeOptions.WaterMax;
            CoffeeLeft = CoffeeOptions.CoffeeMax;
            MilkLeft = CoffeeOptions.MilkMax;
            SugarLeft = CoffeeOptions.SugarMax;
        }
        public override void giveChangeAndCountSells(double userCoinInput, double change, double neededCoins, int chosenDrink)
        {
            CoffeeReceipt crnt = CoffeeOptions.GetBaseCoffeeReceiptList()[chosenDrink - 1];
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
                Console.WriteLine("Напиток приготовлен успешно");
                Balance -= change;
                TotalSells += neededCoins;
            }
            else
            {
                Console.WriteLine("Недостаточно ингредиентов для напитка");
            }
            PrintInfo();
        }
        public override void chooseDrink()
        {
            Console.WriteLine($"Выберите напиток (1-3)\nКапучино (1)\nЛатте (2)\nАмерикано (3)");
            int chosenDrink = Convert.ToInt32(Console.ReadLine());


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

            finalCost += chosenSize * CoffeeOptions.GetBaseCoffeeReceiptList()[chosenDrink - 1].Cost;
            Console.WriteLine($"Стоимость: {finalCost}");
            eatCoins(Convert.ToDouble(Console.ReadLine()), finalCost, chosenDrink);
        }
    }
}