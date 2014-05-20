using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ARDSQL_GUI
{
    /// <summary>
    /// Klasa implementuje lokalną bazę testową
    /// <remarks>Potem do usunięcia</remarks>
    /// </summary>
    class SQLCon
    {
        /// <summary>
        /// Obiekt służący do obsługi bazy danych
        /// </summary>
        private MySqlConnection mysqlTestConn;
        /// <summary>
        /// Dane do połączenia się z bazą
        /// </summary>
        private List<string> serverCredentials = new List<string>(4);
        /// <summary>
        /// String służący do połączenia z bazą
        /// </summary>
        string connectionString = " ";
        /// <summary>
        /// Konstruktor
        /// </summary>
        public SQLCon()
        {
        }
        private void init()
        {
            serverCredentials[0] = "localhost";
            serverCredentials[1] = "netrunnertest";
            serverCredentials[2] = "root";
            serverCredentials[3] = "sam1";
            for (int i = 0; i < serverCredentials.Capacity; i++)
            {
                connectionString += serverCredentials[i];
            }
            this.mysqlTestConn = new MySqlConnection(connectionString);
        }
    }
}
