using MauiSample.Models;
using System.Collections.ObjectModel;

namespace MauiSample.ViewModels;

internal class AnimalVM
{

    public string Title { get; set; }

    public Collection<Animal> Animals { get; set; }


    public AnimalVM()
    {
        Animal.InitializeData();
        Animals = Animal.Animals;

		Title = $"Liste des {Animals.Count} animaux";

    }

}
