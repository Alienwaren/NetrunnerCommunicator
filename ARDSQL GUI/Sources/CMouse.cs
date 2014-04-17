using System;
using SFML.Window;
using SFML.Graphics;
namespace ARDSQL_GUI
{
    /// <summary>
    /// Klasa implementuje obsługę myszy
    /// </summary>
    class CMouse
    {
        public CMouse()
        {
        }
        /// <summary>
        /// Pozycja myszy
        /// </summary>
        private Vector2i mousePosition;
        /// <summary>
        /// Pobranie pozycji myszy
        /// </summary>
        /// <param name="mouseWindow">Okno w którym mysz się znajduje</param>
        public void getMousePosition(RenderWindow mouseWindow)
        {
            mousePosition = new Vector2i();
            mousePosition = Mouse.GetPosition(mouseWindow);
            Console.Write(mousePosition + "\r");
        }
        
        /// <summary>
        /// Sprawdzenie czy wystapila kolizja z guzikiem
        /// </summary>
        /// <param name="av_Sprite">Obiekt do sprawdzenia</param>
        /// <param name="av_Window">Okno renderu</param>
        /// <returns>Zwraca czy kolizja nastąpiła</returns>
        public Boolean checkForMouseCollision(Sprite av_Sprite, RenderWindow av_Window)
        {
            FloatRect tempRect = av_Sprite.GetGlobalBounds();
            if(tempRect.Contains(this.mousePosition.X, this.mousePosition.Y))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}