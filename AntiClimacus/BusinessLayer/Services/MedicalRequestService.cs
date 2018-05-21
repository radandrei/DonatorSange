using BusinessLayer.Models;
using BusinessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class MedicalRequestService : IMedicalRequestService
    {
        private readonly IMedicalRequestRepository medicalRequestRepository;
        
        public MedicalRequestService(IMedicalRequestRepository medicalRequestRepository)
        {
            this.medicalRequestRepository = medicalRequestRepository;
        }

        public void DonateBlood(RequestModel request, int distributionQuantity)
        {
            medicalRequestRepository.Donate(request.Id, distributionQuantity);
        }

        public List<RequestModel> GetAllRequests()
        {
            List<Request> requests = medicalRequestRepository.GetAll();

            return requests.Select(x => new RequestModel(x)).ToList();
        }

        public int GetBloodComponentQuantity(int componentId, int unitId)
        {
            int quantity = medicalRequestRepository.GetQuantityByBloodComponentTypeId(componentId, unitId);
            return quantity;
        }

        public RequestModel GetRequestById(int id)
        {
            Request request = medicalRequestRepository.GetById(id);
            return new RequestModel(request);
        }
    }
}
