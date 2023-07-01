using System;
// Интерфейс "Издательство"
interface IPublisher
{
    string Title { get; set; }
    string Author { get; set; }

    void DisplayInfo();
}

interface IBook : IPublisher
{
    DateTime PublicationDate { get; set; }
    int Pages { get; set; }

    void DisplayInfo();
}

class Book : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Pages { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine("Информация о книге:");
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Дата публикации: {PublicationDate}");
        Console.WriteLine($"Количество страниц: {Pages}");
    }
}

interface IUser
{
    string Login { get; set; }
    string Password { get; set; }

    void DisplayInfo();
}

class User : IUser
{
    public string Login { get; set; }
    public string Password { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine("Информация о пользователе:");
        Console.WriteLine($"Логин: {Login}");
        Console.WriteLine($"Пароль: {Password}");
    }
}

class ProductUser : IBook, IUser
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Pages { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine("Информация о товаре и пользователе:");
        Console.WriteLine($"Название товара: {Title}");
        Console.WriteLine($"Автор товара: {Author}");
        Console.WriteLine($"Дата публикации товара: {PublicationDate}");
        Console.WriteLine($"Количество страниц товара: {Pages}");
        Console.WriteLine($"Логин пользователя: {Login}");
        Console.WriteLine($"Пароль пользователя: {Password}");
    }

    public void BuyBook()
    {
        Console.WriteLine($"Пользователь с логином {Login} купил книгу {Title}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        IBook book1 = new Book
        {
            Title = "Книга 1",
            Author = "Автор 1",
            PublicationDate = new DateTime(2022, 1, 1),
            Pages = 200
        };

        IBook book2 = new Book
        {
            Title = "Книга 2",
            Author = "Автор 2",
            PublicationDate = DateTime.Parse("01.02.2023"),
            Pages = 150
        };
        
        IUser user1 = new User
        {
            Login = "user1",
            Password = "password1"
        };

       
        IUser user2 = new User
        {
            Login = "user2",
            Password = "password2"
        };

  
        ProductUser productUser = new ProductUser
        {
            Title = "Книга 3",
            Author = "Автор 3",
            PublicationDate = new DateTime(2021, 12, 31),
            Pages = 300,
            Login = "user3",
            Password = "password3"
        };

        book1.DisplayInfo();


        book2.DisplayInfo();

     
        user1.DisplayInfo();

        user2.DisplayInfo();

        productUser.DisplayInfo();


        productUser.BuyBook();

        Console.ReadLine();
    }


}