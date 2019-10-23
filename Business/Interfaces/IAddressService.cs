using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Address;

namespace Business.Interfaces
{
    public interface IAddressService : IServiceCrud<Address, AddressViewModel>
    {
    }
}
