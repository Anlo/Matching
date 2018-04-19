using System.Collections.Generic;



namespace ConsoleMatching
{
    internal class Processing
    {
        /// <summary>
        /// Обработка заявок (orders) с внесением изменений в статус клиента.
        /// </summary>
        /// <param name="clients"></param>
        /// <param name="orders"></param>
        internal static void Run(ref List<Client> clients, List<Order> orders)
        {
            for (int i = 1; i < orders.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (
                        orders[i].ClientName != orders[j].ClientName &&
                        orders[i].Operation != orders[j].Operation &&
                        orders[i].SecurityPaper == orders[j].SecurityPaper&&
                        orders[i].Price == orders[j].Price &&
                        orders[i].Qty == orders[j].Qty
                        )
                    {
                        Client buyer = null;
                        Client seller = null;

                        if (orders[i].Operation == "b")
                        {
                            buyer = clients.Find(x => x.Name == orders[i].ClientName);
                            seller = clients.Find(x => x.Name == orders[j].ClientName);
                        }
                        else
                        {
                            seller = clients.Find(x => x.Name == orders[i].ClientName);
                            buyer = clients.Find(x => x.Name == orders[j].ClientName);
                        }

                        Transaction(ref buyer, ref seller, orders[i].SecurityPaper, orders[i].Qty, orders[i].Price);

                        orders.RemoveAt(i);
                        orders.RemoveAt(j);

                        if (i > 2)
                        {
                            i -= 2;
                        }
                        else
                        {
                            i = 0;
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Выполнение транзакции покупки-продажи ценной бумаги (securityPaper).
        /// </summary>
        /// <param name="buyer"></param>
        /// <param name="seller"></param>
        /// <param name="securityPaper"></param>
        /// <param name="qty"></param>
        /// <param name="price"></param>
        private static void Transaction(ref Client buyer, ref Client seller, string securityPaper, int qty, int price)
        {
            decimal summ = qty * price;
            buyer.Balance -= summ;
            seller.Balance += summ;

            switch (securityPaper)
            {
                case "A":
                    buyer.QtySecurityPaperA += qty;
                    seller.QtySecurityPaperA -= qty;
                    break;
                case "B":
                    buyer.QtySecurityPaperB += qty;
                    seller.QtySecurityPaperB -= qty;
                    break;
                case "C":
                    buyer.QtySecurityPaperC += qty;
                    seller.QtySecurityPaperC -= qty;
                    break;
                case "D":
                    buyer.QtySecurityPaperD += qty;
                    seller.QtySecurityPaperD -= qty;
                    break;
                default:                    
                    break;
            }
        }
    }
}
