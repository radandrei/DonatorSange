using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class StatusModel
    {
        public StatusModel(Status unit)
        {

            Id = unit.Id;
            Name = unit.Name;
        }

        public StatusModel()
        {

        }

        public StatusModel(int statusId)
        {
            Id = statusId;
        }

        public StatusModel(StatusModel statusModel)
        {
            Id = statusModel.Id;
            Name = statusModel.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

