using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    class RequestStatusModel
    {
        public RequestStatusModel(RequestStatus req)
    {

        ID = req.ID;
        Name = req.Name;
    }

    public RequestStatusModel()
    {

    }
    public int ID { get; set; }
    public string Name { get; set; }
}
}
