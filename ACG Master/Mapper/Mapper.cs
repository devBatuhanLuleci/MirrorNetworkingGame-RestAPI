using AutoMapper;

namespace ACG_Master.Mapper
{
    public class Mapper : IMapper
    {
        private AutoMapper.IMapper _mapper;
        public Mapper()
        {
            var profiles = new List<UserProfile>()
            {
                new UserProfile()
            };
            var config = new MapperConfiguration(config =>
            {
                foreach (var item in profiles)
                {
                    config.AddProfile(item);
                }
            });
            _mapper = new AutoMapper.Mapper(config);
            //_mapper = config.CreateMapper();
        }
        // düzenlenecek
        public TDestination Map<TSource, TDestination>(TSource source)
        {

            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}
