using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleMatching
{
    internal static class Export
    {
        /// <summary>
        /// Экспорт списка статусов клиентов в файл result.txt, в корневую директорию данной программы.
        /// В случае, существования файла, к имени файла добавляется временная метка в формате "yyyyMMddHHmmssffff".
        /// </summary>
        /// <param name="clients"></param>
        internal static void Run(List<Client> clients)
        {
            List<string> exportData = new List<string>();

            foreach (var client in clients)
            {
                exportData.Add(String.Join('\t', new string[] 
                {
                    client.Name,
                    client.Balance.ToString("G"),
                    client.QtySecurityPaperA.ToString(),
                    client.QtySecurityPaperB.ToString(),
                    client.QtySecurityPaperC.ToString(),
                    client.QtySecurityPaperD.ToString()
                }));
            }

            string fileName = @"result.txt";

            while (File.Exists(fileName))
            {
                fileName = @"result-" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt";
            }

            File.WriteAllLines(fileName, exportData.ToArray());
        }
    }
}
