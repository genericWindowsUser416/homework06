namespace homework06
{
    public class VendingManager
    {
        List<VendingMachine> machines = new List<VendingMachine>();
        public void CreatingMachines()
        {
            machines = new List<VendingMachine>()
            {
                new VendingMachine_Soda(SodaOptions.GetBaseSodaReceiptList(), "StandardSoda", 500),
                new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "StandardCoffee", 1000)  
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
        public void ChooseMachineToAdd()
        {
            Console.WriteLine($"Выберите тип автомата\nКофе (1)\nГазировки (2)");
            int drinkType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Имя автомата");
            string MachineName = Console.ReadLine();
            Console.WriteLine("Баланс автомата");
            double MachineBalance = Convert.ToInt32(Console.ReadLine());
            if (drinkType == 1)
            {
                machines.Add(new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), MachineName, MachineBalance));
            }
            else if (drinkType == 2)
            {
                machines.Add(new VendingMachine_Soda(SodaOptions.GetBaseSodaReceiptList(), MachineName, MachineBalance));
            }
        }
    }
}
