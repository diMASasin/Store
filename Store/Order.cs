using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Order
    {
        public string Paylink { get; private set; }

        private const int _paylinkLength = 20;

        public Order(Warehouse warehouse, IReadOnlyList<IReadOnlyCell> cartCells)
        {
            Paylink = GetRandomString(_paylinkLength);
            warehouse.Remove(cartCells);
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
