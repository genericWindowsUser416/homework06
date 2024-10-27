namespace homework06
{
    public class VendingMachine
    {
        protected string? Name { get; set; }
        protected double Balance { get; set; }
        
        protected bool doAddSugar { get; set; } = false;
        protected double finalCost { get; set; } = 0;
        protected double TotalSells { get; set; } = 0;
        protected List<CoffeeReceipt> _coffeeReceipts { get; set; }
        public VendingMachine(string inputtedName, double balance)
        {
            // _coffeeReceipts = _coffeeReceipts;
            if (balance > 0)
            {
                Balance = balance;
            }
            else
            {
                Balance = 0;
            }
            Name = inputtedName;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Имя автомата: {Name}\nБаланс: {Balance}\nПродано: {TotalSells}");
        }

        public virtual void Refuel()
        {

        }

        public virtual void giveChangeAndCountSells(double userCoinInput, double change, double neededCoins, int chosenCoffee)
        { 
        }

        public void eatCoins(double userCoinInput, double neededCoins, int chosenCoffee)
        {
            if (userCoinInput >= neededCoins)
            {
                double change = userCoinInput - neededCoins;
                if (Balance >= change)
                {
                    giveChangeAndCountSells(userCoinInput, change, neededCoins, chosenCoffee);
                }
                else
                {
                    Console.WriteLine("В автомате недостаточно сдачи");
                }
            }
            else
            {
                Console.WriteLine("Внесено недостаточно средств");
                PrintInfo();
            }
        }

        public virtual void chooseDrink()
        {
            
        }
    }
}