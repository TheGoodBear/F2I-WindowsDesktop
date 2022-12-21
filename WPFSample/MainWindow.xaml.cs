using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using UWPSample.Models;

namespace WPFSample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private static int? SelectedAnimalID = null;


    public MainWindow()
    {
        InitializeComponent();

        Animal.InitializeData();

        lblTitle.Text = $"Liste des {Animal.Animals.Count} animaux";
        lstAnimals.ItemsSource = Animal.Animals;

        // LINQ
        //Animal MyAnimal = Animal.Animals.First(p => p.ID == 3);
        //lblTitle.Text = $"({MyAnimal.ID}) {MyAnimal.Name} → {MyAnimal.Description}";

    }


    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {

        if (txtName.Text != "")
        {
            new Animal(txtName.Text, txtDescription.Text);
            lblStatus.Foreground = new SolidColorBrush(Colors.CadetBlue);
            lblStatus.Text = $"L'animal {txtName.Text} a été ajouté";
            //MessageBox.Show($"L'animal {txtName.Text} a été ajouté");
        }
        else
        {
            lblStatus.Foreground = new SolidColorBrush(Colors.DarkRed);
            lblStatus.Text = "Il faut rentrer le nom d'un animal";
        }

    }


    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {
        
        Animal SelectedAnimal = Animal.Animals
            .First(p => p.ID == SelectedAnimalID);

        if (txtName.Text != "")
        {
            SelectedAnimal.Name = txtName.Text;
            SelectedAnimal.Description = txtDescription.Text;
            lblStatus.Foreground = new SolidColorBrush(Colors.CadetBlue);
            lblStatus.Text = $"L'animal {txtName.Text} a été modifié";
        }
        else
        {
            lblStatus.Foreground = new SolidColorBrush(Colors.DarkRed);
            lblStatus.Text = "Il faut rentrer le nom d'un animal";
        }

    }


    private void lstAnimals_SelectionChanged(
        object sender, 
        SelectionChangedEventArgs e)
    {

        ListView Mylist = (ListView)sender;
        Animal MyAnimal = (Animal)Mylist.SelectedItem;

        SelectedAnimalID = MyAnimal.ID;
        txtName.Text = MyAnimal.Name;
        txtDescription.Text = MyAnimal.Description;

    }
}
