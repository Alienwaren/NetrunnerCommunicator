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
    /// Klasa implementuje tekstury podpisów
    /// </summary>
    class LabelTexture
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public LabelTexture()
        {
            if (loadTexture())
            {
                Console.WriteLine("Success! ");
            }
            else
            {
                Console.Write("False! ");
            }
        }
        /// <summary>
        /// Ładowanko tekstury
        /// </summary>
        /// <returns>Zwraca czy ładowanko sie udało</returns>
        private Boolean loadTexture()
        {
            Console.Write("Loading label texture... ");
            try
            {
                this.labelTexture = new Texture("Resources/Graphics/Label_Texture.png");
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        /// <summary>
        /// Tekstura podpisu
        /// </summary>
        private Texture labelTexture;
        /// <summary>
        /// Geter dla tekstury
        /// </summary>
        public Texture texture
        {
            get
            {
                return labelTexture;
            }
        }      
    }
}
