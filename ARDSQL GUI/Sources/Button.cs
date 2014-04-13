/*
 * 
 * 
 *  TODO: Przerobić klasę. Ma być zbiorcza tj. chcę guzik to dziedziczę z tej klasy mając do dyspozycji gotową teksture, a dopiero potem tworzę
 *  sprity w klasach pochodnych. Pole ma zawierać całą teksturę, sprajt bez koordynat tekstury. Do tego getery i setery (ew. właściwość). Oraz puste koordynaty tekstury
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
namespace ARDSQL_GUI
{
    /// <summary>
    /// klasa implementująca UI - guzik
    /// </summary>
    class Button
    {
            /// <summary>
            /// Konstruktor domyślny
            /// </summary>
            protected Button()
            {
                if (this.loadTexture())
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failed!");
                }
            }
            /// <summary>
            /// Tekstura guzików. 
            /// </summary>
            protected Texture buttonTextures;
            /// <summary>
            /// Ładowanie tekstury guzików
            /// </summary>
            /// <returns></returns>
            private Boolean loadTexture()
            {
                try
                {
                    Console.Write("Loading buttons texture...");
                    buttonTextures = new Texture("../../Resources/Graphics/buttons_texture.png");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
     
            }
            /// <summary>
            /// Ustawienie atrybutów guzika i podpisu
            /// </summary>
            virtual protected void setAttributes(Vector2f initialButtonPosition, String buttonName)
            {
           
                this.buttonSprite.Origin = new Vector2f(this.buttonSprite.GetGlobalBounds().Width / 2, this.buttonSprite.GetGlobalBounds().Height / 2); /// WOW.      
                buttonLabel = new Text(buttonName, this.buttonLabelFont);
                buttonLabelPosition = new Vector2f(100, 100);
                buttonLabel.CharacterSize = 15;
            
            }
            /// <summary>
            /// Pozycja guzika
            /// </summary>
            protected Vector2f buttonPosition = new Vector2f();
            /// <summary>
            /// Sprite guzika
            /// </summary>
            protected Sprite buttonSprite = new Sprite();
            /// <summary>
            /// Ustawienie tekstury do sprite
            /// </summary>
            virtual protected void setTexture()
            {
                ///nothing here....
            }
            /// <summary>
            /// Zwrócenie sprajta
            /// </summary>
            public Sprite getSprite()
            {
                return buttonSprite;
            }
            /// <summary>
            /// Skrawek tekstury do obrazka
            /// </summary>
            protected IntRect spriteRect = new IntRect();
            /// <summary>
            /// Rysowanie guzika
            /// </summary>
            /// <param name="drawingWindow">Okno rysowania guzika</param>
            public void draw(RenderWindow drawingWindow)
            {
                drawingWindow.Draw(buttonSprite);
                drawingWindow.Draw(buttonLabel);
            }
            /// <summary>
            /// Treść podpisu guzika
            /// </summary>
            protected Text buttonLabel;
            /// <summary>
            /// Plik czcionki
            /// </summary>
            protected Font buttonLabelFont = new Font("lucon.ttf");
            /// <summary>
            /// String z treścią guzika
            /// </summary>
            protected String buttonLabelText = null;
            /// <summary>
            /// Pozycja podpisu guzika
            /// </summary>
            protected Vector2f buttonLabelPosition = new Vector2f(100,100);
            /// <summary>
            /// Zdarzenie na kliknięcie
            /// </summary>
            /// <param name="windowToBeClosed">Okno które ma być zamknięte</param>
            virtual public void onClick(RenderWindow windowToBeClosed)
            {
                Console.WriteLine(windowToBeClosed.ToString());
            
            }
        /// <summary>
        /// Przeciążenie zdarzenia na kliknięcie
        /// </summary>
        /// <param name="serverReceiver">Obiekt serwera obierającego dane od Netrunner'a</param>
        /// <param name="maxConnections">Port na którym serwer bedzie stać</param>
            virtual public void onClick(TemperatureReceiver serverReceiver, int maxConnections)
            {
                Console.WriteLine(serverReceiver.ToString() + "{0}", maxConnections);
            }
        }
    }













