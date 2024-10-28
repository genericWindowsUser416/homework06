namespace homework06
{
    internal class VendingMachine_Soda : VendingMachine
    {
        protected double ColaLeft { get; set; }
        protected double ChernogolovkaLeft { get; set; }
        protected double PepsiLeft { get; set; }
        protected List<SodaReceipt> _sodaReceipts { get; set; }
        public VendingMachine_Soda(List<SodaReceipt> sodaReceipts, string inputtedName, double balance) : base(inputtedName, balance)
        {
            _sodaReceipts = _sodaReceipts;
            ColaLeft = SodaOptions.ColaMax;
            ChernogolovkaLeft = SodaOptions.ChernogolovkaMax;
            PepsiLeft = SodaOptions.PepsiMax;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Имя автомата: {Name}\nБаланс: {Balance}\nПродано: {TotalSells}\nКола: {ColaLeft}/{SodaOptions.ColaMax}\nЧерноголовка: {ChernogolovkaLeft}/{SodaOptions.ChernogolovkaMax}\nПепси: {PepsiLeft}/{SodaOptions.PepsiMax}");
        }

        public override void Refuel()
        {
            ColaLeft = SodaOptions.ColaMax;
            ChernogolovkaLeft = SodaOptions.ChernogolovkaMax;
            PepsiLeft = SodaOptions.PepsiMax;
        }

        public override void giveChangeAndCountSells(double userCoinInput, double change, double neededCoins, int chosenDrink)
        {
            SodaReceipt crnt = SodaOptions.GetBaseSodaReceiptList()[chosenDrink - 1];
            if (ColaLeft >= crnt.Cola && ChernogolovkaLeft >= crnt.Chernogolovka && PepsiLeft >= crnt.Pepsi)
            {
                ColaLeft -= crnt.Cola;
                ChernogolovkaLeft -= crnt.Chernogolovka;
                PepsiLeft -= crnt.Pepsi;
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
            Console.WriteLine($"Выберите напиток (1-3)\nКола (1)\nЧерноголовка (2)\nПепси (3)");
            int chosenDrink = Convert.ToInt32(Console.ReadLine());

            finalCost = SodaOptions.GetBaseSodaReceiptList()[chosenDrink - 1].Cost;
            Console.WriteLine($"Стоимость: {finalCost}");
            eatCoins(Convert.ToDouble(Console.ReadLine()), finalCost, chosenDrink);
        }
    }
}
