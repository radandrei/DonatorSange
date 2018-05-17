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

        public DonationController(IDonationService donationService)
        {
            this.donationService = donationService;
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
            catch(Exception ex)
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
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
         
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
