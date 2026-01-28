namespace CSharp.Practice.Q2_MovieStock
{
    /// <summary>
    /// Uses Collections to implement a movie search.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Contains the basic properties for a Movie.
        /// </summary>
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Ratings { get; set; }
    }

    public class Movie_Stock
    {
        public static List<Movie> MovieList = new List<Movie>();

        public static void Main(String[] args)
        {
            // Adding movies using comma-separated input
            // This simulates user input
            AddMovie("Titanic,Leonardo DiCaprio,Romance,9");
            AddMovie("Inception,Leonardo DiCaprio,SciFi,8");
            AddMovie("Avatar,Sam Worthington,SciFi,7");

            // Movie get by Genre
            string genre = "SciFi";
            List<Movie> genreMovies = ViewMoviesByGenre(genre);
            if (genreMovies.Count == 0)
            {
                Console.WriteLine("No movie found");
            }
            else
            {
                foreach (Movie m in genreMovies)
                {
                    Console.WriteLine($"{m.Title} :  {m.Artist}");
                }
            }

            List<Movie> MovieByRatings = SortedMovies();
            foreach (Movie m in MovieByRatings)
            {
                Console.WriteLine($"{m.Title} : {m.Ratings}");
            }
        }

        public static void AddMovie(string MovieDetails)
        {
            string[] data = MovieDetails.Split(",");
            Movie movie = new Movie();
            movie.Title = data[0];
            movie.Artist = data[1];
            movie.Genre = data[2];
            movie.Ratings = int.Parse(data[3]);
            MovieList.Add(movie);
        }

        public static List<Movie> ViewMoviesByGenre(string genre)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie m in MovieList)
            {
                if (m.Genre.Equals(genre))
                {
                    result.Add(m);
                }
            }
            return result;
        }

        public static List<Movie> SortedMovies()
        {
            return MovieList.OrderByDescending(m => m.Ratings).ToList();
        }
    }
}
