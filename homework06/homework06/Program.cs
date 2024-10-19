namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VendingMachine machineV1 = new VendingMachine("FirstMachine", 1000, 5.0, 10.0, 4.0, 5.0, 3.0, 4.0, 2.0, 3.0, 500);
            VendingMachine machineV1 = new VendingMachine("FirstMachine", 50, 1.0, 5.0, 0.25, 3.4, 1.0, 1.5, 0.15, 4.5, 0);
            // machineV1.buyLatte(Convert.ToDouble(Console.ReadLine()));
            machineV1.Refuel();
            machineV1.buyLatte(Convert.ToDouble(Console.ReadLine()));

            machineV1.buyCappuccino(Convert.ToDouble(Console.ReadLine()));
        }
    }
}