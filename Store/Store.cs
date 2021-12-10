using System;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View();

            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse warehouse = new Warehouse();
            warehouse.Add(iPhone11, -5); //Ошибка

            Shop shop = new Shop(warehouse);

            warehouse.Add(iPhone12, 10);
            warehouse.Add(iPhone12, 5);
            warehouse.Add(iPhone11, 1);

            ////Вывод всех товаров на складе с их остатком
            view.ShowStorage(warehouse.CellsView);

            Cart cart = shop.GetCart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            ////Вывод всех товаров в корзине
            view.ShowStorage(cart.CellsView);

            Console.WriteLine(cart.Order().Paylink);  //Paylink - просто какая-нибудь случайная строка.
            Console.WriteLine();

            view.ShowStorage(warehouse.CellsView);
            cart.Add(iPhone12, 14); //Ошибка, после заказа со склада убираются заказанные товары
        }
    }
}
