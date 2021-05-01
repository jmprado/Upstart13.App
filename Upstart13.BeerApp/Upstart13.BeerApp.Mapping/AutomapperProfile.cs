using AutoMapper;
using Upstart13.BeerApp.Entities;
using Upstart13.BeerApp.ViewModel;

namespace Upstart13.BeerApp.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<BeerModel, Beer>().ReverseMap();

        }
    }
}
