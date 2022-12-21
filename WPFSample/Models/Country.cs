using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSample.Models;

internal class Country
{
    // static properties
    private static int NextID = 1;

    // properties
    public int ID { get; set; }
    public string Name { get; set; }
    public string? ImageLink { get; set; }

    // constructor
    public Country(
        string Name, 
        string? ImageLink = null)
    {
        this.ID = NextID;
        this.Name = Name;
        this.ImageLink = ImageLink;

        NextID++;
    }

}
