using AutoMapper;

namespace Hahn.ApplicatonProcess.December2020.Data.Common.Mappers
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
