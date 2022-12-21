using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UWPSample2.Models;
using WpfSample2.ViewModels;

namespace WpfSample2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    // class properties
    private MainVM VM = new MainVM();
    private static int? SelectedAnimalID = null;


    public MainWindow()
    {

        InitializeComponent();

        this.DataContext = VM;

        //VM = new MainVM();

    }


    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {

        if (txtName.Text != "")
        {
            VM.Animals.Add(new Animal(txtName.Text, txtDescription.Text));
            lblStatus.Foreground = new SolidColorBrush(Colors.CadetBlue);
            lblStatus.Text = $"L'animal {txtName.Text} a été ajouté";
        }
        else
        {
            lblStatus.Foreground = new SolidColorBrush(Colors.DarkRed);
            lblStatus.Text = "Il faut rentrer le nom d'un animal";
        }

    }


    private void btnEdit_Click(object sender, RoutedEventArgs e)
    {

        Animal SelectedAnimal = VM.Animals
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
