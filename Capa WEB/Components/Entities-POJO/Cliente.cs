using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Cliente : BaseEntity
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fechaNacimiento { get; set; }
        public int edad { get; set; }
        public string estadoCivil { get; set; }
        public string genero { get; set; }


        public Cliente()
        {

        }

        public Cliente(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                cedula = infoArray[0];
                nombre = infoArray[1];
                apellido = infoArray[2];
                fechaNacimiento = infoArray[3];
                var age = 0;
                if (Int32.TryParse(infoArray[4], out age))
                    edad = age;
                else
                    throw new Exception("La edad debe ser un número");
                estadoCivil = infoArray[5];
                genero = infoArray[6];


            }
            else
            {
                throw new Exception("Todos los valores son requeridos[cedula,nombre,apellido,fechaNacimiento,edad,estadoCivil,genero]");
            }
        }
    }
}
