using AutoMapper;
using Entities.ExtendedModels;
using Entities.Models;

namespace ERPApi.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            AllowNullCollections = true;
            CreateMap<User, TblSecurityUsers>();
            CreateMap<UserGroup, TblSecurityGroups>();
            CreateMap<Customer, TblCustomers>();
            CreateMap<CustomerDetail, TblCustomers>();
        }
    }
}
