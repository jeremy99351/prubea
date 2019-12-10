using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Direcciones : BaseEntity
    {
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string nombre { get; set; }
        public Direcciones()
        {

        }
        public Direcciones(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                Provincia = infoArray[0];
                Canton = infoArray[1];
                Distrito = infoArray[2];
                nombre = infoArray[3];
            }
            else
            {
                throw new Exception("La dirección requiere[provincia,canton,distrito,nombre]");
            }

        }
    }
}