using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities_POJO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DireccionController : ApiController

    {

        ApiResponse apiResp = new ApiResponse();

        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mngDireccion = new CoreAPI.DireccionesManager();
            apiResp.Data = mngDireccion.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/direcciones/
        // Retrieve by id
        public IHttpActionResult Get(string provincia)
        {
            try
            {
                var mngDireccion = new CoreAPI.DireccionesManager();
                var direccion = new Direcciones
                {
                    Provincia = provincia
                };

                direccion = mngDireccion.RetrieveById(direccion);
                apiResp = new ApiResponse();
                apiResp.Data = direccion;
                return Ok(apiResp);
            }
            catch (Exceptions.BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Direcciones direccion)
        {

            try
            {
                var mngDireccion = new CoreAPI.DireccionesManager();
                mngDireccion.Create(direccion);

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
        public IHttpActionResult Put(Direcciones direccion)
        {
            try
            {
                var mngDireccion = new CoreAPI.DireccionesManager();
                mngDireccion.Update(direccion);

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
        public IHttpActionResult Delete(Direcciones direccion)
        {
            try
            {
                var mngDireccion = new CoreAPI.DireccionesManager();
                mngDireccion.Delete(direccion);

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