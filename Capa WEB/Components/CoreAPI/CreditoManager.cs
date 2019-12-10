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
    public class CreditoManager : BaseManager
    {

        private CreditoCrudFactory crudCredito;

        public CreditoManager()
        {
            crudCredito = new CreditoCrudFactory();
        }

        public void Create(Credito credito)
        {
            try
            {
                var c = crudCredito.Retrieve<Credito>(credito);

                if (c != null)
                {
                    throw new BussinessException(3);
                }

                if (credito.monto >= 20000)
                    crudCredito.Create(credito);

                else
                    throw new BussinessException(2);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Credito> RetrieveAll()
        {
            return crudCredito.RetrieveAll<Credito>();
        }

        public Credito RetrieveById(Credito credito)
        {
            Credito c = null;
            try
            {
                c = crudCredito.Retrieve<Credito>(credito);
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

        public void Update(Credito credito)
        {
            crudCredito.Update(credito);
        }

        public void Delete(Credito credito)
        {
            crudCredito.Delete(credito);
        }
    }
}
