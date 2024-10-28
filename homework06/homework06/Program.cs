namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine_Soda machineV1 = new VendingMachine_Soda(SodaOptions.GetBaseSodaReceiptList(), "Пепсикола01", 500);
            machineV1.chooseDrink();

            VendingMachine_Coffee machineV2 = new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "Кофейня01", 600);
            machineV2.chooseDrink();
        }
    }
}