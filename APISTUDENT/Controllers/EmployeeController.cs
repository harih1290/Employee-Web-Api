using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APISTUDENT.Models;
using APISTUDENT.Models.Interface;
using APISTUDENT.Core;
using System.Configuration;
namespace APISTUDENT.Controllers
{
    
    public class EmployeeController : ApiController
    {
        private readonly ISqlHelpernterface _sqlHelpernterface;
        public EmployeeController(ISqlHelpernterface sqlHelpernterface)
        {
            this._sqlHelpernterface = sqlHelpernterface;
        }
        [HttpGet]
        [Route("api/Employee/GetDetails")]
        public IHttpActionResult GetDetails()
        {
            try
            {
                Employee emp = new Employee();
                var data = _sqlHelpernterface.SqlCommander(emp, "Get");
                return Ok(data);
            }
            catch (Exception e)
            {
                return Ok(e);
                //throw new HttpResponseException(e);
            }
        }
        [HttpPost]
        [Route("api/Employee/SaveDetails")]
        public IHttpActionResult SaveDetails(Employee emp)
        {
            try
            {
                var data = _sqlHelpernterface.SqlCommander(emp, "Create");
                if (data.Tables[0].Rows.Count > 0)
                {

                    return Ok(data);
                }
                else
                {
                    return Ok("Something went Wrong");
                }
            }
            catch (Exception e)
            {
                return Ok(e);
                //throw new HttpResponseException(e);
            }
        }
        [HttpPost] ///PUT Method Not allowed If disabled WebDEV PUT And DELETE will be working
        [Route("api/Employee/UpdateDetails")]
        public IHttpActionResult UpdateDetails(Employee emp)
        {
            try
            {
                var data = _sqlHelpernterface.SqlCommander(emp, "Update");
                if (data.Tables[0].Rows.Count > 0)
                {

                    return Ok(data);
                }
                else
                {
                    return Ok("Something went Wrong");
                }
            }
            catch (Exception e)
            {
                return Ok(e);
               // throw new HttpResponseException(e);
            }

        }
        [HttpPost]
        [Route("api/Employee/RemoveDetails")]
        public IHttpActionResult RemoveDetails(Employee emp)
        {
            try
            {
                //Employee emp = new Employee();
               // emp.emp_id = Convert.ToInt16(emp_id);
                var data = _sqlHelpernterface.SqlCommander(emp, "Delete");
                if (data.Tables[0].Rows.Count > 0)
                {

                    return Ok(data);
                }
                else
                {
                    return Ok("Something went Wrong");
                }
            }
            catch (Exception e)
            {
                return Ok(e);
                //throw new HttpResponseException(e);
            }
           
        }
    }
}
