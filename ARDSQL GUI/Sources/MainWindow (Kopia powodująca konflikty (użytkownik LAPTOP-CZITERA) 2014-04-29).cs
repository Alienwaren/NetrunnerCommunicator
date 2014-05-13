using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
namespace ARDSQL_GUI
{
    /// <summary>
    /// Główna klasa to tu cała magia się odbywa
    /// </summary>
    class MainWindow
    {
        /// <summary>
        /// Wyświetlenie okna
        /// </summary>
        public void displayWindow()
        {
            window1.Display();
        }
        /// <summary>
        /// Przeciazenie do displayWindow(). Pozwala na wybranie koloru wyświetlania
        /// </summary>
        /// <param name="clearColor">Kolor.</param>
        public void displayWindow(Color clearColor)
        {
            
            window1.Clear(clearColor);
            minTemp.drawAll(window1);
            avgTemp.drawAll(window1);
            maxTemp.drawAll(window1);
            connection1.draw(window1);
            exit1.draw(window1);
            statusBar.draw(window1);
            window1.Display();
        }

        /// <summary>
        /// Petla wyświetlania
        /// </summary>
        private void displayLoop()
        {
            window1.SetFramerateLimit(60);
            initEvents();
            while (window1.IsOpen())
            {
                update();
                window1.DispatchEvents();
                displayWindow(new Color(Color.Black));
            }
        }
        /// <summary>
        /// Uruchomienie aplikacji
        /// </summary>
        public void run()
        {
            displayLoop();
        }
        /// <summary>
        /// Inicjacja zdarzen
        /// </summary>
        private void initEvents()
        {
            window1.Closed += new EventHandler(closeWindow);
            window1.MouseMoved += mouseMoved;
            window1.MouseButtonPressed += buttonPressed;
        }

        /// <summary>
        /// Akcja pozwalająca na zareagowanie na kliknięcie myszy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttonPressed(object sender, MouseButtonEventArgs e)
        {
            if(windowMouse.checkForMouseCollision(exit1.getSprite(), window1))
            {
                exit1.onClick(window1);
            }
            if (windowMouse.checkForMouseCollision(connection1.getSprite(), window1))
            {
                this.isWorking = true;
                connection1.onClick(receiver, 2);
                
            }
        }
        /// <summary>
        /// Pobranie zdarzenia zamknięcia okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void closeWindow(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window1.Close();
        }
        /// <summary>
        /// Zdarzenie ruchu myszy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mouseMoved(object sender, EventArgs e)
        {
            windowMouse.getMousePosition(window1);   
        }
        /// <summary>
        /// Funkcja update służy do aktualizacji okna programu
        /// </summary>
        private void update()
        {
            minTemp.updateTemperatureString();
            maxTemp.updateTemperatureString();
            avgTemp.updateTemperatureString();
            statusBar.update(isWorking);
        }
        /// <summary>
        /// Czy program jest zajęty
        /// </summary>
        private bool isWorking = false;
        /// <summary>
        /// Property do ustawienia czy program jest zajęty
        /// </summary>
        public bool working
        {
            get
            {
                return isWorking;
            }
            set
            {
                isWorking = value;
            }
        }
        /// <summary>
        /// Obiekt reprezentujący okno programu
        /// </summary>
        RenderWindow window1 = new RenderWindow(new VideoMode(800, 600), "Netrunner Hub Control Center");
        /// <summary>
        /// Obiekt typu temperature reprzentujący temperature - temp srednia
        /// </summary>
        Temperature avgTemp = new Temperature(new Vector2f(0,50), "AvgTemp");
        /// <summary>
        /// Reprezentacja najmniejszej temperatury
        /// </summary>
        Temperature minTemp = new Temperature(new Vector2f(80, 50), "MinTemp");
        /// <summary>
        /// Reprezentacja największej temperatury
        /// </summary>
        Temperature maxTemp = new Temperature(new Vector2f(160, 50), "MaxTemp");
        /// <summary>
        /// Mysz programu
        /// </summary>
        CMouse windowMouse = new CMouse();
        /// <summary>
        /// Guzik wyjscia
        /// </summary>
        ExitButton exit1 = new ExitButton(new Vector2f(40,195), "Exit");
        /// <summary>
        /// Guzik pobrania danych od klienta
        /// </summary>
        ConnButton connection1 = new ConnButton(new Vector2f(120, 195), "Connect");
        /// <summary>
        /// Obiekt serwera danych
        /// </summary>
        TemperatureReceiver receiver = new TemperatureReceiver(134, "192.168.1.6", "192.168.1.5");
        /// <summary>s
        /// Pasek statusu
        /// </summary>
        StatusBar statusBar = new StatusBar(new Color(Color.Green), new Vector2f(0, 0), new Vector2f(800,50), "Ready to work", "Working...", new Color(Color.Red));
    }
}
