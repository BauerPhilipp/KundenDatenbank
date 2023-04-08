using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class SearchManager : MonoBehaviour
{
    [SerializeField] VisualTreeAsset buttonTemplate;
    VisualElement root;
    VisualElement searchResult;
    TextField searchField;
    Label buttonTemplateLabel;
    List<Kunde> kundenliste;
    List<VisualElement> kundenlisteButtons;

    const string searchStyle = "SearchStyle";
    const string buttonTemplateLabelClass = "buttonTemplateLabel";

    private void Start()
    {
        kundenlisteButtons = new List<VisualElement>();
        root = GetComponent<UIDocument>().rootVisualElement;
        searchField = root.Q<TextField>("SearchText");
        searchResult = root.Q("SearchResults");
        searchField.RegisterCallback<ChangeEvent<string>>(OnInputChanged);

        kundenliste = CSVReader.GetKundenliste();
    }

    private void OnInputChanged(ChangeEvent<string> e)
    {
        RemoveButtonsFromView();
        SearchKundenliste(e.newValue);
    }

    void SearchKundenliste(string value)
    {
        foreach (Kunde kunde in kundenliste)
        {
            if (kunde.Name.ToUpper().Contains(value.ToUpper())) 
            {
                CreateCustomerButton(kunde);
            }
        }
        AddButtonsToView();
    }
    void CreateCustomerButton(Kunde kunde)
    {
        if (kundenlisteButtons.Count > 5) { return; }
        VisualElement customerButton = buttonTemplate.Instantiate();
        customerButton.RegisterCallback<ClickEvent>(OnCustomerClicked);
        customerButton.userData = kunde;
        kundenlisteButtons.Add(customerButton);
    }

    void AddButtonsToView()
    {
        if (kundenlisteButtons.Count == 0) { return; }
        foreach (VisualElement button in kundenlisteButtons)
        {
            Label label = button.Q<Label>("ButtonLabel");
            label.text = "Kunde: " + (button.userData as Kunde).Kundenbezeichnung + ";  Name: " + (button.userData as Kunde).Name;
            label.pickingMode = PickingMode.Ignore;
            searchResult.Add(button);
        }
        Debug.Log("kundenlisteButtons count = " + kundenlisteButtons.Count);
    }

    void RemoveButtonsFromView()
    {
        if (kundenlisteButtons.Count == 0) { return; };
        

        foreach (VisualElement button in kundenlisteButtons)
        {
            searchResult.Remove(button);
        }
        //Debug.Log(kundenlisteButtons.Count);
        kundenlisteButtons.Clear();
        
    }

    void OnCustomerClicked(ClickEvent e)
    {
        Debug.Log(((e.target as VisualElement).parent.userData as Kunde).Name);
    }

}
