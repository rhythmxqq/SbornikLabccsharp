using System;

public class Collection
{
    public string Name { get; set; }
    public string Owner { get; set; }
}

public class MusicAlbum
{
    public string Author { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public int TotalDuration { get; set; }

    public void GetDescription()
    {
        Console.WriteLine($"Author/Group: {Author}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Total Duration: {TotalDuration} minutes");
    }
}

public class MusicComposition
{
    private string title;
    public string Title
    {
        get { return title; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NazvanieException("Title cannot be null or empty."); // Проверка значения свойства "Название" и выброс исключения типа NazvanieException, если значение равно null или пустой строке
            }
            title = value;
        }
    }

    public int Duration { get; set; }

    public virtual void GetDescription()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Duration: {Duration} minutes");
    }

    public MusicComposition(string title, int duration)
    {
        try
        {
            Title = title; // Инициализация свойства "Название" с помощью сеттера, который проверяет корректность значения
            Duration = duration;
        }
        catch (NazvanieException ex)
        {
            Console.WriteLine("Error: " + ex.Message); // Вывод сообщения об ошибке, если произошло исключение типа NazvanieException
            throw new NazvanieException("Title cannot be null or empty."); // Повторное создание исключения для корректного завершения создания объекта
        }
    }
}

public class Song : MusicComposition
{
    public string Lyrics { get; set; }
    public string Lyricist { get; set; }

    public override void GetDescription()
    {
        base.GetDescription();
        Console.WriteLine($"Lyrics: {Lyrics}");
        Console.WriteLine($"Lyricist: {Lyricist}");
    }

    public Song(string title, int duration, string lyrics, string lyricist)
        : base(title, duration)
    {
        Lyrics = lyrics;
        Lyricist = lyricist;
    }
}

public class InstrumentalComposition : MusicComposition
{
    public string Instruments { get; set; }

    public override void GetDescription()
    {
        base.GetDescription();
        Console.WriteLine($"Instruments: {Instruments}");
    }

    public InstrumentalComposition(string title, int duration, string instruments)
        : base(title, duration)
    {
        Instruments = instruments;
    }
}

public class NazvanieException : Exception
{
    public NazvanieException(string message) : base(message)
    {
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Collection myCollection = new Collection
        {
            Name = "My Music Collection",
            Owner = "John Doe"
        };

        MusicAlbum album = new MusicAlbum
        {
            Author = "Artist/Band Name",
            Genre = "Rock",
            Year = 2021,
            TotalDuration = 60
        };

        try
        {
            Song song = new Song(null, 4, "Song Lyrics", "Lyricist Name"); // Попытка создания объекта Song с недопустимым значением для свойства "Название"
        }
        catch (NazvanieException ex)
        {
            Console.WriteLine("Error: " + ex.Message); // Вывод сообщения об ошибке, если произошло исключение типа NazvanieException
        }

        try
        {
            InstrumentalComposition instrumental = new InstrumentalComposition("", 3, "Guitar, Drums, Piano"); // Попытка создания объекта InstrumentalComposition с недопустимым значением для свойства "Название"
        }
        catch (NazvanieException ex)
        {
            Console.WriteLine("Error: " + ex.Message); // Вывод сообщения об ошибке, если произошло исключение типа NazvanieException
        }
    }
}

