namespace homework06
{
    internal class VendingMachine_Coffee : VendingMachine
    {
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
        public override void giveChangeAndCountSells(double userCoinInput, double change, double neededCoins, int chosenCoffee)
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
    }
}