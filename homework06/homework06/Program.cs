namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {

            VendingManager mainManager = new VendingManager();
            mainManager.CreatingMachines();
            mainManager.DestroyMachine("Oleg1");
            mainManager.OrderDrink("Oleg2");
            mainManager.GetAllSells();
            mainManager.RefuelAll();
            //VendingMachine_Soda machineSoda01 = new VendingMachine_Soda(SodaOptions.GetBaseSodaReceiptList(), "Пепсикола01", 500);
            //machineSoda01.chooseDrink();
            //
            //VendingMachine_Coffee machineCoffee01 = new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "Кофейня01", 600);
            //machineCoffee01.chooseDrink();
            //
        }
    }
}