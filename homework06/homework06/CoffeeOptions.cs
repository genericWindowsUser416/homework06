namespace homework06
{
    public class CoffeeOptions
    {
        public const double WaterMax = 1000;
        public const double CoffeeMax = 1000;
        public const double MilkMax = 1000;
        public const double SugarMax = 1000;

        public static List<CoffeeReceipt> GetBaseCoffeeRecieptList()
        {
            return new List<CoffeeReceipt>()
            {
                new CoffeeReceipt()
                {
                    Name = "Капучино",
                    Water = 50,
                    Coffee = 50,
                    Milk = 100,
                    Cost = 180
                },
                new CoffeeReceipt()
                {
                    Name = "Латте",
                    Water = 50,
                    Coffee = 50,
                    Milk = 150,
                    Cost = 200
                },
                new CoffeeReceipt()
                {
                    Name = "Американо",
                    Water = 50,
                    Coffee = 50,
                    Milk = 0,
                    Cost = 160
                }
            };
        }
    }
}
