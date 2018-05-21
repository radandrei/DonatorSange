using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceInterfaces
{
    public interface IAddressService
    {
        AddressModel AddOrUpdateAdress(AddressModel addressModel);
    }
}
