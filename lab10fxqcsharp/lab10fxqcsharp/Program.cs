using System;
using System.IO;

abstract class Person
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public int StartYear { get; set; }
    public decimal BaseSalary { get; set; }

    public abstract decimal CalculateSalary();

    public virtual void PrintDetails()
    {
        Console.WriteLine("Full Name: " + FullName);
        Console.WriteLine("Birth Year: " + BirthYear);
        Console.WriteLine("Start Year: " + StartYear);
        Console.WriteLine("Base Salary: " + BaseSalary);
    }
}

interface IBonusCalculable
{
    decimal CalculateBonus();
}

class ExamPerson : Person, IBonusCalculable
{
    public decimal ExamBonus { get; set; }

    public override decimal CalculateSalary() => BaseSalary + ExamBonus;

    public decimal CalculateBonus() => ExamBonus;

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine("Exam Bonus: " + ExamBonus);
    }
}

class TestPerson : Person, IBonusCalculable
{
    public decimal TestBonus { get; set; }

    public override decimal CalculateSalary() => BaseSalary + TestBonus;

    public decimal CalculateBonus() => TestBonus;

    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine("Test Bonus: " + TestBonus);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] people = LoadObjectsFromFile("/Users/mak/Projects/lab10fxqcsharp/lab10fxqcsharp/data.txt");

        if (people != null)
        {
            foreach (var person in people)
            {
               person.PrintDetails();

                if (person is IBonusCalculable bonusCalculable)
                    Console.WriteLine("Bonus: " + bonusCalculable.CalculateBonus());

                Console.WriteLine("Salary: " + person.CalculateSalary());
                Console.WriteLine();
            }
        }
    }

    static Person[] LoadObjectsFromFile(string fileName)
    {
        try
        {
            string[] lines = File.Exists(fileName) ? File.ReadAllLines(fileName) : new string[0];
            Person[] people = new Person[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(';');

                Person person = data[0] switch
                {
                    nameof(ExamPerson) => CreateExamPerson(data),
                    nameof(TestPerson) => CreateTestPerson(data),
                    _ => null
                };

                people[i] = person;
            }

            Console.WriteLine("Objects loaded from file successfully.");
            return people;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found: " + fileName);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred while loading objects: " + e.Message);
        }

        return null;
    }

    static ExamPerson CreateExamPerson(string[] data)
    {
        if (data.Length >= 6 && decimal.TryParse(data[5], out decimal examBonus))
        {
            return new ExamPerson
            {
                FullName = data[1],
                BirthYear = int.Parse(data[2]),
                StartYear = int.Parse(data[3]),
                BaseSalary = decimal.Parse(data[4]),
                ExamBonus = examBonus
            };
        }

        return null;
    }

    static TestPerson CreateTestPerson(string[] data)
    {
        if (data.Length >= 6 && decimal.TryParse(data[5], out decimal testBonus))
        {
            return new TestPerson
            {
                FullName = data[1],
                BirthYear = int.Parse(data[2]),
                StartYear = int.Parse(data[3]),
                BaseSalary = decimal.Parse(data[4]),
                TestBonus = testBonus
            };
        }

        return null;
    }
}
