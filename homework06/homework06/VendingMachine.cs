namespace homework06
{
    public abstract class VendingMachine
    {
        protected string? Name { get; set; }
        protected double Balance { get; set; }
        protected bool doAddSugar { get; set; } = false;
        protected double finalCost { get; set; } = 0;
        protected double TotalSells { get; set; } = 0;
        public VendingMachine(string inputtedName, double balance)
        {
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
        public string PrintName()
        {
            return Name;
        }
        public abstract bool RefuelIfNeeded();

        public abstract void giveChangeAndCountSells(double userCoinInput, double change, double neededCoins, int chosenDrink);

        public void eatCoins(double userCoinInput, double neededCoins, int chosenDrink)
        {
            if (userCoinInput >= neededCoins)
            {
                double change = userCoinInput - neededCoins;
                if (Balance >= change)
                {
                    giveChangeAndCountSells(userCoinInput, change, neededCoins, chosenDrink);
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

        public abstract void chooseDrink();
    }
}