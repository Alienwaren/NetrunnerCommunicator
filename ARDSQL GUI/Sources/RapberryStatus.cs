using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
namespace ARDSQL_GUI
{
    class RapberryStatus
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="left">Początek kwadratu</param>
        /// <param name="top">Góra kwadratu</param>
        /// <param name="width">Długość</param>
        /// <param name="height">Szerokość</param>
        public RapberryStatus(int left, int top, int width, int height)
        {
            raspBerryTextureRectangle = new IntRect(left, top, width, height);
        }
        
        /// <summary>
        /// Pobranie tekstury z parametru i ustawienie atrybutów
        /// </summary>
        /// <param name="raspBerryPiTexture">Referencja do tekstury</param>
        public void bindTextureAndSetAttrib(Texture raspBerryPiTexture)
        {     
            raspBerryPiSprite = new Sprite(raspBerryPiTexture, raspBerryTextureRectangle);
            this.raspBerryPiSprite.Origin = new Vector2f(raspBerryPiSprite.GetGlobalBounds().Width / 2, raspBerryPiSprite.GetGlobalBounds().Height / 2);
            rpiLabel.createSpriteAndSetPosition(this.labelsTextures.texture, new IntRect(0, 0, 1251, 304));
        }
        /// <summary>
        /// Rysowanko uszanowanko
        /// </summary>
        public void draw(RenderWindow windowToBeDrawed)
        {
            windowToBeDrawed.Draw(raspBerryPiSprite);
            this.rpiLabel.draw(windowToBeDrawed);
        }
        /// <summary>
        /// Updatujemy obrazek
        /// </summary>
        public void update()
        {
            raspBerryPiSprite.Scale = new Vector2f(spriteScaleFloat, spriteScaleFloat);
            raspBerryPiSprite.Position = spritePosition;
            rpiLabel.scale = 0.2f;
            rpiLabel.position = new Vector2f((raspBerryPiSprite.GetGlobalBounds().Height / 2), raspBerryPiSprite.GetGlobalBounds().Width / 2);
            rpiLabel.update();
        }
        /// <summary>
        /// Pozycja sprajta
        /// </summary>
        private Vector2f spritePosition;
        /// <summary>
        /// Geter i seter dla pola spritePosition
        /// </summary>
        public Vector2f position
        {
            get
            {
                return spritePosition;
            }
            set
            {
                spritePosition = value;
            }
        }
        /// <summary>
        /// Sprite statusu
        /// </summary>
        private Sprite raspBerryPiSprite;
        /// <summary>
        /// Kwadrat tekstury
        /// </summary>
        private IntRect raspBerryTextureRectangle;
        /// <summary>
        /// Skala obrazka
        /// </summary>
        private float spriteScaleFloat;
        /// <summary>
        /// Geter i seter
        /// </summary>
        public float scale
        {
            get
            {
                return spriteScaleFloat;
            }
            set
            {
                spriteScaleFloat = value;
            }
        }
        /// <summary>
        /// Tesktura podpisów do Raspberry Pi
        /// </summary>
        LabelTexture labelsTextures = new LabelTexture();
        /// <summary>
        /// Podpisy statusów komponentów
        /// </summary>
        Label rpiLabel = new Label("Voltage", new Vector2f(170, 350));
        /// <summary>
        /// Wartość napięcia:
        /// TODO: odbieranie z serwera tej wartości
        /// </summary>
        Voltage rpiVcc = new Voltage(5.0F);
    }
}
