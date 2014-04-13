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
    /// Implementacja guzika wyjścia
    /// </summary>
    class ExitButton
        : Button
    {
        /// <summary>
        /// Konstruktor domyślny dzięki któremu ustawimy pozycję guzika
        /// </summary>
        /// <param name="initialButtonPosition">Początkowa pozycja guzika.</param>
        public ExitButton(Vector2f initialButtonPosition, String buttonName)
            : base()
        {
            setTexture();
            this.setAttributes(initialButtonPosition, buttonName);
        }
        protected override void setTexture()
        {
            base.setTexture();
            this.spriteRect = new IntRect(410, 9, 400, 365);
            this.buttonSprite = new Sprite(base.buttonTextures, spriteRect);
            
        }
        protected override void setAttributes(Vector2f initialButtonPosition, String buttonName)
        {
            base.setAttributes(initialButtonPosition, buttonName);
            buttonSprite.Scale = new Vector2f(0.2F, 0.2F);
            this.buttonLabel.DisplayedString = buttonName;
            this.buttonSprite.Position = initialButtonPosition;
            buttonLabel.Position = new Vector2f(buttonSprite.Position.X, buttonSprite.Position.Y + 40);
            buttonLabel.Origin = new Vector2f(buttonLabel.GetGlobalBounds().Width / 2, buttonLabel.GetGlobalBounds().Height / 2);
        }
        public override void onClick(RenderWindow windowToBeClosed)
        {
            base.onClick(windowToBeClosed);
            windowToBeClosed.Close(); 
        }
    }
}
