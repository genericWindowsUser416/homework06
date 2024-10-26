namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine_Coffee machineV1 = new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeRecieptList(), "Кофейня01", 500);
            machineV1.chooseCoffee();
            machineV1.Refuel();
        }
    }
}