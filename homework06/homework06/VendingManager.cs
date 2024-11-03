namespace homework06
{
    public class VendingManager
    {
        List<VendingMachine> machines = new List<VendingMachine>();
        public void CreatingMachines()
        {
            machines = new List<VendingMachine>()
            {
                new VendingMachine_Soda(SodaOptions.GetBaseSodaReceiptList(), "Gleb1", 600),
                new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "Oleg1", 600),
                new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "Oleg2", 600),
                new VendingMachine_Soda(SodaOptions.GetBaseSodaReceiptList(), "Gleb2", 600),
                new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "Oleg3", 600)
            };
        }
        public void RefuelAll()
        {
            foreach (VendingMachine m in machines)
            {
                if (m.RefuelIfNeeded())
                {
                    Console.WriteLine($"{m.PrintName()} был починен");
                }
            }
        }
        public void DestroyMachines(string NameOfMachineToDestroy)
        {
            foreach (VendingMachine m in machines.ToList())
            {
                if (m.PrintName() == NameOfMachineToDestroy)
                {

                    machines.Remove(m);
                }
            }
            foreach (VendingMachine m in machines)
            {
                Console.WriteLine(m.PrintName());
            }
        }
    }
}
