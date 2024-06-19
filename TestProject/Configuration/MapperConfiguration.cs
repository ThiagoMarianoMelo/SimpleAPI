using AutoMapper;
using TestProject.Domain.Command;
using TestProject.Domain.Entities;

namespace TestProject.Configuration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
