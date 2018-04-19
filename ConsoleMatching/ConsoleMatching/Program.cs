using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTestProject")]

namespace ConsoleMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            // Данные импортируются из файлов clients.txt и orders.txt, находящихся в корневой директории данной программы.
            string clientsFileName = @"clients.txt";
            string ordersFileName = @"orders.txt";

            // Импорт данных из файлов в массив string.
            var importData = Import.Run(clientsFileName, ordersFileName);
            string[] clientsRawData = importData.Item1;
            string[] ordersRawData = importData.Item2;

            // Парсинг массивов string с формированием списка состояний клиентов и списка заявок.
            List<Client> clients = Parse.ParseClient(clientsRawData);
            List<Order> orders = Parse.ParseOrder(ordersRawData);

            // Обработка заявок.
            Processing.Run(ref clients, orders);

            // Экспорт списка состояний клиентов в файл result.txt
            Export.Run(clients);
        }
    }
}
