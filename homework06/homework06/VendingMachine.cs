namespace homework06
{
    public class VendingMachine
    {
        public string? Name { get; set; }
        public double Balance { get; set; }
        public double WaterLeft { get; set; }
        public double CoffeeLeft { get; set; }
        public double MilkLeft { get; set; }
        public double SugarLeft { get; set; }
        public double TotalSells { get; set; }
        public VendingMachine(string name, double balance, double waterleft, double coffeeleft, double milkleft, double sugarleft, double totalsells)
        {
            Name = name;
            if (balance >= 0) Balance = balance;
            else Balance = 0;
            WaterLeft = waterleft;
            CoffeeLeft = coffeeleft;
            MilkLeft = milkleft;
            SugarLeft = sugarleft;
            TotalSells = totalsells;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name}-{Balance}-{WaterLeft}");
        }

        public void AddWater(int mass)
        {
            WaterLeft += 1.0;
        }
    }
}
