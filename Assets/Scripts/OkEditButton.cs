using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkEditButton : MonoBehaviour
{

    UnityEngine.Object newButtonPrefab;

    void Start()
    {
        //this.gameObject.GetComponent<Button>().onClick.AddListener(SubmitButtonChanges);
        newButtonPrefab = Resources.Load("Prefabs/WorkspaceButton");

    }

    public void SubmitButtonChanges()
    {
        InputField inputName = AppAction.propertiesDialog.transform.Find("InputButtonName").GetComponent<InputField>();
        InputField inputMessage = AppAction.propertiesDialog.transform.Find("InputButtonMessage").GetComponent<InputField>();
        InputField inputWidth = AppAction.propertiesDialog.transform.Find("InputButtonWidth").GetComponent<InputField>();
        InputField inputHeight = AppAction.propertiesDialog.transform.Find("InputButtonHeight").GetComponent<InputField>();

        AppAction.selectedItem.GetComponent<ButtonData>().SetButtonName(inputName.text);
        AppAction.selectedItem.GetComponent<ButtonData>().SetButtonMessage(inputMessage.text);
        double widthCoef = Convert.ToDouble(inputWidth.text, System.Globalization.CultureInfo.InvariantCulture);
        double heightCoef = Convert.ToDouble(inputHeight.text, System.Globalization.CultureInfo.InvariantCulture);

        if (widthCoef < 0.5)
            widthCoef = 0.5;
        if (heightCoef < 0.5)
            heightCoef = 0.5;

        //widthCoef--;
        //heightCoef--;// чтобы при коефициенте 1 не прибавлялось ничего

        AppAction.selectedItem.GetComponent<ButtonData>().SetWidthCoef((float)widthCoef);
        AppAction.selectedItem.GetComponent<ButtonData>().SetHeightCoef((float)heightCoef);

        AppAction.isEditButtonDataMode = false;
        Destroy(AppAction.propertiesDialog);
    }

    public void CreateNewButton()
    {
        InputField inputName = AppAction.propertiesDialog.transform.Find("InputButtonName").GetComponent<InputField>();
        InputField inputMessage = AppAction.propertiesDialog.transform.Find("InputButtonMessage").GetComponent<InputField>();
        InputField inputWidth = AppAction.propertiesDialog.transform.Find("InputButtonWidth").GetComponent<InputField>();
        InputField inputHeight = AppAction.propertiesDialog.transform.Find("InputButtonHeight").GetComponent<InputField>();

        GameObject buttonsPanel = GameObject.FindGameObjectWithTag("WorkspaceButtons");
        GameObject newButton = (GameObject)Instantiate(newButtonPrefab, buttonsPanel.transform);

        newButton.GetComponent<ButtonData>().SetButtonName(inputName.text);
        newButton.GetComponent<ButtonData>().SetButtonMessage(inputMessage.text);

        double widthCoef = Convert.ToDouble(inputWidth.text, System.Globalization.CultureInfo.InvariantCulture);
        double heightCoef = Convert.ToDouble(inputHeight.text, System.Globalization.CultureInfo.InvariantCulture);

        if (widthCoef < 0.5)
            widthCoef = 0.5;
        if (heightCoef < 0.5)
            heightCoef = 0.5;

        //widthCoef--;
        //heightCoef--;// чтобы при коефициенте 1 не прибавлялось ничего

        newButton.GetComponent<ButtonData>().SetWidthCoef((float)widthCoef);
        newButton.GetComponent<ButtonData>().SetHeightCoef((float)heightCoef);

        Destroy(AppAction.propertiesDialog);
    }

    public void SetCreateMod()
    {
        this.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        this.gameObject.GetComponent<Button>().onClick.AddListener(CreateNewButton);
    }

    public void SetChangeMod()
    {
        this.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        this.gameObject.GetComponent<Button>().onClick.AddListener(SubmitButtonChanges);
    }

}
