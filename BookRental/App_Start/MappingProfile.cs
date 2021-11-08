using AutoMapper;
using BookRental.Dtos;
using BookRental.Models;

namespace BookRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Book, BookDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<BookDto, Book>()
                .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}