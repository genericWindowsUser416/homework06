namespace homework06
{
    public class SodaOptions
    {
        public const double CokeMax = 1000;
        public const double ChernogolovkaMax = 1000;
        public const double PepsiMax = 1000;
        public static List<SodaReceipt> GetBaseDrinkReceiptList()
        {
            return new List<SodaReceipt>()
        {
            new SodaReceipt()
            {
                Name = "Кола",
                Coke = 1,
            },
            new SodaReceipt()
            {
                Name = "Черноголовка",
                Chernogolovka = 1,
            },
            new SodaReceipt()
            {
                Name = "Пепси",
                Pepsi = 1
            }
        };
        }
    }
}
