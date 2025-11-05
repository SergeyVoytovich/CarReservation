using AutoMapper;
using CarReservation.Web.Domain;
using CarReservation.Web.VIewModels;

namespace CarReservation.Web.Mapping;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Car, BookingItem>()
            .ForMember(dst => dst.CarId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.LicensePlate, opt => opt.MapFrom(src => src.LicensePlate))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => $"{src.Make} {src.Model}" ))
            ;

        
    }
}
