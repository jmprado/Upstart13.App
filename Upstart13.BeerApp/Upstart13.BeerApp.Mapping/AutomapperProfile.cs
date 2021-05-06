using AutoMapper;
using System.Collections.Generic;
using Upstart13.BeerApp.Entities;
using Upstart13.BeerApp.ViewModel;

namespace Upstart13.BeerApp.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PunkApiBeerModel, Beer>()
                .ForMember(dest => dest.Abv, opt => opt.MapFrom(src => src.Abv))
                .ForMember(dest => dest.AttenuationLevel, opt => opt.MapFrom(src => src.AttenuationLevel))
                .ForMember(dest => dest.BrewerTips, opt => opt.MapFrom(src => src.BrewersTips))
                .ForMember(dest => dest.ContributedBy, opt => opt.MapFrom(src => src.ContributedBy))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Ebc, opt => opt.MapFrom(src => src.Ebc))
                .ForMember(dest => dest.ListFoodPairing, opt => opt.MapFrom(src => src.FoodPairing))
                .ForMember(dest => dest.FirstBrewed, opt => opt.MapFrom(src => src.FirstBrewed))
                .ForMember(dest => dest.Ibu, opt => opt.MapFrom(src => src.Ibu))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Ph, opt => opt.MapFrom(src => src.Ph))
                .ForMember(dest => dest.Srm, opt => opt.MapFrom(src => src.Srm))
                .ForMember(dest => dest.Tagline, opt => opt.MapFrom(src => src.Tagline))
                .ForMember(dest => dest.TargetFg, opt => opt.MapFrom(src => src.TargetFg))
                .ForMember(dest => dest.TargetOg, opt => opt.MapFrom(src => src.TargetOg))
                .ForMember(dest => dest.Method, opt => opt.Ignore())
                .ForMember(dest => dest.Ingredient, opt => opt.Ignore())
                .ForMember(dest => dest.Volume, opt => opt.Ignore())
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<string, FoodPairing>()
                .ForMember(dest => dest.Food, opt => opt.MapFrom(src => src))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunkApiMashTemp, Method>()
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                .ForMember(dest => dest.MethodTypeId, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.TemperatureUnit, opt => opt.MapFrom(src => src.Temp.Unit))
                .ForMember(dest => dest.TemperatureValue, opt => opt.MapFrom(src => src.Temp.Value))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunkApiFermentation, Method>()
                .ForMember(dest => dest.MethodTypeId, opt => opt.MapFrom(src => 2))
                .ForMember(dest => dest.TemperatureUnit, opt => opt.MapFrom(src => src.Temp.Unit))
                .ForMember(dest => dest.TemperatureValue, opt => opt.MapFrom(src => src.Temp.Value))
                .ForMember(dest => dest.Duration, opt => opt.Ignore())
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunkApiMethod, Method>()
                .ForMember(dest => dest.MethodTypeId, opt => opt.MapFrom(src => 3))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Twist))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunkApiMalt, Ingredient>()
                .ForMember(dest => dest.IngredienteTypeId, src => src.MapFrom(src => 1))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.AmountUnit, src => src.MapFrom(src => src.Amount.Unit))
                .ForMember(dest => dest.AmountValue, src => src.MapFrom(src => src.Amount.Value))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunkApiHop, Ingredient>()
                .ForMember(dest => dest.IngredienteTypeId, src => src.MapFrom(src => 2))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.AmountUnit, src => src.MapFrom(src => src.Amount.Unit))
                .ForMember(dest => dest.AmountValue, src => src.MapFrom(src => src.Amount.Value))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<string, Ingredient>()
                .ForMember(dest => dest.IngredienteTypeId, src => src.MapFrom(src => 3))
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunkApiBoilVolume, Volume>()
                .ForMember(dest => dest.VolumeTypeId, src => src.MapFrom(src => 1))
                .ForMember(dest => dest.VolumeUnit, src => src.MapFrom(src => src.Unit))
                .ForMember(dest => dest.VolumeValue, src => src.MapFrom(src => src.Value))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<PunkApiBeerModel, ResultSearchModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
