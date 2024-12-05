namespace Store
{
    public class Order
    {
        private const int PaylinkLength = 20;
        
        public string Paylink { get; private set; }

        public Order()
        {
            Paylink = GetRandomString(PaylinkLength);
        }

        private string GetRandomString(int length)
        {
            string availableSymbols = "qwertyuiopasdfghjklzxcvbnm0123456789";
            string newString = "";
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int symbolIndex = random.Next(availableSymbols.Length);
                newString += availableSymbols[symbolIndex];
            }

            return newString;
        }
    }
}
