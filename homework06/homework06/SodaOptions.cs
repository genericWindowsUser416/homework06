namespace homework06
{
    public class SodaOptions
    {
        public const double ColaMax = 15;
        public const double ChernogolovkaMax = 15;
        public const double PepsiMax = 15;
        public static List<SodaReceipt> GetBaseSodaReceiptList()
        {
            return new List<SodaReceipt>()
        {
            new SodaReceipt()
            {
                Name = "Кола",
                Cola = 1,
                Cost = 90
            },
            new SodaReceipt()
            {
                Name = "Черноголовка",
                Chernogolovka = 1,
                Cost = 100
            },
            new SodaReceipt()
            {
                Name = "Пепси",
                Pepsi = 1,
                Cost = 90
            }
        };
        }
    }
}
