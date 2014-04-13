using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
namespace ARDSQL_GUI
{
    class Temperature
    {
        /// <summary>
        /// Konstruktor domyślny
        /// </summary>
        public Temperature()
        {
            temperatureTextPosition = new Vector2f(0,0);
            setAttributesTemp();
        }
        /// <summary>
        /// Konsturktor przeciążony ustawiający pozycję tekstu
        /// </summary>
        /// <param name="positionOfText">Współrzędne na ekranie</param>
        public Temperature(Vector2f positionOfText, String textString)
        {
            temperatureTextPosition = new Vector2f(positionOfText.X, positionOfText.Y);
            labelTextPosition = new Vector2f(positionOfText.X, positionOfText.Y + 40);
            setAttributesTemp();
            setLabelAttributes(textString);
        }
        /// <summary>
        /// Ustawenie parametrów tekstu
        /// </summary>
        public void setAttributesTemp()
        {

            temperatureText = new Text(temperatureValue.ToString(), temperatureFont);
            temperatureText.Color = new Color(Color.White);
            temperatureText.CharacterSize = 30;
            temperatureText.Position = temperatureTextPosition;

        }
        /// <summary>
        /// Metoda ustawiająca atrybuty podpisu temperatury
        /// </summary>
        /// <param name="textString">Tekst do ustawienia</param>
        public void setLabelAttributes(String textString)
        {
            labelText = new Text(textString, temperatureFont);
            labelText.Color = new Color(Color.White);
            labelText.CharacterSize = 15;
            labelText.Position = labelTextPosition;
        }
        /// <summary>
        /// Aktualizacja temperatury
        /// </summary>
        public void updateTemperatureString()
        {
            temperatureText.DisplayedString = temperatureValue.ToString();
        }
        /// <summary>
        /// Tekstowa reprezentacja temperatury
        /// </summary>
        public Text temperatureText;
        /// <summary>
        /// Czcionka temperatury
        /// </summary>
        private Font temperatureFont = new Font("lucon.ttf");
        /// <summary>
        /// Wartosc temperatury aktualnej
        /// </summary>
        private float temperatureValue = 0;
        /// <summary>
        /// Własciwosc pozwalająca na ustawienie wartosci temperatureValue
        /// </summary>
        public float temperature
        {
            get
            {
                return temperatureValue;
            }
            set
            {
                temperatureValue = value;
            }
        }
        /// <summary>
        /// Pozycja tekstu temperatury.
        /// </summary>
        private Vector2f temperatureTextPosition;
        /// <summary>
        /// Właściwość która pozwoli na dobranie sie do temperatureTextPosition
        /// </summary>
        public Vector2f temperaturePosition
        {
            get
            {
                return temperatureTextPosition;
            }
            set
            {
                temperatureTextPosition.X = value.X;
                temperatureTextPosition.Y = value.Y;
            }
        }
        /// <summary>
        /// Podpis temperatury
        /// </summary>
        public Text labelText;
        /// <summary>
        /// Pozycja tekstu podpisu temperatury
        /// </summary>
        private Vector2f labelTextPosition;
        /// <summary>
        /// Właściwość która pozwala dobrać się do tekstu
        /// </summary>
        public Vector2f labelPosition
        {
            get
            {
                return labelTextPosition;
            }
            set
            {
                labelTextPosition.X = value.X;
                labelTextPosition.Y = value.Y;
            }
        }
        /// <summary>
        /// Wyświetlenie tekstu
        /// </summary>
        /// <param name="windowTarget">Okno w którym wyświetlony zostanie tekst</param>
        public void drawAll(RenderWindow windowTarget)
        {
            windowTarget.Draw(labelText);
            windowTarget.Draw(temperatureText);
        }
    }
}












