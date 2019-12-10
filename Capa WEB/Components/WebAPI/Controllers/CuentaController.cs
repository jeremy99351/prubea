using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities_POJO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CuentaController : ApiController 
    {
        ApiResponse apiResp = new ApiResponse();

        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mngCuenta = new CoreAPI.CuentaManager();
            apiResp.Data = mngCuenta.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/cuenta/
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mngCuenta = new CoreAPI.CuentaManager();
                var cuenta = new Cuenta
                {
                    idCuenta = id
                };

                cuenta = mngCuenta.RetrieveById(cuenta);
                apiResp = new ApiResponse();
                apiResp.Data = cuenta;
                return Ok(apiResp);
            }
            catch (Exceptions.BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Cuenta cuenta)
        {

            try
            {
                var mngCuenta = new CoreAPI.CuentaManager();
                mngCuenta.Create(cuenta);

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
        public IHttpActionResult Put(Cuenta cuenta)
        {
            try
            {
                var mngCuenta = new CoreAPI.CuentaManager();
                mngCuenta.Update(cuenta);

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
        public IHttpActionResult Delete(Cuenta cuenta)
        {
            try
            {
                var mngCuenta = new CoreAPI.CuentaManager();
                mngCuenta.Delete(cuenta);

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