using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSample.Models;

internal class Animal
{
    // static properties
    private static int NextID = 1;
    public static ObservableCollection<Animal> Animals = new ObservableCollection<Animal>();

    // properties
    public int ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageLink { get; set; }
    public int? IDCountry { get; set; }


    // constructor
    public Animal(
        string Name,
        string? Description = null,
        string? ImageLink = null,
        int? IDCountry = null) 
    { 
        this.ID = NextID;
        this.Name = Name;
        this.Description = Description; 
        this.ImageLink = ImageLink;
        this.IDCountry = IDCountry;

        NextID++;

        Animals.Add(this);
    }


    // methods
    public override string ToString() 
        => $"({ID}) {Name} → {Description}";
    //public override string ToString()
    //{
    //    return $"({ID}) {Name} → {Description}";
    //}


    public static void InitializeData()
    {
        new Animal("Lapin", "Doux avec des grandes oreilles");
        new Animal("Chat", "Doux avec des petites oreilles, fait miaou");
        new Animal("Chien", "Fait wafwaf");
        new Animal("Cochon", "Rose et fait gruic");
        new Animal("Mésange", "Vole");
        new Animal("Serpent", "Rampe");
        new Animal("Chèvre", "Mange tout même les ronces");
    }

}
