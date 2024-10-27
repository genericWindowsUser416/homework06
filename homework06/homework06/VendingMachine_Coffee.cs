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
    }
}
