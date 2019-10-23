using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Data.Models;
using ViewModel;
using ViewModel.Address;
using ViewModel.Company;
using ViewModel.Order;
using ViewModel.SubscriptionsPlans;

namespace Business.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Address, AddressViewModel>()
                .ReverseMap();

            CreateMap<Company, CompanyViewModel>()
                .ReverseMap();

            CreateMap<SubscriptionPlans, SubscriptionsPlansViewModel>()
                .ReverseMap();

            CreateMap<Order, OrderViewModel>()
                .ReverseMap();
        }
    }
}
