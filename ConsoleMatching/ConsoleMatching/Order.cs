using System;

namespace ConsoleMatching
{
    /// <summary>
    /// Заявка
    /// </summary>
    internal class Order
    {
        internal string ClientName { get; set; }
        internal string Operation { get; set; }
        internal string SecurityPaper { get; set; }
        internal int Price { get; set; }
        internal int Qty { get; set; }

        public Order(string clientName, string operation, string securityPaper, string price, string qty)
        {
            string errorMessage = " format string is incorrect: ";
            string[] operationKeys = new string[] { "b", "s" };
            string[] securityPaperKeys = new string[] { "A", "B", "C", "D" };

            ClientName = clientName;
            Operation = CheckString(operation, operationKeys, "Operation" + errorMessage);
            SecurityPaper = CheckString(securityPaper, securityPaperKeys, "SecurityPaper" + errorMessage);
            Price = Parse.ParseInt(price, "Price" + errorMessage);
            Qty = Parse.ParseInt(qty, "Qty" + errorMessage);
        }

        /// <summary>
        /// Проверка входных данных (string input) на соответствие контрольным значениям (string[] keys).
        /// </summary>
        /// <param name="input"></param>
        /// <param name="keys"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private string CheckString(string input, string[] keys, string errorMessage)
        {
            bool isCorrect = false;
            foreach (string key in keys)
            {
                if (input == key)
                {
                    isCorrect = true;
                    break;
                }
            }

            if (isCorrect)
            {
                return input;
            }
            else
            {
                throw new Exception(errorMessage + input);
            }
        }
    }
}
