using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CoreAPI;
using Entities_POJO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LocalizacionController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // Retrieve
        public IHttpActionResult Get()
        { 

            apiResp = new ApiResponse();
            var mngLocalizacion = new LocalizacionManager();
            apiResp.Data = mngLocalizacion.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/direcciones/
        // Retrieve by id
        public IHttpActionResult Get(string cedula)
        {
            try
            {
                var mngLocalizacion = new LocalizacionManager();
                var localizacion = new Localizacion
                {
                    cedula = cedula
                };

                localizacion = mngLocalizacion.RetrieveById(localizacion);
                apiResp = new ApiResponse();
                apiResp.Data = localizacion;
                return Ok(apiResp);
            }
            catch (Exceptions.BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Localizacion localizacion)
        {

            try
            {
                var mngLocalizacion = new LocalizacionManager();
                mngLocalizacion.Create(localizacion);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (Exceptions.BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Localizacion localizacion)
        {
            try
            {
                var mngLocalizacion = new LocalizacionManager();
                mngLocalizacion.Update(localizacion);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (Exceptions.BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Localizacion localizacion)
        {
            try
            {
                var mngLocalizacion = new LocalizacionManager();
                mngLocalizacion.Delete(localizacion);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (Exceptions.BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }

}
