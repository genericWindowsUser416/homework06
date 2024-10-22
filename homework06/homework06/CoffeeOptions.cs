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
                    Water = 1,
                    Coffee = 1,
                    Milk = 1
                },
                new CoffeeReceipt()
                {
                    Name = "Латте",
                    Water = 1,
                    Coffee = 1,
                    Milk = 3
                },
                new CoffeeReceipt()
                {
                    Name = "Американо",
                    Water = 1,
                    Coffee = 1,
                    Milk = 0
                }
            };
        }
    }
}
