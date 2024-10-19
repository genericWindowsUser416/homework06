namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VendingMachine machineV1 = new VendingMachine("FirstMachine", 1000, 5.0, 10.0, 4.0, 5.0, 3.0, 4.0, 2.0, 3.0, 500);
            VendingMachine machineV1 = new VendingMachine("FirstMachine", 1000, 1.0, 10.0, 0.25, 2.0, 0.1, 4.0, 0.1, 3.0, 500);
            // machineV1.buyLatte(Convert.ToDouble(Console.ReadLine()));
            machineV1.Refuel();
            machineV1.buyLatte(Convert.ToDouble(Console.ReadLine()));
        }
    }
}