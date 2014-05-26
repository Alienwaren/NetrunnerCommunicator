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
      //  : IDisposable
    {
        
        /// <summary>
        /// Konskturktor tworzący komunikat i ustawienie czy bedą sprite czy nie
        /// </summary>
        public MsgBox(string msgText, bool willHaveSprite)
        {
            presentTexture = willHaveSprite;
            this.msgTextString = msgText;
            try
            {
                /*
                 * tworzymy napis
                 * */
                this.msgTextFont = new Font("Resources/lucon.ttf");
                this.msgTextObj = new Text(msgText, msgTextFont);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            if (presentTexture)
            {
                try
                {
                    msgTextures = new Texture("../../Resources/Graphics/clairTexture.png");
                    msgSprite = new Sprite(msgTextures);
                    msgSprite.Scale = new Vector2f(0.1f, 0.1f);
                    msgSprite.Position = new Vector2f(650, 350);
                    msgTextObj.Position = new Vector2f(msgSprite.Position.X + 80, msgSprite.Position.Y);
                    msgTextObj.Origin = new Vector2f(msgTextObj.GetGlobalBounds().Width / 2, msgTextObj.GetGlobalBounds().Height / 2);
                    msgTextObj.CharacterSize = 18;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        /// <summary>
        /// Rysowanko uszanowanko
        /// </summary>
        public virtual void draw(RenderWindow windowDraw)
        {
            windowDraw.Draw(msgTextObj);
            if (presentTexture)
            {
                windowDraw.Draw(msgSprite);
            }
            
        }
        /// <summary>
        /// Czy bedzie sprite
        /// </summary>
        protected bool presentTexture = false;
        /// <summary>
        /// Tekstura komunikatu
        /// </summary>
        private Texture msgTextures;
        /// <summary>
        /// Czcionka podpisu
        /// </summary>
        private Font msgTextFont;
        /// <summary>
        /// Sprite komunikatów
        /// </summary>
        private Sprite msgSprite;
        /// <summary>
        /// Treść komunikatu
        /// </summary>
        private Text msgTextObj;
        /// <summary>
        /// String tekstu
        /// </summary>
        private string msgTextString;
        /// <summary>
        /// Geter i seter do ustawienia tego co ma byc w komunikacie
        /// </summary>
        public string Text
        {
            get
            {
                return msgTextString;
            }
            set
            {
                msgTextString = value;
            }
        }
    }
}
