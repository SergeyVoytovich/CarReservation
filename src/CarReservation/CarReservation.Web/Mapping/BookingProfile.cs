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

        CreateMap<NewBookingViewModel, Booking>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dst => dst.CarId, opt => opt.MapFrom(src => src.Car!.Id))
            .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.StartDate!.Value)))
            .ForMember(dst => dst.EndDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.EndDate!.Value)))
            .ForMember(dst => dst.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
            ;
    }
}
