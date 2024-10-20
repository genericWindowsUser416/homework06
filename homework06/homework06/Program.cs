namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VendingMachine machineV1 = new VendingMachine("FirstMachine", 1000, 5.0, 10.0, 4.0, 5.0, 3.0, 4.0, 2.0, 3.0, 500);
            VendingMachine machineV1 = new VendingMachine("FirstMachine", 50, 1000.0, 5000.0, 3400.0, 3400.0, 4000.0, 4000.0, 1500.0, 4500.0, 0);
            // machineV1.buyLatte(Convert.ToDouble(Console.ReadLine()));
            // machineV1.Refuel();
            machineV1.chooseCoffee();
            //machineV1.buyCappuccino(Convert.ToDouble(Console.ReadLine()));
        }
    }
}