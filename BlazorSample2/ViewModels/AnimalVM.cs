using BlazorSample2.Models;
using BlazorSample2.Utilities;

namespace BlazorSample2.ViewModels;

internal class AnimalVM
{

    // view properties
    public string Title { get; set; }
    public string FormVisibility { get; set; } = "ControlInvisible";
    public string FormTitle { get; set; } = "";
    public string FormMessage { get; set; } = "";
    public string FormMessageClass { get; set; } = "";
    public string AddAnimalFromPoolText { get; set; } = "";
    public bool AddAnimalFromPoolDisabled { get; set; }

    // data properties
    public List<Animal> Animals { get; set; }
    public Animal AnimalModel { get; set; } = new Animal();
    private static List<Tuple<string, string>> AnimalPool =
        new List<Tuple<string, string>>();


    // constructor
    public AnimalVM()
    {

        Animals = DBUtil.Animals;

        CreateAnimalPool();
        UpdateData();

    }

    public void Cancel()
    {

        // reset form fields
        AnimalModel = new Animal();

        // update form
        FormVisibility = "ControlInvisible";
        FormTitle = "";
        FormMessage = "";

    }


    public void Add()
    {

        // reset form fields
        AnimalModel = new Animal();

        // update form
        FormVisibility = "";
        FormTitle = "Ajouter un animal";
        FormMessage = "";

    }


    public void Edit(int ID)
    {

        // find selected animal and update form fields
        AnimalModel = DBUtil.Animals
            .Find(p => p.ID == ID);

        // update form
        FormVisibility = "";
        FormTitle = "Modifier l'animal";
        FormMessage = "";

    }


    public async Task Delete(int ID)
    {

        // find selected animal 
        Animal CurrentAnimal = DBUtil.Animals
            .Find(p => p.ID == ID);

        // make action
        await DBUtil.DeleteAnimal(CurrentAnimal);

        // update form
        FormVisibility = "ControlInvisible";
        FormMessage = $"L'animal {CurrentAnimal.Name} a été supprimé";
        DBUtil.Animals.Remove(CurrentAnimal);
        UpdateData();

    }


    public async Task ValidateAnimal()
    {

        Animal CurrentAnimal = AnimalModel;

        if (string.IsNullOrEmpty(CurrentAnimal.Name))
        {
            // model not valid
            FormMessage = "Merci de rentrer un nom pour l'animal";
            FormMessageClass = "text-danger";
            return;
        }

        if (AnimalModel.ID != 0)
        {
            // make action
            FormMessage = "L'animal a été modifié";
            await DBUtil.UpdateAnimal(CurrentAnimal);
        }
        else
        {
            // make action
            FormMessage = "L'animal a été ajouté";
            await DBUtil.CreateAnimal(CurrentAnimal);
        }

        FormMessageClass = "text-success";

        // reset form
        FormVisibility = "ControlInvisible";
        FormTitle = "";
        AnimalModel = new Animal();

        UpdateData();

    }


    public async Task AddFromPool()
    {

        if (AnimalPool.Count > 0) 
        {
            Animal NewAnimal = new Animal(AnimalPool[0].Item1, AnimalPool[0].Item2);
            AnimalPool.RemoveAt(0);
            await DBUtil.CreateAnimal(NewAnimal);
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
