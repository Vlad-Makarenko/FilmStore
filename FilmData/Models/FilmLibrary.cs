namespace FilmData.Models;

using System.Collections.Generic;

public class FilmLibrary
{
    private int _idIncrement = 1;
    public List<Film> Films { get; set; }

    public FilmLibrary()
    {
        this.Films = new List<Film>();
    }

    public void AddFilm(string name, string producer, string streamingService, int price, Genre genre)
    {
        try
        {
            Films.Add(new Film(_idIncrement, name, producer, streamingService, price, genre));
            _idIncrement++;
            Console.WriteLine("Film added!\n"); // Напевно це зайве? 
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message + "\n");
        }
    }

    public List<Film> FindFilm(string name)
    {
        return Films.FindAll(item => item.Name == name);
    }

    public List<Film> FindFilm(Genre genre)
    {
        return Films.FindAll(item => item.Genre == genre);
    }

    public List<Film> FindFilm(int price)
    {
        return Films.FindAll(item => item.Price == price);
    }

    public bool RemoveFilm(string name)
    {
        Film item = Films.SingleOrDefault(x => x.Name == name);
        if (item != null)
        {
            Films.Remove(item);
            return true;
        }
        return false;
    }

    public bool RemoveFilm(int id)
    {
        Film item = Films.SingleOrDefault(x => x.Id == id);
        if (item != null)
        {
            Films.Remove(item);
            return true;
        }
        return false;
    }

    public void Information()
    {
        foreach (Film film in Films)
        {
            film.Information();
        }
    }
}