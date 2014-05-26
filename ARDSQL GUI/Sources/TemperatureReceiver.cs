using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace ARDSQL_GUI
{
    /*
     * 
     * TODO: LICZENIE REKORDÓW Z BAZY
     * 
     */
    /// <summary>
    /// Implementacja serwera odbierającego
    /// </summary>
    class TemperatureReceiver
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public TemperatureReceiver()
        {
            try
            {
                Configuration sqlConf = new Configuration("Conf\\Server.conf");
                sqlClientConfiguration = sqlConf.getSQLServerConfiguration();
                //initAttributes(); //pobranie danych z późniejszego inputu
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Połączenie się z bazą
        /// </summary>
        /// <remarks>
        /// Element 0 - ip serwera
        /// Element 1 - nazwa bazy danych
        /// Element 2 - nazwa użytkownika
        /// Element 3 - Nazwa tabeli
        /// Element 4 - hasło [zostanie dodany]
        /// Element 5 - connection string [i ten tez :D]
        /// </remarks>
        private void initAttributes()
        {
            Console.WriteLine("Applying configuration and connecting to database...");
            string passwordTemp = Console.ReadLine();
            sqlClientConfiguration.Add(passwordTemp);
            string tempConnectionString = "server=" + sqlClientConfiguration[0] + ";" + "port=3306" + ";" + "database=" + sqlClientConfiguration[1] + ";" + "uid=" + sqlClientConfiguration[2] + ";" + "password=" + sqlClientConfiguration[4] + ";";
            sqlClientConfiguration.Add(tempConnectionString);
            this.mysqlDbConnection = new MySqlConnection(this.sqlClientConfiguration[5]);
            this.sqlQuerySelect = "SELECT * " + "FROM " + sqlClientConfiguration[3];
   
        }
        /// <summary>
        /// Odebranie danych z bazy danych
        /// </summary>
        /// <returns>Zwraca dane w postaci gotowego napięcia</returns>
        public Voltage getRpiData()
        {
            
            List<string> readData = new List<string>(); //odczytane dane
            Voltage tempVoltage = new Voltage(0.0f); //tymczasowe napięcie
            try
            {
                this.mysqlDbConnection.Open();
                MySql.Data.MySqlClient.MySqlCommand test; //nasz 'cotainer' na zapytanie
                MySql.Data.MySqlClient.MySqlDataReader voltageReader; ///odczytywacz danych
                Console.WriteLine("Done. Getting voltage info from database...");
                test = new MySqlCommand(this.sqlQuerySelect, mysqlDbConnection);
                voltageReader = test.ExecuteReader();
                Console.WriteLine("Reading data from database...");
                while (voltageReader.Read()) //dopóki odczytujemy
                {
                    readData.Add(voltageReader["NetrunnerVoltage"].ToString());
                }
                Console.WriteLine("Done. And success. Clearing up...");
                test.Dispose();
                voltageReader.Dispose();
                mysqlDbConnection.Close();
                tempVoltage.voltage = Convert.ToDouble(readData[readData.Count - 1]); ///zapamiętać - ostatni element List<object>
                Console.WriteLine("Actual Voltage: " + tempVoltage.voltage);
                return tempVoltage;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to Netrunner Hub. Check connection and try again");
                        break;
                    case 1045:
                        Console.WriteLine("Wrong username/password supplied. Check correct password on http://alienwaren.github.io/NetrunnerCommunicator/");
                        break; 
                }

            }
            return new Voltage(0);
        }
        /// <summary>
        /// Przechowanie konfiguracji clienta do serwera sql
        /// </summary>
        private List<string> sqlClientConfiguration = new List<string>(5);
        /// <summary>
        /// Obiekt służący do komunikacji z bazą danych
        /// </summary>
        private MySqlConnection mysqlDbConnection;
        /// <summary>
        /// String do przechowujący zapytanie do bazy [SELECT FROM]
        /// </summary>
        private string sqlQuerySelect = "";
    }
}
