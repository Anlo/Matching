using System.IO;

namespace ConsoleMatching
{
    internal class Import
    {
        /// <summary>
        /// Импорт данных из файлов clientsFileName и ordersFileName. Возвращаются данные в формате string[] по каждому из файлов.
        /// </summary>
        /// <param name="clientsFileName"></param>
        /// <param name="ordersFileName"></param>
        /// <returns></returns>
        internal static (string[], string[]) Run(string clientsFileName, string ordersFileName)
        {
            string[] clients = CheckFile(clientsFileName);
            string[] orders = CheckFile(ordersFileName);

            var result = (clients, orders);
            return result;
        }

        /// <summary>
        /// Проверка существует ли файл (string fileName). В случае, если существует, возвращается string[], содержащий все данные из файла.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string[] CheckFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllLines(fileName);
            }
            else
            {
                throw new FileNotFoundException($"File {fileName} is not exist.");
            }
        }
    }
}
