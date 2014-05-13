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

        }
        /// <summary>
        /// Ładowanko tekstury
        /// </summary>
        /// <returns>Zwraca czy ładowanko sie udało</returns>
        private Boolean loadTexture()
        {
            return true;
        }
        /// <summary>
        /// Tekstura podpisu
        /// </summary>
        private Texture labelTexture;
    }
}
