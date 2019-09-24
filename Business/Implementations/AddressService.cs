using Business.Interfaces;
using Data;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Implementations
{
    public class AddressService : ServiceCrud<Address>, IAddressService
    {
        public AddressService(IAddressRepository repository) 
            : base(repository)
        {
        }
    }
}
