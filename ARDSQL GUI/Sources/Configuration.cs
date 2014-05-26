/*
 * Klasa wczytuje plik konfiguracyjny i ustawia parametry serwera.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace ARDSQL_GUI
{
    /// <summary>
    /// Klasa wczytuje konfigurację serwera
    /// </summary>
    /// <remarks>
    /// IPNTRNHB - ip Netrunner Hub'a.
    /// </remarks>
    class Configuration 
        : IDisposable
    {
        /// <summary>
        /// Konstruktor który pozwala na utworzenie obiektu StreamReader poprzez podanie mu nazwy pliku
        /// </summary>
        /// <param name="fileName">Nazwa pliku konfiguracyjnego</param>
        public Configuration(string fileName)
        {
            confReader = new StreamReader(fileName);
            loadConfFile();
            cleanAddr();
            clearSQL();
        }
        /// <summary>
        /// Ładowanie konfiguracji serwera z pliku
        /// </summary>
        /// <returns>Zwraca odczytane opcje konfiguracyjne</returns>
        private void loadConfFile()
        {
            Console.Write("Reading configuration file...");
            try
            {
                readLines.Add(confReader.ReadLine());
                if (readLines[0] == "START")
                {
                    while (readLines.Last() != "END")
                    {
                        readLines.Add(confReader.ReadLine());
                    }
                }else
                {
                    Console.WriteLine("Failed! Because: ");
                    throw new EmptyConfFileBeginningException("Beginning of conf file is empty or missing START");
                }
                Console.WriteLine("Success!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            confReader.Close(); // kasowanko confReadera
            displayLoadedConf();
            Console.Write("Starting processing of loaded configuration...");
            /*
             * 
             * Przetwarzamy konfigurację
             * 
             */
            processIp();
            processSQL();
        }
        /// <summary>
        /// Wyświetlenie odczytanej konfiguracji
        /// </summary>
        private void displayLoadedConf()
        {
            Console.WriteLine("Read Configuration: ");
            for(int i = 0; i < readLines.Count; i++)
            {
                Console.WriteLine(readLines[i]);
            }
        }
        /// <summary>
        /// Przetworzenie konfiguracji: IP
        /// </summary>
        /// <returns>Zwraca IP</returns>
        private void processIp()
        {
            String[] processTemp;
            Console.WriteLine("IP, ");
                for (int i = 0; i < readLines.Count; i++)
                {
                    if (readLines[i].Contains("IPNTRNHB:"))
                    {
                        processTemp = readLines.ElementAt(i).Split(':');
                        beforeCleanIp.Add(processTemp[1]); ///i dorzucamy adres ip do gotowej konfiguracji
                        break;
                    }
                }
                for (int i = 0; i < readLines.Count; i++)
                {
                    if (readLines[i].Contains("IPNTRNPC:"))
                    {
                        processTemp = readLines.ElementAt(i).Split(':');
                        beforeCleanIp.Add(processTemp[1]); /// a teraz IP Netrunnera
                        break;
                    }
                }
                Console.WriteLine("Done reading IP Configuration. ");
        }
        /// <summary>
        /// Przetworzenie konfiguracji serwera SQL
        /// </summary>
        private void processSQL()
        {
            String[] processedSQL;
            Console.WriteLine("SQL Configuration");
            for (int i = 0; i < readLines.Count; i++)
            {
                if (readLines[i].Contains("SQLSRV:"))
                {
                    processedSQL = readLines.ElementAt(i).Split(':');
                    beforeCleanSQL.Add(processedSQL[1]);
                    break;
                }
            }
            for (int i = 0; i < readLines.Count; i++)
            {
                if (readLines[i].Contains("SQLDBNM:"))
                {
                    processedSQL = readLines.ElementAt(i).Split(':');
                    beforeCleanSQL.Add(processedSQL[1]);
                    break;
                }
            }
            for (int i = 0; i < readLines.Count; i++)
            {
                if (readLines[i].Contains("USRNM:"))
                {
                    processedSQL = readLines.ElementAt(i).Split(':');
                    beforeCleanSQL.Add(processedSQL[1]);
                    break;
                }
            }
            for (int i = 0; i < readLines.Count; i++)
            {
                if (readLines[i].Contains("SQLTBNM:"))
                {
                    processedSQL = readLines.ElementAt(i).Split(':');
                    beforeCleanSQL.Add(processedSQL[1]);
                    break;
                }
            }
            Console.WriteLine("Done processing SQL Configuration");
        }
        /// <summary>
        /// Wyczyszczenie adresów z białych znaków
        /// </summary>
        /// <returns>Zwraca gotowy adres</returns>
        private void cleanAddr()
        {
            List <string> ips = new List<string>();
            ips = this.beforeCleanIp;
            for(int i = 0; i < ips.Count; i++)
            {
                if(ips[i].Contains(' '))
                {
                    ips[i] = ips[i].Substring(1, ips[i].Length - 1); //ZAPAMIĘTAĆ!!!
                }
                readyIps.Add(ips[i]);

            }
            
        }
        /// <summary>
        /// Czyszczonko ze śmieci konfiguracja SQL'a
        /// </summary>
        private void clearSQL()
        {
            List<string> sqls = new List<string>();
            sqls = this.beforeCleanSQL;
            for (int i = 0; i < sqls.Count; i++)
            {
                if(sqls[i].Contains(' '))
                {
                    sqls[i] = sqls[i].Substring(1, sqls[i].Length - 1);
                }
                readySQL.Add(sqls[i]);
            }
            
        }
        /// <summary>
        /// Lista gotowych juz adresów IP dla serwera
        /// </summary>
        private List<String> readyIps = new List<String>();
        /// <summary>
        /// Gotowa konfiguracja serwera SQL
        /// </summary>
        private List<String> readySQL = new List<String>(3);
        /// <summary>
        /// "Odczytywacz danych" z pliku konfiguracyjnego
        /// </summary>
        private StreamReader confReader;
        /// <summary>
        /// Odczytane dane jako lista.
        /// </summary>
        private List<string> readLines = new List<string>(1);
        /// <summary>
        /// Gotowa konfiguracja
        /// </summary>
        private List<string> beforeCleanIp = new List<string>();
        /// <summary>
        /// Konfuguracja przed czyszczeniem
        /// </summary>
        private List<string> beforeCleanSQL = new List<string>();
        /// <summary>
        /// Zwróci konfiguracje
        /// </summary>
        /// <returns>Zwraca konfigurację w postaci listy</returns>
        public List<String> getConfigurationIp()
        {
            return readyIps;
        }
        /// <summary>
        /// Zwrócenie konfiguracji serwera sql
        /// </summary>
        /// <returns>Zwraca gotową już konfiguracje</returns>
        public List<String> getSQLServerConfiguration()
        {
            return readySQL;
        }
        /// <summary>
        /// Metoda do zwolnienia pamięci zajętej przez tą klasę
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Przeciążenie które zostanie wywołane poprzez publiczną metodę
        /// Usuwa obiekt z pamięci
        /// </summary>
        /// <param name="disposing">Parametr oznaczający czy obiekt jest właśnie usuwany</param>
        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Clearing configuration class... ");
            if (disposing == true)
            {
                beforeCleanIp.Clear();
                beforeCleanSQL.Clear();
                this.readLines.Clear();
                this.readyIps.Clear();
                this.readySQL.Clear();
            }
            else
            {
                this.confReader.Dispose();
            }
        }
        /// <summary>
        /// Finalizer zwalniający niezarządzalne zasoby
        /// </summary>
        ~Configuration()
        {
            Dispose(false);
        }
    }
    /// <summary>
    /// "Wyjątek" pustego początku pliku.
    /// </summary>
    [global::System.Serializable]
    public class EmptyConfFileBeginningException  : Exception
    {
        public EmptyConfFileBeginningException() 
        { 
        }
        public EmptyConfFileBeginningException(string message) : base(message) 
        {
            
        }
        public EmptyConfFileBeginningException(string message, Exception inner) : base(message, inner) 
        { 
        }
        protected EmptyConfFileBeginningException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
    /// <summary>
    /// Sygnalizacja że składnia pliku konfiguracyjnego jest nieprawidłowa
    /// </summary>
    [global::System.Serializable]
    public class InvalidConfSyntaxException : Exception
    {
        public InvalidConfSyntaxException() { }
        public InvalidConfSyntaxException( string message ) : base( message ) { }
        public InvalidConfSyntaxException( string message, Exception inner ) : base( message, inner ) { }
        protected InvalidConfSyntaxException( 
	    System.Runtime.Serialization.SerializationInfo info, 
	    System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
    }
}
