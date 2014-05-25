using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
namespace ARDSQL_GUI
{
    /// <summary>
    /// Klasa implementuje komunikaty
    /// </summary>
    class MsgBox
    {
        /// <summary>
        /// Konskturktor tworzący okno
        /// </summary>
        public MsgBox(uint msgBoxWidth, uint msgBoxHeight, string msgBoxTitle)
        {
            this.msgBoxTitle = msgBoxTitle;
            msgBoxVideoMode = new VideoMode(msgBoxWidth, msgBoxHeight); //ustawienie trybu wideo
            msgBoxWindow = new RenderWindow(msgBoxVideoMode, msgBoxTitle, Styles.Close); //ustawienie parametrów okna
        }
        /// <summary>
        /// Wyświetlenie okna
        /// </summary>
        public virtual void display()
        {
            this.msgBoxWindow.Clear(Color.Black);
            this.msgBoxWindow.Display();
        }
        /// <summary>
        /// Metoda wirtualna do wyświetlania elementów okna.
        /// </summary>
        public virtual void draw()
        {
        }
        /// <summary>
        /// Okno renderu służące do wyświetlenia elementów okna.
        /// </summary>
        private RenderWindow msgBoxWindow;
        /// <summary>
        /// Informacje o wielkości okna
        /// </summary>
        private VideoMode msgBoxVideoMode;
        /// <summary>
        /// Tytuł okna
        /// </summary>
        private string msgBoxTitle = " ";
    }
}
