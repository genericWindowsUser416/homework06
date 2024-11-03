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
                    Console.WriteLine($"{m.GetName()} был починен");
                }
            }
        }
        public void DestroyMachine(string NameOfMachineToDestroy)
        {
            foreach (VendingMachine m in machines.ToList())
            {
                if (m.GetName() == NameOfMachineToDestroy)
                {
                    machines.Remove(m);
                    break;
                }
            }
        }
        public double GetAllSells()
        {
            double totalSellsAmongAllMachines = 0;
            foreach (VendingMachine m in machines)
            {
                totalSellsAmongAllMachines = totalSellsAmongAllMachines + m.GetSells();
            }
            Console.WriteLine(totalSellsAmongAllMachines);
            return totalSellsAmongAllMachines;
        }
        public void OrderDrink(string NameOfMachineToOrder)
        {
            foreach (VendingMachine m in machines.ToList())
            {
                if (m.GetName() == NameOfMachineToOrder)
                {
                    m.chooseDrink();
                    break;
                }
            }
        }
    }
}
