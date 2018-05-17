using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IStatusService
    {
        List<StatusModel> GetAllStatuses();
    }
}
