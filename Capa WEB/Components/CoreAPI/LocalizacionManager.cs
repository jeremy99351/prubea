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
    public class LocalizacionManager : BaseManager
    {

        private LocalizacionCrudFactory crudLocalizacion;

        public LocalizacionManager()
        {
            crudLocalizacion = new LocalizacionCrudFactory();
        }

        public void Create(Localizacion localizacion)
        {
            try
            {
                var l = crudLocalizacion.Retrieve<Localizacion>(localizacion);

                if (l != null)
                {
                    throw new BussinessException(3);
                   
                }

                 crudLocalizacion.Create(localizacion);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Localizacion> RetrieveAll()
        {
            return crudLocalizacion.RetrieveAll<Localizacion>();
        }

        public Localizacion RetrieveById(Localizacion localizacion)
        {
            Localizacion l = null;
            try
            {
                l = crudLocalizacion.Retrieve<Localizacion>(localizacion);
                if (l == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return l;
        }

        public void Update(Localizacion localizacion)
        {
            crudLocalizacion.Update(localizacion);
        }

        public void Delete(Localizacion localizacion)
        {
            crudLocalizacion.Delete(localizacion);
        }
    }
}
