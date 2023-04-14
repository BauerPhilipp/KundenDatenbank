using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsibilityManager : MonoBehaviour
{
    List<ResponsiblePerson> persons;

    public void Awake()
    {
        persons = new List<ResponsiblePerson>();
        ResponsiblePerson DS = new ResponsiblePerson("Daniela", new List<string> { "Istanbul", "Österreich", "Brasil", "Belgium", "United Kingdom", "Polen" });
        persons.Add(DS);
        ResponsiblePerson VF = new ResponsiblePerson("Vera", new List<string> { "Japan"});
        persons.Add(VF);
        ResponsiblePerson MB = new ResponsiblePerson("Margit", new List<string> { "Deutschland", "Switzerland",  });
        persons.Add(MB);
        ResponsiblePerson AB = new ResponsiblePerson("Alma", new List<string> { "Malaysia", "China", });
        persons.Add(AB);
    }


    public string GetResponsiblePerson(Kunde kunde)
    {
        foreach (ResponsiblePerson person in persons)
        {
            foreach (string land in person.listOfLands)
            {
                if (kunde.Land.ToLower() == land.ToLower())
                {
                    return person.name;
                }
            }
            
        }
        return "keine Angabe";
    }


}

public class ResponsiblePerson
{
    public string name;
    public List<string> listOfLands;

    public ResponsiblePerson(string name, List<string> listOfLands)
    {
        this.name = name;
        this.listOfLands = listOfLands;
    }
}
