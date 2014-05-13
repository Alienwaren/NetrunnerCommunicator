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
        private String actualLabelString = "";
        /// <summary>
        /// Label po zmianie
        /// </summary>
        private String changedLabel = "";
        /// <summary>
        /// Ten co przed zmianą
        /// </summary>
        private String standardLabel = "";
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
            this.actualLabelString = initialLabel;
            this.standardLabel = initialLabel;
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
        public void update(bool isServerWorking)
        {
            base.update();
            this.statusBarLabel.DisplayedString = actualLabelString;
            this.changeColor(isServerWorking);
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
        /// Zmiana koloru status Bara
        /// </summary>
        private void changeColor(bool isServerWorking)
        {
            if (isServerWorking)
            {
                base.barColor = this.changedColorAfterClick;
                this.actualLabelString = changedLabel;
            }
            if (!isServerWorking)
            {
                base.barColor = this.normalColor;
                this.actualLabelString = standardLabel;
            }
        }
    }
}
