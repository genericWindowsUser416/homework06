namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //, "FirstMachine", 500, 5000.0, 3400.0, 4000.0, 1000.0
            VendingMachine machineV1 = new VendingMachine(CoffeeOptions.GetBaseCoffeeRecieptList(), "Кофейня01", 500);
            machineV1.chooseCoffee();
            machineV1.Refuel();
        }
    }
}