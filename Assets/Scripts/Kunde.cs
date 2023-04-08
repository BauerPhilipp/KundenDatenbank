using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Kunde
{
    public string Kundenbezeichnung { get; set; }
    public string Name { get; set; }
    public string Firma { get;  set; }
    public string Straﬂe { get; set; }
    public string Postleitzahl { get; set; }
    public string Land { get;  set; }


    public Kunde() { }
    public Kunde(string Kundenbezeichnung, string Name, string Firma, string Straﬂe, string Postleitzahl, string Land)
    {
        this.Kundenbezeichnung = Kundenbezeichnung;
        this.Name = Name;
        this.Firma = Firma;
        this.Straﬂe = Straﬂe;
        this.Postleitzahl = Postleitzahl;
        this.Land = Land;       
    }
}
