using System;
using System.Collections.Generic;
using System.Reflection;

public class Crocodile
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Length { get; set; }
    public int Age { get; set; }
    public string Sex { get; set; }
    public Crocodile(string name, double weight, double length, int age, string sex)
    {
        Name = name;
        Weight = weight;
        Length = length;
        Age = age;
        Sex = sex;
    }
    public override string ToString()
    {
        return $"Имя: {Name}, Вес: {Weight} кг, Длина: {Length} м, Возраст: {Age} лет, Пол: {Sex}";
    }
}
public class CrocodileService
{
    private List<Crocodile> crocodiles = new List<Crocodile>();

    public void CreateCrocodile(string name, double weight, double length, int age, string sex)
    {
        Crocodile croc = new Crocodile(name, weight, length, age, sex);
        crocodiles.Add(croc);
        Console.WriteLine($"Добавлен новый крокодил: {croc}");
    }

    public void PrintAllCrocodiles()
    {
        if (crocodiles.Count == 0)
        {
            Console.WriteLine("В коллекции нет крокодилов.");
            return;
        }

        Console.WriteLine("Список всех крокодилов:");
        foreach (var croc in crocodiles)
        {
            Console.WriteLine(croc);
        }
    }

    public void FindCrocodilesLongerThan(double minLength)
    {
        var result = crocodiles.FindAll(c => c.Length > minLength);

        if (result.Count == 0)
        {
            Console.WriteLine($"Нет крокодилов длиннее {minLength} м.");
            return;
        }

        Console.WriteLine($"Крокодилы длиннее {minLength} м:");
        foreach (var croc in result)
        {
            Console.WriteLine(croc);
        }
    }

    public void FindOldestCrocodile()
    {
        if (crocodiles.Count == 0)
        {
            Console.WriteLine("В коллекции нет крокодилов.");
            return;
        }

        Crocodile oldest = crocodiles[0];
        foreach (var croc in crocodiles)
        {
            if (croc.Age > oldest.Age)
            {
                oldest = croc;
            }
        }

        Console.WriteLine($"Самый старый крокодил: {oldest}");
    }

    public void FindHeaviestCrocodile()
    {
        if (crocodiles.Count == 0)
        {
            Console.WriteLine("В коллекции нет крокодилов.");
            return;
        }

        Crocodile heaviest = crocodiles[0];
        foreach (var croc in crocodiles)
        {
            if (croc.Weight > heaviest.Weight)
            {
                heaviest = croc;
            }
        }

        Console.WriteLine($"Самый тяжелый крокодил: {heaviest}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        CrocodileService service = new CrocodileService();

        service.CreateCrocodile("Кроки", 120.5, 2.3, 15, "мужской");
        service.CreateCrocodile("Роки", 95.2, 1.9, 12, "женский");
        service.CreateCrocodile("Мини", 150.8, 2.7, 20, "мужской");
        service.CreateCrocodile("Мони", 88.3, 1.8, 10, "женский");
        service.CreateCrocodile("Рекс", 180.1, 3.1, 25, "мужской");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Вывести всех крокодилов");
            Console.WriteLine("2. Найти крокодилов длиннее заданного значения");
            Console.WriteLine("3. Найти самого старого крокодила");
            Console.WriteLine("4. Найти самого тяжелого крокодила");
            Console.WriteLine("5. Добавить нового крокодила");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    service.PrintAllCrocodiles();
                    break;
                case "2":
                    Console.Write("Введите минимальную длину (м): ");
                    if (double.TryParse(Console.ReadLine(), out double length))
                    {
                        service.FindCrocodilesLongerThan(length);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод!");
                    }
                    break;
                case "3":
                    service.FindOldestCrocodile();
                    break;
                case "4":
                    service.FindHeaviestCrocodile();
                    break;
                case "5":
                    AddNewCrocodile(service);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор!");
                    break;
            }
        }
    }

    static void AddNewCrocodile(CrocodileService service)
    {
        Console.WriteLine("\nДобавление нового крокодила:");

        Console.Write("Имя: ");
        string name = Console.ReadLine();

        Console.Write("Вес (кг): ");
        if (!double.TryParse(Console.ReadLine(), out double weight))
        {
            Console.WriteLine("Некорректный ввод веса!");
            return;
        }

        Console.Write("Длина (м): ");
        if (!double.TryParse(Console.ReadLine(), out double length))
        {
            Console.WriteLine("Некорректный ввод длины!");
            return;
        }

        Console.Write("Возраст (лет): ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Некорректный ввод возраста!");
            return;
        }

        Console.Write("Пол (мужской/женский): ");
        string sex = Console.ReadLine();

        service.CreateCrocodile(name, weight, length, age, sex);
    }
}
