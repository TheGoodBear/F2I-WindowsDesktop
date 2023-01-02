using MauiSample.Models;
using System.Collections.ObjectModel;

namespace MauiSample.ViewModels;

internal class AnimalVM
{

    private static List<Tuple<string, string>> AnimalPool = 
        new List<Tuple<string, string>>();

    public string Title { get; set; }

    public Collection<Animal> Animals { get; set; }


    public AnimalVM()
    {

        Animal.InitializeData();
        Animals = Animal.Animals;
        UpdateData();
        CreateAnimalPool();

    }


    public void AddAnimal()
    {

        if (AnimalPool.Count > 0) 
        {
            new Animal(AnimalPool[0].Item1, AnimalPool[0].Item2);
            AnimalPool.RemoveAt(0);
            UpdateData();
        }

    }


    private void UpdateData()
    {

        Title = $"Liste des {Animals.Count} animaux";

    }

    private void CreateAnimalPool()
    {
        AnimalPool.Add(new Tuple<string, string>
            ("Dauphin", "Mammifère marin"));
        AnimalPool.Add(new Tuple<string, string>
            ("Lièvre", "Court vite"));
        AnimalPool.Add(new Tuple<string, string>
            ("Tortue", "Se déplace avec lenteur"));
        AnimalPool.Add(new Tuple<string, string>
            ("Pie", "Oiseau voleur"));
    }

}
