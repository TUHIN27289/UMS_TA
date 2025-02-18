﻿using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UMS_TA.Controllers
{
    public class CompanyController : ApiController
    {
        [HttpPost]
        [Route("api/Company/Create")]
        public HttpResponseMessage Create(CompanyDTO s)
        {
            if (s == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "CompanyDTO cannot be null");
            }

            try
            {
                CompanyService.Create(s);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to register Company: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Company/Show")]
        public HttpResponseMessage Show()
        {
            var data = CompanyService.Show();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/Company/{id}")]
        public HttpResponseMessage Show(int id)
        {
            var data = CompanyService.Show(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPut]
        [Route("api/Company/Update")]
        public HttpResponseMessage Update(CompanyDTO studentDTO)
        {
            try
            {
                var success = CompanyService.Update(studentDTO);
                if (success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Company updated successfully.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Company not found or update failed.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
        /*
                [HttpDelete]
                [Route("api/Student/Delete/{id}")]
                public HttpResponseMessage Delete(int id)
                {
                    try
                    {
                        var success = StudentService.Delete(id);
                        if (success)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, "Student deleted successfully.");
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "Student not found or delete failed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
                    }
                }*/
    }
}
