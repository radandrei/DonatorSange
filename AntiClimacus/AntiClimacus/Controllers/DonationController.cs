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
        private readonly IDonorService donorService;
        public DonationController(IDonationService donationService, IDonationRequestService donationRequestService, IDonorService donorService)
        {
            this.donationService = donationService;
            this.donationRequestService = donationRequestService;
            this.donorService = donorService;
        }

        // GET: api/Donation/getdonors/5
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

        // GET: api/Donation/getDonor/5
        [HttpGet("[action]/{id}")]
        public IActionResult GetDonor(int id)
        {
            try
            {
                List<DonorModel> ret = donationService.GetDonors(id);

                foreach(DonorModel donor in ret)
                {
                    if (donor.Id == id)
                        return new OkObjectResult(donor);
                }

                return new OkObjectResult(null);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }


        // POST: api/Donation
        [HttpPost("[action]")]
        public IActionResult SubmitDonorData([FromBody]DonorModel model)
        {
            try
            {
                donationService.SubmitDonorData(model.DonorData,model.Id);
                donationRequestService.UpdateStatusOfDonorRequest(model.Id, 2);

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

        // POST: api/Donation
        [HttpPost("add")]
        public IActionResult Donate([FromBody]DonorModel model)
        {
            try
            {
                donorService.RegisterDonor(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

    }
}
