using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARDSQL_GUI
{
    /// <summary>
    /// Klasa reprezentuje napięcie elektryczne.
    /// </summary>
    class Voltage
    {
        /// <summary>
        /// Konstruktor pozwalajacy na ustawienie wartości początkowej napięcia
        /// </summary>
        /// <param name="voltageValue">Wartość napięcia</param>
        public Voltage(double voltageValue)
        {
            voltageAmount = voltageValue;
        }
        /// <summary>
        /// Konstruktor pozwalajacy na ustawienie wartości początkowej napięcia
        /// </summary>
        /// <param name="voltageValue">Wartość napięcia</param>
        public Voltage(float voltageValue)
        {
            voltageAmount = (double)voltageValue;
        }
        /// <summary>
        /// Konstruktor pozwalajacy na ustawienie wartości początkowej napięcia
        /// </summary>
        /// <param name="voltageValue">Wartość napięcia</param>
        /// <remarks>Try to use precise one...</remarks>
        public Voltage(int voltageValue)
        {
            voltageAmount = (double)voltageValue;
        }
        /// <summary>
        /// Wartość napięcia
        /// </summary>
        private double voltageAmount = 0.0F;
        /// <summary>
        /// Przeciążony operator dodawania
        /// </summary>
        /// <param name="leftSide">Lewa strona równania</param>
        /// <param name="rightSide">Prawa strona równania</param>
        /// <returns>Zwracamy wynik</returns>
        public static Voltage operator +(Voltage leftSide, Voltage rightSide)
        {
            return new Voltage(leftSide.voltageAmount + rightSide.voltageAmount);
        }
        /// <summary>
        /// Przeciążony operator odejmowania
        /// </summary>
        /// <param name="leftSide">Lewa strona równania</param>
        /// <param name="rightSide">Prawa strona równania</param>
        /// <returns>Zwracamy wynik</returns>
        public static Voltage operator -(Voltage leftSide, Voltage rightSide)
        {
            return new Voltage(leftSide.voltageAmount - rightSide.voltageAmount);
        }
        /// <summary>
        /// Przeciążony operator mnożenia
        /// </summary>
        /// <param name="leftSide">Lewa strona równania</param>
        /// <param name="rightSide">Prawa strona równania</param>
        /// <returns>Zwracamy wynik</returns>
        public static Voltage operator *(Voltage leftSide, Voltage rightSide)
        {
            return new Voltage(leftSide.voltageAmount * rightSide.voltageAmount);
        }
        /// <summary>
        /// Przeciążony operator dzielenia
        /// </summary>
        /// <param name="leftSide">Lewa strona równania</param>
        /// <param name="rightSide">Prawa strona równania</param>
        /// <returns>Zwracamy wynik</returns>
        public static Voltage operator /(Voltage leftSide, Voltage rightSide)
        {
            return new Voltage(leftSide.voltageAmount / rightSide.voltageAmount);
        }
        /// <summary>
        /// Przeciążony operator mnożenia
        /// </summary>
        /// <param name="leftSide">Lewa strona równania</param>
        /// <param name="rightSide">Prawa strona równania</param>
        /// <returns>Zwraca wynik</returns>
        public static Voltage operator %(Voltage leftSide, Voltage rightSide)
        {
            return new Voltage(leftSide.voltageAmount % rightSide.voltageAmount);
        }
    }
}
