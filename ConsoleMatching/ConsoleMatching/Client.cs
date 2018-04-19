namespace ConsoleMatching
{
    /// <summary>
    /// Статус клиента
    /// </summary>
    internal class Client
    {
        internal string Name { get; set; }
        internal decimal Balance { get; set; }
        internal int QtySecurityPaperA { get; set; }
        internal int QtySecurityPaperB { get; set; }
        internal int QtySecurityPaperC { get; set; }
        internal int QtySecurityPaperD { get; set; }

        internal Client(string name, string balance, string qtySecurityPaperA, string qtySecurityPaperB, string qtySecurityPaperC, string qtySecurityPaperD)
        {
            string intErrorMessage = "Incorrect QtySecurityPaper format string: ";
            string balanceErrorMessage = "Incorrect balance format string: ";

            Name = name;
            Balance = Parse.ParseDecimal(balance, balanceErrorMessage);
            QtySecurityPaperA = Parse.ParseInt(qtySecurityPaperA, intErrorMessage);
            QtySecurityPaperB = Parse.ParseInt(qtySecurityPaperB, intErrorMessage);
            QtySecurityPaperC = Parse.ParseInt(qtySecurityPaperC, intErrorMessage);
            QtySecurityPaperD = Parse.ParseInt(qtySecurityPaperD, intErrorMessage);
        }        
    }
}
