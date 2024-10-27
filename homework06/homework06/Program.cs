namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VendingMachine machineV1 = new VendingMachine(CoffeeOptions.GetBaseCoffeeRecieptList(), "Кофейня01", 500);
            // machineV1.chooseCoffee();
            // machineV1.Refuel();

            VendingMachine_Coffee machineV2 = new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "Кофейня02", 600);
            machineV2.chooseDrink();
        }
    }
}