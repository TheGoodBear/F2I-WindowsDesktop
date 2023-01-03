using MauiSample.Models;
using System.Collections.ObjectModel;

namespace MauiSample.ViewModels;

internal class AnimalVM
{

    // view properties
    public string Title { get; set; }
    public string FormTitle { get; set; }
    public string FormMessage { get; set; } = "";
    public string FormMessageClass { get; set; } = "";
    public string AddAnimalFromPoolText { get; set; } = "";
    public bool AddAnimalFromPoolDisabled { get; set; }

    // data properties
    public Collection<Animal> Animals { get; set; }
    public Animal AnimalModel { get; set; } = new Animal();
    private static List<Tuple<string, string>> AnimalPool =
        new List<Tuple<string, string>>();


    public AnimalVM()
    {

        Animal.InitializeData();
        Animals = Animal.Animals;

        FormTitle = "Ajouter un animal";

        CreateAnimalPool();
        UpdateData();

    }


    public void AddAnimal()
    {

        Animal NewAnimal = this.AnimalModel;
        if (NewAnimal.Name != null)
        {
            new Animal(NewAnimal.Name, NewAnimal.Description);
            FormMessage = "L'animal a été ajouté";
            FormMessageClass = "text-success";
        }
        else
        {
            FormMessage = "Merci de rentrer un nom pour l'animal";
            FormMessageClass = "text-danger";
        }
        AnimalModel = new Animal();
        UpdateData();

    }


    public void AddAnimalFromPool()
    {

        if (AnimalPool.Count > 0) 
        {
            new Animal(AnimalPool[0].Item1, AnimalPool[0].Item2);
            AnimalPool.RemoveAt(0);
            FormMessage = "L'animal a été ajouté depuis la réserve";
            FormMessageClass = "text-success";
            UpdateData();
        }

    }


    private void UpdateData()
    {

        Title = $"Liste des {Animals.Count} animaux";

        AddAnimalFromPoolText =
            AnimalPool.Count > 0
            ? $"Ajouter un animal depuis la réserve ({AnimalPool.Count} restant(s))"
            : $"Aucun animal disponible";

        AddAnimalFromPoolDisabled = 
            AnimalPool.Count > 0 
            ? false 
            : true;

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
