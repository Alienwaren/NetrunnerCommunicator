/*
 * 
 * 
 * Klasa będzie zawierać teksturę obrazów statusu.
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
namespace ARDSQL_GUI
{
    class StatusImageTexture
    {
        /// <summary>
        /// Konstruktor ktory ładuje teksture do pamięci
        /// </summary>
        public StatusImageTexture()
        {
            if (loadTexture())
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
        /// <summary>
        /// Nasza tekstura statusu.
        /// </summary>
        private Texture statusTexture;
        /// <summary>
        /// Getter dla statusTexture
        /// </summary>
        public Texture statusRpi
        {
            get
            {
                return statusTexture;
            }
        }
        /// <summary>
        /// Ładowanko tekstury do pamięci
        /// </summary>
        /// <returns></returns>
        private Boolean loadTexture()
        {
            try
            {
                Console.Write("Loading status Texture... ");
                statusTexture = new Texture("Resources/Graphics/status_texture.png");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
