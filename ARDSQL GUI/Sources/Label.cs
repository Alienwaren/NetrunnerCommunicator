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
        /// Konstruktor....
        /// </summary>
        public Label(Vector2f initialPosition)
        {
            this.labelPosition = initialPosition;
            initAttrib();
        }
        /// <summary>
        /// Inicjacja atrybutów tekstu
        /// </summary>
        private void initAttrib()
        {
            if (labelTextString == " ")
            {
                labelText = new Text("EMPTY! CORRECT THAT", labelFont);
            }
            this.labelText.CharacterSize = 20;
            this.labelText.Color = new Color(Color.White);
            this.labelText.Position = new Vector2f(labelPosition.X - 20, labelPosition.Y - 30);
        }
        /// <summary>
        /// Podpięcie tekstury do sprajta
        /// </summary>
        /// <param name="labelTexture">Tesktura do ustawienia</param>
        /// <param name="spriteRectangle">Skrawek z tekstury</param>
        public void createSpriteAndSetPosition(Texture labelTexture, IntRect spriteRectangle)
        {
            this.labelSprite = new Sprite(labelTexture, spriteRectangle);
            this.labelSprite.Position = labelPosition;
        }
        /// <summary>
        /// Duszek podpisu 
        /// </summary>
        /// <seealso cref="LabelTexture.cs"/>
        private Sprite labelSprite;
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
        public void update()
        {
            this.labelSprite.Origin = new Vector2f(labelSprite.GetGlobalBounds().Width / 2, labelSprite.GetGlobalBounds().Height / 2);
            this.labelText.DisplayedString = labelTextString;
            this.labelSprite.Scale = new Vector2f(this.labelScale, this.labelScale);
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
            windowToBeDrawed.Draw(this.labelSprite);
        }
        /// <summary>
        /// Skala naszego podpisu statusu
        /// </summary>
        private float labelScale = 1;
        /// <summary>
        /// Geter i seter dla skali
        /// </summary>
        public float scale
        {
            get
            {
                return labelScale;
            }
            set
            {
                labelScale = value;
            }
        }
    }
}
