namespace Policy.Framework.Mappers
{
    using AutoMapper;
    using System;
    using Policy.Framework.Data.Entities;
    using Policy.Framework.Extensions;
    using Policy.Framework.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Entities.VehicleEntity, Domain.Vehicle>().ForAllMembers(opts => opts.Ignore());
            
            CreateMap<Domain.Vehicle, Data.Entities.VehicleEntity>()
            .ForMember(dest => dest.VehicleId, opt => opt.Ignore());

            //CreateMap<Data.Entities.ServiceEntity, Domain.Service>().ForAllMembers(opts => opts.Ignore());

            CreateMap<Data.Entities.PolicyEntity, Domain.Policy>().ForMember( dest => dest.VehicleId, opt => opt.MapFrom(o => o.VehicleId) )
            .ForMember( dest => dest.StartDate, opt => opt.MapFrom(o => o.StartDate) )
            .ForMember( dest => dest.EndtDate, opt => opt.MapFrom(o => o.EndtDate) )
            .ForMember( dest => dest.Amount, opt => opt.MapFrom(o => o.Amount) )
            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Domain.Policy, Data.Entities.PolicyEntity>().ForMember( dest => dest.VehicleId, opt => opt.MapFrom(o => o.VehicleId) )
            .ForMember( dest => dest.StartDate, opt => opt.MapFrom(o => o.StartDate) )
            .ForMember( dest => dest.EndtDate, opt => opt.MapFrom(o => o.EndtDate) )
            .ForMember( dest => dest.Amount, opt => opt.MapFrom(o => o.Amount) )
            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Domain.Service, Data.Entities.ServiceEntity>().ForMember( dest => dest.ServiceId, opt =>  opt.MapFrom(o => o.ServiceId) )
            .ForMember( dest => dest.Name , opt => opt.MapFrom(o => o.Name) )
            .ForMember( dest => dest.Price, opt => opt.MapFrom(o => o.Price) )
            .ForMember( dest => dest.Period, opt => opt.MapFrom(o => o.Period) )
            .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
