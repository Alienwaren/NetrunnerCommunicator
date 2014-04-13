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
    /// Implementacja klasy guzika połączenia
    /// </summary>
    class ConnButton
        : Button
    {
        public ConnButton(Vector2f initialButtonPosition, String buttonName)
            : base()
        {
            setTexture();
            setAttributes(initialButtonPosition, buttonName);
        }
        protected override void setTexture()
        {
            base.setTexture();
            this.spriteRect = new IntRect(9, 36, 359, 379);
            this.buttonSprite = new Sprite(base.buttonTextures, this.spriteRect);
        }
        protected override void setAttributes(Vector2f initialButtonPosition, string buttonName)
        {
            base.setAttributes(initialButtonPosition, buttonName);
            this.buttonLabel.DisplayedString = buttonName;
            this.buttonSprite.Position = initialButtonPosition;
            buttonLabel.Position = new Vector2f(buttonSprite.Position.X, buttonSprite.Position.Y + 40);
            buttonLabel.Origin = new Vector2f(buttonLabel.GetGlobalBounds().Width / 2, buttonLabel.GetGlobalBounds().Height / 2);
            this.buttonSprite.Scale = new Vector2f(0.2F, 0.2F);
        }
        /// <summary>
        /// Uruchomienie serwera poprzez kliknięcie
        /// </summary>
        /// <param name="tempReceiver"></param>
        public override void onClick(TemperatureReceiver serverReceiver, int maxConnections)
        {
            serverReceiver.startServer(maxConnections);
        }
    }
}
