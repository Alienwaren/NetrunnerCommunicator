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
        }
        /// <summary>
        /// Ładowanie konfiguracji serwera z pliku
        /// </summary>
        /// <returns>Zwraca odczytane opcje konfiguracyjne</returns>
        private String loadConfFile()
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
            confReader.Dispose(); // kasowanko confReadera
            displayLoadedConf();
            Console.Write("Starting processing of loaded configuration...");
            processIp();
            return "";
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
            Console.Write("IP");
                for (int i = 0; i < readLines.Count; i++)
                {
                    if (readLines[i].Contains("IPNTRNHB:"))
                    {
                        processTemp = readLines.ElementAt(i).Split(':');
                        beforeClean.Add(processTemp[1]); ///i dorzucamy adres ip do gotowej konfiguracji
                        break;
                    }
                }
                for (int i = 0; i < readLines.Count; i++)
                {
                    if (readLines[i].Contains("IPNTRN:"))
                    {
                        processTemp = readLines.ElementAt(i).Split(':');
                        beforeClean.Add(processTemp[1]); /// a teraz IP Netrunnera
                        break;
                    }
                }
        }
        /// <summary>
        /// Wyczyszczenie adresów z białych znaków
        /// </summary>
        /// <returns>Zwraca gotowy adres</returns>
        private void cleanAddr()
        {
            List <string> ips = new List<string>();
            ips = this.beforeClean;
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
        /// Lista gotowych juz adresów IP dla serwera
        /// </summary>
        private List<String> readyIps = new List<String>();
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
        private List<string> beforeClean = new List<string>();
        /// <summary>
        /// Zwróci konfiguracje
        /// </summary>
        /// <returns>Zwraca konfigurację w postaci listy</returns>
        public List<String> getConfiguration()
        {
            return readyIps;
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
