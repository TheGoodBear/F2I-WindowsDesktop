using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UWPSample2.Models;

internal class Animal : INotifyPropertyChanged
{
    // static properties
    private static int NextID = 1;

    // properties
    public int ID { get; set; }

    private string _Name;
    public string Name
    {
        get => _Name;
        set
        {
            _Name = value;
            RaisePropertyChanged();
        }
    }

    private string? _Description;
    public string? Description
    {
        get => _Description;
        set
        {
            _Description = value;
            RaisePropertyChanged();
        }
    }

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
    }


    // methods
    public override string ToString() 
        => $"({ID}) {Name} → {Description}";
    //public override string ToString()
    //{
    //    return $"({ID}) {Name} → {Description}";
    //}



    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(
        [CallerMemberName] string PropertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }

}
