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
        InputField inputName = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonName").GetComponent<InputField>();
        InputField inputMessage = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonMessage").GetComponent<InputField>();

        AppAction.selectedButton.GetComponent<ButtonData>().SetButtonName(inputName.text);
        AppAction.selectedButton.GetComponent<ButtonData>().SetButtonMessage(inputMessage.text);

        AppAction.isEditButtonDataMode = false;
        Destroy(AppAction.buttonPropertiesDiglog);
    }

    public void CreateNewButton()
    {
        InputField inputName = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonName").GetComponent<InputField>();
        InputField inputMessage = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonMessage").GetComponent<InputField>();
        InputField inputWidth = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonWidth").GetComponent<InputField>();
        InputField inputHeight = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonHeight").GetComponent<InputField>();

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

        widthCoef--;
        heightCoef--;// чтобы при коефициенте 1 не прибавлялось ничего

        RectTransform rect = newButton.GetComponent<RectTransform>();

        Vector2 maxAnch = rect.anchorMax;
        Vector2 minAnch = rect.anchorMin;

        float diffX = rect.anchorMax.x - rect.anchorMin.x;
        float diffY = rect.anchorMax.y - rect.anchorMin.y;

        maxAnch.x += (float)(diffX * widthCoef);
        maxAnch.y += (float)(diffY * heightCoef);

        rect.anchorMax = maxAnch;

        Destroy(AppAction.buttonPropertiesDiglog);
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
