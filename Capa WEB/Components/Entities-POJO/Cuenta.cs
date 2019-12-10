using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Cuenta : BaseEntity
    {
        public string idCuenta { get; set; }
        public string nombre { get; set; }
        public string moneda { get; set; }
        public int saldo { get; set; }

        public Cuenta()
        {

        }


        public Cuenta(string[] infoArray)
        {
            if(infoArray != null && infoArray.Length>=4)
            {
                idCuenta = infoArray[0];
                nombre = infoArray[1];
                moneda = infoArray[2];
                var saldoC = 0;
                if (Int32.TryParse(infoArray[3], out saldoC))
                {
                    saldo = saldoC;
                }
                else
                    throw new Exception("el saldo debe ser un número");


            }
            else
            {
                throw new Exception("Todos los valores son requeridos[idCuenta,nombre,moneda,saldo]");
            }
        }
    }
}
