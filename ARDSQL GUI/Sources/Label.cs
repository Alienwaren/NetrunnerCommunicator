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
    /// Klasa implementuje podpisy dla różnych obiektów
    /// </summary>
    class Label
    {
        /// <summary>
        /// Konstruktor....
        /// </summary>
        public Label(String labelText, Vector2f initialPosition)
        {
            this.labelText = new Text(labelText, labelFont);
            labelTextString = labelText;
            this.labelPosition = initialPosition;
            initAttrib();
        }
        /// <summary>
        /// Inicjacja atrybutów tekstu
        /// </summary>
        private void initAttrib()
        {
            this.labelText.CharacterSize = 20;
            this.labelText.Color = new Color(Color.White);
        }
        /// <summary>
        /// Tekst podpisu
        /// </summary>
        private Text labelText;
        /// <summary>
        /// Czcionka podpisu
        /// </summary>
        private Font labelFont = new Font("Resources/lucon.ttf");
        /// <summary>
        /// Treść podpisu
        /// </summary>
        private String labelTextString = " ";
        /// <summary>
        /// Aktualizacja atrybutów
        /// </summary>
        void update()
        {
            this.labelText.DisplayedString = labelTextString;
        }
        /// <summary>
        /// Geter i seter dla tekstu
        /// </summary>
        public String text
        {
            get
            {
                return labelTextString;
            }
            set
            {
                labelTextString = value;
            }
        }
        /// <summary>
        /// Pozycja podpisu
        /// </summary>
        private Vector2f labelPosition;
        /// <summary>
        /// Geter i seter
        /// </summary>
        public Vector2f position
        {
            get
            {
                return labelPosition;
            }
            set
            {
                labelPosition = value;
            }
        }
        /// <summary>
        /// Rysowanko
        /// </summary>
        /// <param name="windowToBeDrawed">Okno w którym narysujemy tekst</param>
        public virtual void draw(RenderWindow windowToBeDrawed)
        {
            windowToBeDrawed.Draw(labelText);
        }
    }
}
