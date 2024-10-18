namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine machineV1 = new VendingMachine("FirstMachine", 1000, 5.0, 4.0, 3.0, 2.0, 1.0);
            Console.WriteLine(machineV1.Name);
        }
    }
}