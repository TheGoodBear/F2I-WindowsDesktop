using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPSample2.Models;
using WpfSample2.ViewModels;

namespace WpfSample2.Utilities;

internal static class GlobalVariables
{

    public static ObservableCollection<Animal> Animals =
        new ObservableCollection<Animal>();


    public static ObservableCollection<Animal> InitializeData()
    {
        Animals.Add(new Animal("Lapin", "Doux avec des grandes oreilles"));
        Animals.Add(new Animal("Chat", "Doux avec des petites oreilles, fait miaou"));
        Animals.Add(new Animal("Chien", "Fait wafwaf"));
        Animals.Add(new Animal("Cochon", "Rose et fait gruic"));
        Animals.Add(new Animal("Mésange", "Vole"));
        Animals.Add(new Animal("Serpent", "Rampe"));
        Animals.Add(new Animal("Chèvre", "Mange tout même les ronces"));

        return Animals;
    }


}
