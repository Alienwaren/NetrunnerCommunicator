using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
namespace ARDSQL_GUI
{
    class StatusBar
        : Bar
    {
        /// <summary>
        /// Konstruktor inicjujący pasek dostępu
        /// </summary>
        /// <param name="colorToBeSet">Kolorek paska</param>
        /// <param name="startingPosition">I jego pozycja</param>
        /// <param name="startingSize">Oraz jego rozmiar</param>
        /// <param name="changedColor">Kolor do zmiany</param>
        /// <param name="initialLabel">Początkowy podpis</param>
        /// <param name="labelAfterChange">Podpis po zmianie</param>
        public StatusBar(Color colorToBeSet, Vector2f startingPosition, Vector2f startingSize, String initialLabel, String labelAfterChange, Color changedColor)
            : base(colorToBeSet, startingPosition, startingSize)
        {
            initAttributes(colorToBeSet, startingPosition, startingSize, initialLabel, labelAfterChange, changedColor);
        }
        private Color normalColor = new Color();
        /// <summary>
        /// Kolor ktory sie zmieni po kliknięciu
        /// </summary>
        private Color changedColorAfterClick = new Color();
        /// <summary>
        /// Tekst napisu paska postępowego
        /// </summary>
        private Text statusBarLabel = new Text();
        /// <summary>
        /// Czcionka
        /// </summary>
        private Font labelFont = new Font("lucon.ttf");
        /// <summary>
        /// String przechowujący treść podpisu
        /// </summary>
        private String labelString = "";
        /// <summary>
        /// Label po zmianie
        /// </summary>
        private String changedLabel = "";
        /// <summary>
        /// Inicjacja atrybutów paska
        /// </summary>
        /// <param name="colorToBeSet">Kolorek paska</param>
        /// <param name="startingPosition">I jego pozycja</param>
        /// <param name="startingSize">Oraz jego rozmiar</param>
        /// <param name="changedColor">Kolor do zmiany</param>
        /// <param name="initialLabel">Początkowy podpis</param>
        /// <param name="labelAfterChange">Podpis po zmianie</param>
        private void initAttributes(Color colorToBeSet, Vector2f startingPosition, Vector2f startingSize, String initialLabel, String labelAfterChange, Color changedColor)
        {
            base.initAttributes(colorToBeSet, startingPosition, startingSize);
            normalColor = colorToBeSet;
            this.changedColorAfterClick = changedColor;
            this.labelString = initialLabel;
            this.changedLabel = labelAfterChange;
            this.statusBarLabel.Font = this.labelFont;
            this.statusBarLabel.Color = new Color(Color.Black);
            this.statusBarLabel.CharacterSize = 20;
            this.statusBarLabel.DisplayedString = initialLabel;
            this.statusBarLabel.Position = new Vector2f(this.barRectangle.GetGlobalBounds().Width / 2, this.barRectangle.GetGlobalBounds().Height / 2);
            statusBarLabel.Origin = new Vector2f(this.statusBarLabel.GetGlobalBounds().Width / 2, this.statusBarLabel.GetGlobalBounds().Height / 2);
        }
        /// <summary>
        /// Updejt status bara.
        /// </summary>
        public override void update()
        {
            base.update();
            this.statusBarLabel.DisplayedString = labelString;
        }
        /// <summary>
        /// Malujemy! :D
        /// </summary>
        /// <param name="renderWindow">Okno renderu gdzie to narysujemy</param>
        public override void draw(RenderWindow renderWindow)
        {
            base.draw(renderWindow);
            renderWindow.Draw(statusBarLabel);
        }
        /// <summary>
        /// Ilość kliknięć
        /// </summary>
        private int amountOfClicks = 0;
        /// <summary>
        /// Zmiana koloru status Bara
        /// </summary>
        private void changeColor()
        {
            //if (base.barRectangle.FillColor.Equals(new Color(Color.Green)))
            //{
            //    Console.WriteLine("Changing status color to: {0}", Color.Red.ToString());
            //    base.barRectangle.FillColor = this.changedColorAfterClick;
            //}
            //else
            //{
            //    Console.WriteLine("Changing status color to: {0}", Color.Green.ToString());
            //}
            if (amountOfClicks == 0)
            {
                
                    Console.WriteLine("Changing status color to: {0}", Color.Red.ToString());
                    base.barColor = this.changedColorAfterClick;
                
                amountOfClicks++;
                return;
            }
            if (amountOfClicks == 1)
            {
                
                    Console.WriteLine("Changing status color to: {0}", Color.Green.ToString());
                    base.barColor = this.normalColor;

                amountOfClicks = 0;
                return;
            }
        }
        /// <summary>
        /// Przeciążnienie do onClick()
        /// </summary>
        public override void onClick()
        {
            base.onClick();
            this.changeColor();
        }
    }
}
