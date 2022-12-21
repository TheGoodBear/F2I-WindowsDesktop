using System.Collections.ObjectModel;
using UWPSample2.Models;
using WpfSample2.Utilities;

namespace WpfSample2.ViewModels;

internal class MainVM
{

    // view properties
    public string Title { get; set; }


    // models properties
    public ObservableCollection<Animal> Animals { get; set; } 


    // constructor
    public MainVM() 
    {
        Animals = GlobalVariables.InitializeData();

        this.Title = $"Liste des {Animals.Count} animaux"; ;
    }

}
