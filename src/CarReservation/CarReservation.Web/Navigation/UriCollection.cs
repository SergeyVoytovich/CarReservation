using System.Security.Cryptography.X509Certificates;

namespace CarReservation.Web.Navigation;

public static class UriCollection
{
    public const string Root = "/";

    public const string Error = $"{Root}error";


    public static class Booking
    {
        public const string Root = $"{UriCollection.Root}booking";
        public const string New = $"{Booking.Root}/new";

        public static string ToRoot(DateTime from, DateTime till)
            => Root
                .AddQueryString(Parameters.From, from)
                .AddQueryString(Parameters.Till, till)
            ;

        public static string ToRoot(Guid cityId, DateTime from, DateTime till)
            => Root
                .AddQueryString(Parameters.CityId, cityId)
                .AddQueryString(Parameters.From, from)
                .AddQueryString(Parameters.Till, till)
            ;

        public static string ToNew(Guid carId, DateTime from, DateTime till)
            => New
                .AddQueryString(Parameters.CarId, carId)
                .AddQueryString(Parameters.From, from)
                .AddQueryString(Parameters.Till, till)
            ;

        public static class Parameters
        {
            public const string CityId = "city";
            public const string CarId = "car";
            public const string From = "from";
            public const string Till = "till";


        }
    }


    public static class History
    {
        public const string Root = $"{UriCollection.Root}history";

        public const string DetailsRoute = $"{History.Root}/{{id:guid}}";

        public static string ToDetails(Guid id)
            => $"{History.Root}/{id}";
    }
}
