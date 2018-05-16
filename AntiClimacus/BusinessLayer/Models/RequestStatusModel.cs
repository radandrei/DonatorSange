using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class RequestStatusModel
    {
        public RequestStatusModel(RequestStatus req)
        {

            Id = req.Id;
            Name = req.Name;
        }

        public RequestStatusModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
