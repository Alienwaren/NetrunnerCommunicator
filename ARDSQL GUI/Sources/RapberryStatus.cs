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
        }
        /// <summary>
        /// Rysowanko uszanowanko
        /// </summary>
        public void draw(RenderWindow windowToBeDrawed)
        {
            windowToBeDrawed.Draw(raspBerryPiSprite);
        }
        /// <summary>
        /// Updatujemy obrazek
        /// </summary>
        public void update()
        {
            raspBerryPiSprite.Scale = new Vector2f(spriteScaleFloat, spriteScaleFloat);
            raspBerryPiSprite.Position = spritePosition;
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
    }
}
