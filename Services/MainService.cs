using ContextExample.Data;
using System;

namespace ContextExample.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IContext _context;

    public MainService(IContext context)
    {
        _context = context;
    }

    public void Invoke()
    {
        // provide an option to the user to 
        // 1. select by id
        // 2. select by title 
        // 3. find movie by title

        while (true)
        {
            Console.WriteLine("Enter the corresponding #: \n\t1. Get by Id\n\t2. Get by Title\n\t3. Find movie");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Enter the Id: ");
                var inputId = Console.ReadLine();
                var id = int.Parse(inputId);
                var movie = _context.GetById(id);
                Console.WriteLine($"Your movie is {movie.Title}");
            }
            else if (input == "2")
            {
                Console.WriteLine("Enter the title: ");
                var title = Console.ReadLine();
                var movie = _context.GetByTitle(title);
                Console.WriteLine($"Your movie is {movie.Title}");
            }
            else if (input == "3")
            {
                Console.WriteLine("Enter the movie: ");
                var inputMovie = Console.ReadLine();
                var movie = _context.FindMovie(inputMovie);
                Console.WriteLine("List movies: ");
                foreach (var moviesMovie in movie)
                {
                    Console.WriteLine($"Your movie is Id: {moviesMovie.Id} -- {moviesMovie.Title}");
                }
            }
        }
        
    }
}
