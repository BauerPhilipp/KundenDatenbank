using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{

    [SerializeField] TextAsset csvDatei;
    int spaltenAnzahl = 0;
    int reihenAnzahl = 0;
    static List<Kunde> kundenListe = new List<Kunde>();

    private void Start()
    {
        string[] reihe = csvDatei.text.Split("\n", StringSplitOptions.None);
        reihenAnzahl = reihe.Length ;
        string[] data = csvDatei.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);
        spaltenAnzahl = data.Length / reihenAnzahl - 1;
        //Debug.Log("Einträge in data: " + data.Length);
        //Debug.Log("Reihen: " + reihenAnzahl);
        //Debug.Log("Spalten -1: " + spaltenAnzahl);

        //foreach (string s in data)
        //{
        //    Debug.Log(s);
        //}

        int offset = 0;
        for (int i = 0; i < reihenAnzahl; i++)
        {
            Kunde kunde = new Kunde();
            kunde.Kundenbezeichnung = data[i + offset];
            kunde.Name = data[i + 1 + offset];
            kunde.Firma = data[i + 2 + offset];
            kunde.Straße = data[i + 3 + offset];
            kunde.Postleitzahl = data[i + 4 + offset];
            kunde.Land = data[i + 5 + offset];

            //Debug.Log(data[i + offset]);
            offset += 6;

            kundenListe.Add(kunde);
        }
        //AusgabeKundenliste();
    }

    //void AusgabeKundenliste()
    //{
    //    foreach (Kunde kunde in kundenListe)
    //    {
    //        Debug.Log("Kunde: " + kunde.Kundenbezeichnung + ", "
    //                + "Name: " + kunde.Name + ", "
    //                + "Firma: " + kunde.Firma + ", "
    //                + "Straße: " + kunde.Straße + ", "
    //                + "Postleitzahl: " + kunde.Postleitzahl + ", "
    //                + "Land: " + kunde.Land + ", ");
    //    }
    //}


    public static List<Kunde> GetKundenliste()
    {
        return kundenListe;
    }

}
