using System;

// Абстрактный базовый класс
abstract class Person
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public int StartYear { get; set; }
    public decimal BaseSalary { get; set; }

    public abstract decimal CalculateSalary(); // Абстрактный метод

    public virtual void PrintDetails() // Виртуальный метод
    {
        Console.WriteLine("Full Name: " + FullName);
        Console.WriteLine("Birth Year: " + BirthYear);
        Console.WriteLine("Start Year: " + StartYear);
        Console.WriteLine("Base Salary: " + BaseSalary);
    }
}

// Производный класс для испытания
class ExamPerson : Person
{
    public decimal ExamBonus { get; set; }

    public override decimal CalculateSalary() // Реализация абстрактного метода
    {
        return BaseSalary + ExamBonus;
    }

    public override void PrintDetails() // Переопределение виртуального метода
    {
        base.PrintDetails();
        Console.WriteLine("Exam Bonus: " + ExamBonus);
    }
}

// Производный класс для экзамена
class TestPerson : Person
{
    public decimal TestBonus { get; set; }

    public override decimal CalculateSalary() // Реализация абстрактного метода
    {
        return BaseSalary + TestBonus;
    }

    public override void PrintDetails() // Переопределение виртуального метода
    {
        base.PrintDetails();
        Console.WriteLine("Test Bonus: " + TestBonus);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ExamPerson examPerson = new ExamPerson()
        {
            FullName = "John Doe",
            BirthYear = 1990,
            StartYear = 2015,
            BaseSalary = 2000,
            ExamBonus = 500
        };

        TestPerson testPerson = new TestPerson()
        {
            FullName = "Jane Smith",
            BirthYear = 1995,
            StartYear = 2017,
            BaseSalary = 2500,
            TestBonus = 700
        };

        examPerson.PrintDetails();
        Console.WriteLine("Salary: " + examPerson.CalculateSalary());

        Console.WriteLine();

        testPerson.PrintDetails();
        Console.WriteLine("Salary: " + testPerson.CalculateSalary());
    }
}
