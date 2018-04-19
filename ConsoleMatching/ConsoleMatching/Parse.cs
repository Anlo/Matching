using System;
using System.Collections.Generic;

namespace ConsoleMatching
{
    internal static class Parse
    {

        /// <summary>
        /// Парсинг статусов клиентов из массива string, который был сформирован из файла clients.txt.
        /// </summary>
        /// <param name="clientsImport"></param>
        /// <returns></returns>
        internal static List<Client> ParseClient(string[] clientsImport)
        {
            List<Client> clients = new List<Client>();
            foreach (string client in clientsImport)
            {
                string[] data = client.Split('\t');
                if (data.Length == 6)
                {
                    clients.Add(new Client(data[0], data[1], data[2], data[3], data[4], data[5]));
                }
                else
                {
                    throw new Exception($"Incomplete data from input file client.\nLine: {client}");
                }
            }
            return clients;
        }

        /// <summary>
        /// Парсинг заявок из массива string, который был сформирован из файла orders.txt.
        /// </summary>
        /// <param name="ordersImport"></param>
        /// <returns></returns>
        internal static List<Order> ParseOrder(string[] ordersImport)
        {
            List<Order> orders = new List<Order>();
            foreach (string order in ordersImport)
            {
                string[] data = order.Split('\t');
                if (data.Length == 5)
                {
                    orders.Add(new Order(data[0], data[1], data[2], data[3], data[4]));
                }
                else
                {
                    throw new Exception($"Incomplete data from input file client.\nLine: {order}");
                }
            }
            return orders;
        }

        internal static int ParseInt(string input, string errorMessage)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                throw new Exception(errorMessage + input);
            }
        }

        internal static decimal ParseDecimal(string input, string errorMessage)
        {
            if (Decimal.TryParse(input, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.GetCultureInfo("en-US"), out decimal result))
            {
                return result;
            }
            else
            {
                throw new Exception(errorMessage + input);
            }
        }
    }
}
