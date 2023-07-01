using System;

class Student
{
    // Свойства студента
    public string LastName { get; set; }
    public string FirstName { get; set; }
    private string Patronymic { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    private string Phone { get; set; }
    public string Faculty { get; set; }
    public int Course { get; set; }

    // Конструктор класса Student
    public Student(string lastName, string firstName, string patronymic, DateTime birthDate, string address, string phone, string faculty, int course)
    {
        LastName = lastName;
        FirstName = firstName;
        Patronymic = patronymic;
        BirthDate = birthDate;
        Address = address;
        Phone = phone;
        Faculty = faculty;
        Course = course;
    }

    // Метод вывода информации о студенте
    public void Show()
    {
        Console.WriteLine("Фамилия: " + LastName);
        Console.WriteLine("Имя: " + FirstName);
        Console.WriteLine("Отчество: " + Patronymic);
        Console.WriteLine("Дата рождения: " + BirthDate.ToShortDateString());
        Console.WriteLine("Адрес: " + Address);
        Console.WriteLine("Телефон: " + Phone);
        Console.WriteLine("Факультет: " + Faculty);
        Console.WriteLine("Курс: " + Course);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Создание массива объектов Student
        Student[] students = new Student[5];
        students[0] = new Student("Иванов", "Иван", "Иванович", new DateTime(1995, 10, 15), "Москва", "123456789", "Факультет 1", 2);
        students[1] = new Student("Петров", "Петр", "Петрович", new DateTime(1998, 5, 20), "Санкт-Петербург", "987654321", "Факультет 2", 3);
        students[2] = new Student("Сидорова", "Анна", "Алексеевна", new DateTime(1997, 7, 1), "Москва", "456789123", "Факультет 1", 1);
        students[3] = new Student("Смирнов", "Алексей", "Игоревич", new DateTime(1996, 3, 10), "Санкт-Петербург", "321654987", "Факультет 3", 2);
        students[4] = new Student("Козлов", "Дмитрий", "Сергеевич", new DateTime(1997, 12, 5), "Москва", "654789321", "Факультет 2", 1);

        // Вывод списка студентов заданного факультета
        string facultyToSearch = "Факультет 1";
        Console.WriteLine("Студенты факультета " + facultyToSearch + ":");
        foreach (Student student in students)
        {
            if (student.Faculty == facultyToSearch)
            {
                student.Show();
            }
        }

        // Вывод списков студентов для каждого факультета и курса
        Console.WriteLine("Списки студентов для каждого факультета и курса:");
        foreach (Student student in students)
        {
            Console.WriteLine("Факультет: " + student.Faculty + ", Курс: " + student.Course);
            student.Show();
        }

        // Вывод списка студентов, родившихся после заданного года
        int yearToSearch = 1997;
        Console.WriteLine("Студенты, родившиеся после " + yearToSearch + " года:");
        foreach (Student student in students)
        {
            if (student.BirthDate.Year > yearToSearch)
            {
                student.Show();
            }
        }

        Console.ReadLine();
    }
}

