namespace CarReservation.Web.Navigation;

public static class UriCollection
{
    public const string Root = "/";

    public const string History = $"{Root}my-bookings";

    public const string Error = $"{Root}error";


    public static class Book
    {
        public const string Root = $"{UriCollection.Root}book";

        public static string GetRoot(Guid cityId, DateTime from, DateTime till)
            => Root
                .AddQueryString(Parameters.CityId, cityId)
                .AddQueryString(Parameters.From, from)
                .AddQueryString(Parameters.Till, till)
            ;

        public static class Parameters
        {
            public const string CityId = "city";
            public const string From = "from";
            public const string Till = "till";


        }
    }
}
