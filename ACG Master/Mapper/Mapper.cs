using AutoMapper;

namespace ACG_Master.Mapper
{
    public class Mapper : IMapper
    {
        private AutoMapper.IMapper _mapper;
        public Mapper()
        {
            var profiles = new List<UserProfile>(new List<UserProfile>());
            var config = new MapperConfiguration(config =>
            {
                foreach (var item in profiles)
                {
                    config.AddProfile(item);
                }
            });
            _mapper = config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
