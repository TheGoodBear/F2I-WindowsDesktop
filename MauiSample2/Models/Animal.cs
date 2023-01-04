using SQLite;

namespace MauiSample2.Models;

internal class Animal
{
	// static properties

	// properties
	[PrimaryKey, AutoIncrement]
	public int ID { get; set; }
	public string Name { get; set; }
	public string? Description { get; set; }
	public string? ImageLink { get; set; }
	public int? IDCountry { get; set; }


    // constructors
    public Animal()
	{ }

    public Animal(
		string Name,
		string? Description = null,
		string? ImageLink = null,
		int? IDCountry = null)
	{
		this.Name = Name;
		this.Description = Description;
		this.ImageLink = ImageLink;
		this.IDCountry = IDCountry;
	}


	// methods
	public override string ToString()
		=> $"({ID}) {Name} → {Description}";

}
