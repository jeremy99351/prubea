using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;

namespace CoreAPI
{
   public class DireccionesManager : BaseManager
    {


        private DireccionesCrudFactory crudDireccion;

        public DireccionesManager()
        {
            crudDireccion = new DireccionesCrudFactory();
        }

        public void Create(Direcciones direccion)
        {
            try
            {
                var d = crudDireccion.Retrieve<Direcciones>(direccion);

                if (d != null)
                {
                    throw new BussinessException(3);
                }

                crudDireccion.Create(direccion);





            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Direcciones> RetrieveAll()
        {
            return crudDireccion.RetrieveAll<Direcciones>();
        }

        public Direcciones RetrieveById(Direcciones direccion)
        {
            Direcciones d = null;
            try
            {
                d = crudDireccion.Retrieve<Direcciones>(direccion);
                if (d == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return d;
        }

        public void Update(Direcciones direccion)
        {
            crudDireccion.Update(direccion);
        }

        public void Delete(Direcciones direccion)
        {
            crudDireccion.Delete(direccion);
        }
    }
}
