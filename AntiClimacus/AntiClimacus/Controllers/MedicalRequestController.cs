using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntiClimacus.Models;
using BusinessLayer.Models;
using BusinessLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AntiClimacus.Controllers
{
    [Produces("application/json")]
    [Route("api/MedicalRequest")]
    public class MedicalRequestController : Controller
    {
        private readonly IMedicalRequestService medicalRequestService;

        public MedicalRequestController(IMedicalRequestService medicalRequestService)
        {
            this.medicalRequestService = medicalRequestService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllRequests()
        {
            try
            {
                List<RequestModel> ret = medicalRequestService.GetAllRequests();
                return new OkObjectResult(ret);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetRequest(int id)
        {
            try
            {
                RequestModel ret = medicalRequestService.GetRequestById(id);

                return new OkObjectResult(ret);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost("[action]")]
        public IActionResult GetBCTQuantity([FromBody]ComponentMedicalUnit model)
        {
            try
            {
                int quantity = medicalRequestService.GetBloodComponentQuantity(model.ComponentTypeId, model.MedicalUnitId);
                return new OkObjectResult(quantity);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost("[action]")]
        public IActionResult UpdateRequest([FromBody]RequestWithQuantity model)
        {
            try
            {
                medicalRequestService.DonateBlood(model.Request, model.DistributionQuantity);
                return new OkObjectResult("Blood donated");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

    }
}