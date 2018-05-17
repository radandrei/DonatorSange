using BusinessLayer.Models;
using BusinessLayer.ServiceInterfaces;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        public List<StatusModel> GetAllStatuses()
        {
            return statusRepository.GetAll().Select(s => new StatusModel(s)).ToList();
        }
    }
}
