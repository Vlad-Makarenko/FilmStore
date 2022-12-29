using FilmData.Models;
namespace FilmStore;
class Program
{
    static void Main()
    {
        Menu();
        Console.WriteLine("Finish");
    }

    static void Menu()
    {
        FilmLibrary filmLibrary = new FilmLibrary();
        filmLibrary.AddFilm("First", "Producer", "netflix", 110, Genre.Comedy);
        filmLibrary.AddFilm("Second", "Author", "HBO Max", 90, Genre.Drama);
        while (true)
        {
            Console.WriteLine("Choose option: ");
            Console.WriteLine("1. Add new film ");
            Console.WriteLine("2. Show all films ");
            Console.WriteLine("3. Find film ");
            Console.WriteLine("4. Remove film ");
            Console.WriteLine("0. Exit ");
            Console.Write("Your option: ");
            string option = Console.ReadKey().Key.ToString();
            Console.WriteLine("\n");
            switch (option)
            {
                case "D1":
                    Console.WriteLine("How many movies do you want to add?");
                    int count = Convert.ToInt32(Console.ReadLine());
                    if (count < 1 || count > 10)
                    {
                        Console.WriteLine("Invalid value");
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(
                                "Input film data in format: \n Name\n Producer\n Streaming service\n Price\n Genre\n");
                            string name = Console.ReadLine();
                            string producer = Console.ReadLine();
                            string streamingService = Console.ReadLine();
                            string price = Console.ReadLine();
                            string genre = Console.ReadLine();
                            filmLibrary.AddFilm(name, producer, streamingService, Convert.ToInt32(price),
                                Enum.Parse<Genre>(genre, true));
                        }
                    }
                    break;
                case "D2":
                    filmLibrary.Information();
                    Console.WriteLine("");
                    break;
                case "D3":
                    Console.WriteLine("Choose search option: ");
                    Console.WriteLine("1. Name ");
                    Console.WriteLine("2. Genre ");
                    Console.WriteLine("3. Price ");
                    Console.Write("Your option: ");
                    string srchOption = Console.ReadKey().Key.ToString();
                    Console.WriteLine("\n");
                    switch (srchOption)
                    {
                        case "D1":
                            Console.WriteLine("Input film Name:");
                            string srchName = Console.ReadLine();
                            List<Film> resultName = filmLibrary.FindFilm(srchName);
                            if (resultName.Count == 0) Console.WriteLine("Nothing Found");
                            foreach (Film film in resultName)
                            {
                                film.Information();
                            }
                            Console.WriteLine("");
                            break;
                        case "D2":
                            Console.WriteLine("Input film Genre:");
                            string srchGenre = Console.ReadLine();
                            List<Film> resultGenre = filmLibrary.FindFilm(Enum.Parse<Genre>(srchGenre, true));
                            if (resultGenre.Count == 0) Console.WriteLine("Nothing Found");
                            foreach (Film film in resultGenre)
                            {
                                film.Information();
                            }
                            Console.WriteLine("");
                            break;
                        case "D3":
                            Console.WriteLine("Input film Price:");
                            string srchPrice = Console.ReadLine();
                            List<Film> resultPrice = filmLibrary.FindFilm(Convert.ToInt32(srchPrice));
                            if (resultPrice.Count == 0) Console.WriteLine("Nothing Found");
                            foreach (Film film in resultPrice)
                            {
                                film.Information();
                            }
                            Console.WriteLine("");
                            break;
                    }

                    break;
                case "D4":
                    Console.WriteLine("Choose delete option: ");
                    Console.WriteLine("1. By Id ");
                    Console.WriteLine("2. By Name ");
                    Console.Write("Your option: ");
                    string deleteOption = Console.ReadKey().Key.ToString();
                    Console.WriteLine("\n");
                    switch (deleteOption)
                    {
                        case "D1":
                            Console.WriteLine("Input film Id:");
                            string deleteId = Console.ReadLine();
                            bool isDeletedId = filmLibrary.RemoveFilm(Convert.ToInt32(deleteId));
                            if (!isDeletedId) Console.WriteLine("Nothing Found\n");
                            else Console.WriteLine("Film was deleted\n");
                            break;
                        case "D2":
                            Console.WriteLine("Input film Name:");
                            string deleteName = Console.ReadLine();
                            bool isDeletedName = filmLibrary.RemoveFilm(deleteName);
                            if (!isDeletedName) Console.WriteLine("Nothing Found\n");
                            else Console.WriteLine("Film was deleted\n");
                            break;
                    }
                    break;
                case "D0":
                    return;
            }
        }
    }
}