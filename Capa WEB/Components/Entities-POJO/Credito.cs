using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Credito : BaseEntity
    {

        public string idCredito { get; set; }
        public int monto { get; set; }
        public int taza { get; set; }
        public string nombre { get; set; }
        public int cuota { get; set; }
        public string fechaInicio { get; set; }
        public string estado { get; set; }
        public int saldo { get; set; }

        public Credito()
        {

        }

        public Credito(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 8)
            {
                idCredito = infoArray[0];
                var montoC = 0;
                if (Int32.TryParse(infoArray[1], out montoC))
                {
                    monto = montoC;
                }
                else
                    throw new Exception("el monto debe ser un número");

                var tazaC = 0;
                if (Int32.TryParse(infoArray[2], out tazaC))
                {
                    taza = tazaC;
                }
                else
                    throw new Exception("La taza debe ser un número");

                nombre = infoArray[3];

                var cuotaC = 0;
                if (Int32.TryParse(infoArray[4], out cuotaC))
                {
                    cuota = cuotaC;
                }
                else
                    throw new Exception("La cuota debe ser un número");

                fechaInicio = infoArray[5];
                estado = infoArray[6];
                var SaldoC = 0;
                if (Int32.TryParse(infoArray[7], out SaldoC))
                {
                    saldo = SaldoC;
                }
                else
                    throw new Exception("El saldo debe ser un número");

            }

        }

    }
}
