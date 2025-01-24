




List<Person> persons = new()
{
    new() { FirstName = "Виталий", LastName = "Цаль", Age = 33 },
    new() { FirstName = "Куджо", LastName = "Джотаро", Age = 40 },
    new() { FirstName = "Юрий", LastName = "Хованский", Age = 34 },
    new() { FirstName = "Михаил", LastName = "Петров", Age = 15 },
    new() { FirstName = "Виталий", LastName = "Гачиев", Age = 40 },
    new() { FirstName = "Юрий", LastName = "Гагарин", Age = 34 },
};



List<Person> FilterPersons(
    List<Person> all,
    string? firstName = null,
    string? lastName = null,
    int? age = null) 
{
    IEnumerable<Person> query = all;

    if (!string.IsNullOrEmpty(firstName))    // я мог написать используя 'if (string.IsNullOrEmpty(firstName) == false)'
                                             // но мне гпт показал этот прикол с восклицательным знаком и мне он как-то покрасивше показалсяя
    {
        query = query.Where(p => p.FirstName == firstName);
    }
    
    if (!string.IsNullOrEmpty(lastName))
    {
        query = query.Where(p => p.LastName == lastName);
    }

    if (age.HasValue)
    {
        query = query.Where(p => p.Age == age.Value);
    }

    return query.ToList();
}

//пример вывода по заданию
var filtered1 = FilterPersons(persons, firstName: "Виталий", age: 40);
foreach (var person in filtered1)
{
    Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age);
}

var filtered2 = FilterPersons(persons, firstName: "Юрий", age: 34);
foreach (var person in filtered2)
{
    Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age);
}

var filtered3 = FilterPersons(persons, lastName: "Джотаро");
foreach (var person in filtered3)
{
    Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.Age);
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}