using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
    public class CuentaManager : BaseManager
    {

        private CuentaCrudFactory crudCuenta;

        public CuentaManager()
        {
            crudCuenta = new CuentaCrudFactory();
        }

        public void Create(Cuenta cuenta)
        {
            try
            {
                var c = crudCuenta.Retrieve<Cuenta>(cuenta);

                if (c != null)
                {
                    throw new BussinessException(3);
                }

                if (cuenta.saldo >= 20000)
                 crudCuenta.Create(cuenta); 

                else
                    throw new BussinessException(2);


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Cuenta> RetrieveAll()
        {
            return crudCuenta.RetrieveAll<Cuenta>();
        }

     
        public Cuenta RetrieveById(Cuenta cuenta)
        {
            Cuenta c = null;
            try
            {
                c = crudCuenta.Retrieve<Cuenta>(cuenta);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Cuenta cuenta)
        {
            crudCuenta.Update(cuenta);
        }

        public void Delete(Cuenta cuenta)
        {
            crudCuenta.Delete(cuenta);
        }

     
    }
}
