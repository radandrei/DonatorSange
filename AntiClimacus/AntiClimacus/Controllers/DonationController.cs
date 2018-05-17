using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Models;
using BusinessLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AntiClimacus.Controllers
{
    [Produces("application/json")]
    [Route("api/Donation")]
    public class DonationController : Controller
    {
        private readonly IDonationService donationService;
        private readonly IDonationRequestService donationRequestService;

        public DonationController(IDonationService donationService, IDonationRequestService donationRequestService)
        {
            this.donationService = donationService;
            this.donationRequestService = donationRequestService;
        }

        // GET: api/Donation/5
        [HttpGet("[action]/{id}")]
        public IActionResult GetDonors(int id)
        {
            try
            {
                List<DonorModel> ret = donationService.GetDonors(id);

                return new OkObjectResult(ret);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        [HttpGet("[action]")]
        public IActionResult GetBloodComponents()
        {
            try
            {
                List<BloodComponentModel> ret = donationService.GetBloodComponents();

                return new OkObjectResult(ret);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        [HttpGet("[action]")]
        public IActionResult GetBloodTypes()
        {
            try
            {
                List<BloodTypeModel> ret = donationService.GetBloodTypes();

                return new OkObjectResult(ret);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        // POST: api/Donation
        [HttpPost("[action]")]
        public IActionResult SubmitDonorData([FromBody]DonorDataModel model)
        {
            try
            {
                donationService.SubmitDonorData(model);
                donationRequestService.UpdateStatusOfDonorRequest(model.Donor.Id, 2);

                return new OkObjectResult("donor data updated");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
