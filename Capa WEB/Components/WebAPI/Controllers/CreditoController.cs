using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entities_POJO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CreditoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mngCredito = new CoreAPI.CreditoManager();
            apiResp.Data = mngCredito.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/credito/
        // Retrieve by id
        public IHttpActionResult Get(string idC)
        {
            try
            {
                var mngCredito = new CoreAPI.CreditoManager();
                var credito = new Credito
                {
                    idCredito = idC
                };

                credito = mngCredito.RetrieveById(credito);
                apiResp = new ApiResponse();
                apiResp.Data = credito;
                return Ok(apiResp);
            }
            catch (Exceptions.BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Credito credito)
        {

            try
            {
                var mngCredito = new CoreAPI.CreditoManager();
                mngCredito.Create(credito);

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
        public IHttpActionResult Put(Credito credito)
        {
            try
            {
                var mngCredito = new CoreAPI.CreditoManager();
                mngCredito.Update(credito);

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
        public IHttpActionResult Delete(Credito credito)
        {
            try
            {
                var mngCredito = new CoreAPI.CreditoManager();
                mngCredito.Delete(credito);

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