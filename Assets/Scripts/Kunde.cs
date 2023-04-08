using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Kunde
{
    public string Kundenbezeichnung { get; set; }
    public string Name { get; set; }
    public string Firma { get;  set; }
    public string Stra�e { get; set; }
    public string Postleitzahl { get; set; }
    public string Land { get;  set; }


    public Kunde() { }
    public Kunde(string Kundenbezeichnung, string Name, string Firma, string Stra�e, string Postleitzahl, string Land)
    {
        this.Kundenbezeichnung = Kundenbezeichnung;
        this.Name = Name;
        this.Firma = Firma;
        this.Stra�e = Stra�e;
        this.Postleitzahl = Postleitzahl;
        this.Land = Land;       
    }
}
