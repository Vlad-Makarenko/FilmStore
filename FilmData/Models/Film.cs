namespace FilmData.Models;

using System;

public class Film
{
    private int _id;
    private int _rentalAmount = 0;
    private string _name;
    private string _producer;
    private string _streamingService;
    private int _price;
    private Genre? _genre;

    public int Id
    {
        get { return _id; }
        private set
        {
            if (value < 1)
            {
                throw new Exception("Invalid Id");
            }
            else _id = value;
        }
    }

    public string? Name
    {
        get { return _name; }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new Exception("Invalid Name");
            }
            else
            {
                _name = value;
            }
        }
    }

    public string? Producer
    {
        get { return _producer; }
        private set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new Exception("Invalid Producer");
            }
            else _producer = value;
        }
    }

    public string? StreamingService
    {
        get { return _streamingService; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new Exception("Invalid Streaming service");
            }
            else _streamingService = value;
        }
    }

    public int RentalAmount
    {
        get { return _rentalAmount; }
        set
        {
            if (value < _rentalAmount)
            {
                throw new Exception("Invalid Rental Amount");
            }
            else _rentalAmount = value;
        }
    }

    public int Price
    {
        get { return _price; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("Invalid Price");
            }
            else _price = value;
        }
    }

    public Genre? Genre
    {
        get { return _genre; }
        private set
        {
            if (!Enum.IsDefined(typeof(Genre), value))
            {
                throw new Exception("Invalid Genre");
            }
            else _genre = value;
        }
    }

    public Film(int id, string name, string producer, string streamingService, int price, Genre genre)
    {
        this.Id = id;
        this.Name = name;
        this.Producer = producer;
        this.StreamingService = streamingService;
        this.Price = price;
        this.Genre = genre;
    }

    public void Information()
    {
        this.RentalAmount += this.Price;
        Console.WriteLine("Id: " + Id + ". Name: " + Name + ". Producer: " + Producer + ". Streaming Service " +
                          StreamingService + ". Price: " + Price + ". Genre: " + Genre + ". Rental Amount: " +
                          _rentalAmount);
    }
}