namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine machineV1 = new VendingMachine("FirstMachine", 1000, 5.0, 10.0, 4.0, 5.0, 3.0, 4.0, 2.0, 3.0, 500);
            machineV1.PrintInfo();
            machineV1.buyLatte(); 
        }
    }
}