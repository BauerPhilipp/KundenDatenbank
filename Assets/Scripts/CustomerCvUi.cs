using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerCvUi : MonoBehaviour
{

    VisualElement root;
    Button backButton;
    Button copyButton;
    TextField kunde;
    TextField kundenName;
    TextField firma;
    TextField strasse;
    TextField postleitzahl;
    TextField land;
    TextField inhalt;
    TextField laenge;
    TextField breite;
    TextField hoehe;
    TextField gewicht;

    Label etikettEmpfaengerText;
    Label etikettInhaltText;
    Label etikettAbmasseText;

    private void Awake()
    {
        
        root = GetComponent<UIDocument>().rootVisualElement;
        backButton = root.Q<Button>("BackButton");
        backButton.RegisterCallback<ClickEvent>(BackButtonClicked);

        copyButton = root.Q<Button>("SaveToClipboard");
        copyButton.RegisterCallback<ClickEvent>(OnCopyClicked);

        etikettEmpfaengerText = root.Q<Label>("EtikettEmpfaengerText");
        etikettInhaltText = root.Q<Label>("EtikettInhaltText");
        etikettAbmasseText = root.Q<Label>("EtikettAbmasseText");

        kunde = root.Q<TextField>("Kunde"); kunde.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        kundenName = root.Q<TextField>("Name"); kundenName.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        firma = root.Q<TextField>("Firma"); firma.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        strasse = root.Q<TextField>("Strasse"); strasse.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        postleitzahl = root.Q<TextField>("Postleitzahl"); postleitzahl.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        land = root.Q<TextField>("Land"); land.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        inhalt = root.Q<TextField>("Inhalt"); inhalt.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        laenge = root.Q<TextField>("Laenge"); laenge.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        breite = root.Q<TextField>("Breite"); breite.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        hoehe = root.Q<TextField>("Hoehe"); hoehe.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        gewicht = root.Q<TextField>("Gewicht"); gewicht.RegisterCallback<ChangeEvent<string>>(UpdateEtikettText);
        root.Q("MainContainer").visible = false;
    }


    public void SetData(Kunde pickedCustomer)
    {
        root.Q("MainContainer").visible = true;
        kunde.value = pickedCustomer.Kundenbezeichnung;
        kundenName.value = pickedCustomer.Name;
        firma.value = pickedCustomer.Firma;
        strasse.value = pickedCustomer.Straﬂe;
        postleitzahl.value = pickedCustomer.Postleitzahl;
        land.value = pickedCustomer.Land;
        inhalt.value = "x Abpressungen schwarz: ";
        laenge.value = "" + 56;
        breite.value = "" + 56;
        hoehe.value = "" + 2;
        gewicht.value = "" + 10;

        UpdateText();
    }

    void BackButtonClicked(ClickEvent e)
    {
        root.Q("MainContainer").visible = false;
    }

    void OnCopyClicked(ClickEvent e)
    {
        string finalResult = $"Empf‰nger:\n      {kundenName.value}\n" +
            $"      {firma.value}\n      {strasse.value}\n      {postleitzahl.value}\n      {land.value}\n\nInhalt:\n" +
            $"      {inhalt.value}\n\nAbmaﬂe:\n      {laenge.value} x {breite.value} x {hoehe.value} - Gewicht: {gewicht.value}kg\n\n" +
            $"Kontierung:\n      810051";

        GUIUtility.systemCopyBuffer = finalResult;

    }

    void UpdateEtikettText(ChangeEvent<string> e)
    {
        UpdateText();
    }

    void UpdateText()
    {
        etikettEmpfaengerText.text = $"Herr {kundenName.value}\n{firma.value}\n{strasse.value}\n{postleitzahl.value}\n{land.value}";
        etikettInhaltText.text = "" + inhalt.value;
        etikettAbmasseText.text = $"{laenge.value} x {breite.value} x {hoehe.value} - Gewicht: {gewicht.value}kg"; 
    }

}
