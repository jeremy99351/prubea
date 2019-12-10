using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Localizacion : BaseEntity
    {

        public string idLocalizacion { get; set; }
        public string cedula { get; set; }
        public string tipoLocalizacion { get; set; }
        public string valor { get; set; }

        public Localizacion()
        {

        }

        public Localizacion(string[] infoArray) 
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                idLocalizacion = infoArray[0];
                cedula = infoArray[1];
                tipoLocalizacion = infoArray[2];
                valor = infoArray[3];
            }
            else
            {
                throw new Exception("La Localización requiere[idLocalizacion,cedula,tipo de localizacion,valor]");
            }
        }


    }
}
