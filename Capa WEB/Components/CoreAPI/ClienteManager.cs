using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using Exceptions;
using DataAcces.Crud;

namespace CoreAPI
{
    public class ClienteManager : BaseManager
    {
        private DataAcess.Crud.ClienteCrudFactory crudCliente;

        public ClienteManager()
        {
            crudCliente = new DataAcess.Crud.ClienteCrudFactory();
        }

        public void Create(Cliente cliente)
        {
            try
            {
                var c = crudCliente.Retrieve<Cliente>(cliente);

                if (c != null)
                {
                    throw new BussinessException(3);
                }

                if (cliente.edad >= 18)

                    crudCliente.Create(cliente);
                else
                    throw new BussinessException(2);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Cliente> RetrieveAll()
        {
            return crudCliente.RetrieveAll<Cliente>();
        }

        public Cliente RetrieveById(Cliente cliente)
        {
            Cliente c = null;
            try
            {
                c = crudCliente.Retrieve<Cliente>(cliente);
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

        public void Update(Cliente cliente)
        {
            crudCliente.Update(cliente);
        }

        public void Delete(Cliente cliente)
        {
            crudCliente.Delete(cliente);
        }

    }
}
