﻿namespace homework06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine_Soda machineSoda01 = new VendingMachine_Soda(SodaOptions.GetBaseSodaReceiptList(), "Пепсикола01", 500);
            machineSoda01.chooseDrink();

            VendingMachine_Coffee machineCoffee01 = new VendingMachine_Coffee(CoffeeOptions.GetBaseCoffeeReceiptList(), "Кофейня01", 600);
            machineCoffee01.chooseDrink();
        }
    }
}