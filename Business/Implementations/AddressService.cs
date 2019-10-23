using AutoMapper;
using Business.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using ViewModel.Address;

namespace Business.Implementations
{
    public class AddressService : ServiceCrud<Address, AddressViewModel>, IAddressService
    {
        public AddressService(IAddressRepository repository,
                                IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
