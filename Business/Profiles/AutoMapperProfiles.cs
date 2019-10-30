using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Data.Models;
using ViewModel;
using ViewModel.Address;
using ViewModel.Company;
using ViewModel.Login;
using ViewModel.Order;
using ViewModel.SubscriptionsPlans;
using ViewModel.User;

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

            CreateMap<User, UserViewModel>()
                .ReverseMap();

            CreateMap<User, RegisterUserViewModel>()
                .ReverseMap();
        }
    }
}
