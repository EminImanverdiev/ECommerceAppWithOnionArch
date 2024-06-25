using AutoMapper;
using AutoMapper.Internal;

namespace OnionApi.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();
        private IMapper MapperContainer;
        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public TDestination Map<TDestination, TSource>(object source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<object> source, string? ignore = null)
        {
            throw new NotImplementedException();
        }

        
    }
}
