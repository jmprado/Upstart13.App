using AutoMapper;

namespace Upstart13.BeerApp.Mapping
{
    public static class MappingGetter
    {
        public static Mapper Get()
        {
            var profile = new AutomapperProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(config);

            return mapper;
        }
    }
}
