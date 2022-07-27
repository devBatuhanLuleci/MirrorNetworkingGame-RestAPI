namespace ACG_Master.Mapper
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
