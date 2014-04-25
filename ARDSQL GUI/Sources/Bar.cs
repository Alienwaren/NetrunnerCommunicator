using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
/*
 * Założenia klasy:
 * -> Ma być to klasa bazowa pod wszystkie banerki, progress bary etc...
 * -> Metody: setColor, setAttributes, createBar, etc..
 * -> Pola: rozmiar, kolor, etc...
 * 
 * 
 * 
 */
namespace ARDSQL_GUI
{
    /// <summary>
    /// Klasa implementuje progresbary itd.
    /// </summary>
    class Bar
    {
        /// <summary>
        /// Konstruktor 
        /// </summary>
        /// <param name="colorToBeSet">Kolor startowy</param>
        /// <param name="startingPosition">Pozycja startowa</param>
        /// <param name="startingSize">Startowy Rozmiar</param>
        public Bar(Color colorToBeSet, Vector2f startingPosition, Vector2f startingSize)
        {
            initAttributes(colorToBeSet, startingPosition, startingSize);
        }
        /// <summary>
        /// Inicjacja atrybutów
        /// </summary>
        /// <param name="colorToBeSet">Color startowy</param>
        /// <param name="startingPosition">Pozycja startowa</param>
        /// <param name="startingSize">Startowy Rozmiar</param>
        protected void initAttributes(Color colorToBeSet, Vector2f startingPosition, Vector2f startingSize)
        {
            this.barPosition = startingPosition; ///pozycja
            this.barColor = colorToBeSet; ///kolor
            this.barSize = startingSize; ///rozmiar
            this.barRectangle.FillColor = barColor;
            this.barRectangle.Position = barPosition;
            this.barRectangle.Size = barSize;
             
        }
        /// <summary>
        /// Pole przechowujące kolor
        /// </summary>
        protected Color barColor = new Color();
        /// <summary>
        /// Getter i seter dla koloru
        /// </summary>
        public Color color
        {
            get
            {
                return barColor;
            }
            set
            {
                barColor = new Color(value);
            }
        }
        /// <summary>
        /// Rozmiar bara
        /// </summary>
        protected Vector2f barSize = new Vector2f();
        /// <summary>
        /// Property do ustawienia rozmiaru bara
        /// </summary>
        public Vector2f size
        {
            get
            {
                return barSize;
            }
            set
            {
                barSize.X = value.X;
                barSize.Y = value.Y;
                this.barRectangle.Size = barSize;
            }
        }
        /// <summary>
        /// Pozycja bara
        /// </summary>
        protected Vector2f barPosition = new Vector2f();
        /// <summary>
        /// Pozycja bara.
        /// </summary>
        public Vector2f position
        {
            get
            {
                return barPosition;
            }
            set
            {

                barPosition.X = value.X;
                barPosition.Y = value.Y;
                this.barRectangle.Position = barPosition;
            }
        }
        /// <summary>
        /// Rectangle shape bara
        /// </summary>
        protected RectangleShape barRectangle = new RectangleShape();
        /// <summary>
        /// Malujemy! :D
        /// </summary>
        /// <param name="renderWindow">Okno renderu gdzie to narysujemy</param>
        virtual public void draw(RenderWindow renderWindow)
        {
            renderWindow.Draw(barRectangle);
        }
        /// <summary>
        /// I aktualizujemy :P
        /// </summary>
        public virtual void update()
        {
            this.barRectangle.FillColor = barColor;
            this.barRectangle.Position = barPosition;
            this.barRectangle.Size = barSize;
        }
        /// <summary>
        /// Zdarzenie na kliknięcie
        /// </summary>
        public virtual void onClick()
        {
            Console.WriteLine("Clicked on status bar!");
        }
        /// <summary>
        /// Zwracamy nasz kształt
        /// </summary>
        /// <returns>Zwracamy kształt</returns>
        public RectangleShape getShape()
        {
            return this.barRectangle;
        }
    }
}
