namespace MovieTickets.Data
{
    public class DataConstants
    {
        //Actors and Producers
        public const int FullNameMinLength = 3;
        public const int FullNameMaxLength = 50;
        public const int AgeMaxLength = 80;
        public const int AgeMinLength = 10;
        public const int BiographyMinLength = 10;
        public const int BiographyMaxLength = 255;


        //Movie
        public const int MovieNameMinLength = 10;
        public const int MovieNameMaxLength = 40;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 255;
        //price validation
        //date validation


        //Cinema
        public const int CinemaNameMinLenght = 10;
        public const int CinemaNameMaxLenght = 20;
        public const int CityNameMinLenght = 10;
        public const int CityNameMaxLenght = 20;
        public const int CinemaAddressMinLenght = 20;
        public const int CinemaAddressMaxLenght = 40;
        public const int CinemaHallMinLength = 1;
        public const int CinemaHallMaxLength = 10;
        public const int CinemaRowMinLength = 1;
        public const int CinemaRowMaxLength = 20;
        public const int CinemaSeatMinLength = 1;
        public const int CinemaSeatMaxLength = 50;

        //Tickets
        public const int TicketQuantityMinLength = 1;
        public const int TicketQuantityMaxLength = 10;
        public const int TicketPriceMinLength = 15;
        public const int TicketPriceMaxLength = 50;

        //Display attributes
        public const string DisplayMovieName = "Movie name";
        public const string DisplayMovieLanguage = "Movie language";
        public const string DisplayMovieDuration = "Movie duration";
        public const string DisplayMoviePrice = "Price in $";
        public const string DisplayMovieUrl = "Movie poster URL";
        public const string DisplayMovieStartDate = "Movie start date";
        public const string DisplayMovieEndDate = "Movie end date";
        public const string DisplayMovieGenre = "Select a genre";
        public const string DisplayMovieResolution = "Select a resolution";
        public const string DisplayMovieActors = "Select actor(s)";
        public const string DisplayMovieProducer = "Select a producer";
        public const string DisplayMovieCinema = "Select a cinema";
        public const string DisplayMovieDescription = "Movie description";
        public const string DisplayProfilePicture = "Profile Picture";
        public const string DisplayFullName = "Full Name";
        public const string DisplayBiography = "Biography";
        public const string DisplayAge = "Age";
        public const string DisplayEmail = "Email address";
        public const string DisplayConfirmPassword = "Confirm password";
        public const string DisplayCinemaLogo = "Cinema Logo";
        public const string DisplayCinemaName = "Cinema Name";
        public const string DisplayCinemaAddress = "Cinema Address";
        public const string DisplayCity = "City";

        //Display errors
        public const string LanguageError = "Language is required";
        public const string DurationError = "Duration is required";
        public const string PriceError = "Price is required";
        public const string PosterError = "Movie poster is required";
        public const string StartDateError = "Start date is required";
        public const string EndDateError = "End date is required";

        public const string GenreError = "Genre is required";
        public const string ResolutionError = "Resolution is required";
        public const string ActorsError = "Actor(s) is required";
        public const string ProducerError = "Producer is required";
        public const string CinemaError = "Cinema is required";


        public const string ProfilePictureError = "Profile picture is required";
        public const string FullNameError = "Full Name is required";
        public const string BiographyError = "Biography is required";
        public const string NameError = "Name is required";
        public const string DescriptionError = "Description is required";
        public const string EmailError = "Email address is required";
        public const string ConfirmPasswordError = "Confirm password is required";
        public const string CinemaLogoError = "Cinema logo is required";
        public const string CinemaNameError = "Cinema name is required";
        public const string CinemaAddressError = "Cinema address is required";
        public const string CinemaCityError = "City is required";
        public const string AgeError = "Age is required";



    }
}
