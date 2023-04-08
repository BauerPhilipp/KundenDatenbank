using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerCvUi : MonoBehaviour
{

    VisualElement root;
    Button backButton;
    Button copyButton;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        backButton = root.Q<Button>("BackButton");
        backButton.RegisterCallback<ClickEvent>(BackButtonClicked);
    }


    public void SetData(Kunde pickedCustomer)
    {
        root.Q("MainContainer").visible = true;
        VisualElement kunde;
        Debug.Log("CustomerUi aktiviert!");
    }


    void BackButtonClicked(ClickEvent e)
    {
        root.Q("MainContainer").visible = false;
    }
}
