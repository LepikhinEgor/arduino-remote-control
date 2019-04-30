using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkEditSlider : MonoBehaviour
{

    UnityEngine.Object newSliderPrefab;

    void Start()
    {
        //this.gameObject.GetComponent<Button>().onClick.AddListener(SubmitButtonChanges);
        newSliderPrefab = Resources.Load("Prefabs/WorkspaceSlider");

    }

    public void SubmitButtonChanges()
    {
        Dropdown inputDirection = AppAction.propertiesDialog.transform.Find("Dropdown").GetComponent<Dropdown>();
       
        InputField inputMessage = AppAction.propertiesDialog.transform.Find("InputSliderMessage").GetComponent<InputField>();

        AppAction.selectedItem.GetComponent<ButtonData>().SetButtonMessage(inputMessage.text);

        AppAction.isEditButtonDataMode = false;
        Destroy(AppAction.propertiesDialog);
    }

    public void CreateNewButton()
    {
        Dropdown inputDirection = AppAction.propertiesDialog.transform.Find("Dropdown").GetComponent<Dropdown>();
        InputField inputMessage = AppAction.propertiesDialog.transform.Find("InputSliderMessage").GetComponent<InputField>();
        InputField inputWidth = AppAction.propertiesDialog.transform.Find("InputButtonWidth").GetComponent<InputField>();
        InputField inputHeight = AppAction.propertiesDialog.transform.Find("InputButtonHeight").GetComponent<InputField>();
        InputField inputMinValue = AppAction.propertiesDialog.transform.Find("ValuePanel").Find("InputButtonMin").GetComponent<InputField>();
        InputField inputMaxValue = AppAction.propertiesDialog.transform.Find("ValuePanel").Find("InputButtonMin").GetComponent<InputField>();
        Toggle inputIsWhole = AppAction.propertiesDialog.transform.Find("ValuePanel").Find("IsWhole").Find("Toggle").GetComponent<Toggle>();

        GameObject buttonsPanel = GameObject.FindGameObjectWithTag("WorkspaceButtons");
        GameObject newSlider = (GameObject)Instantiate(newSliderPrefab, buttonsPanel.transform);

        double widthCoef = Convert.ToDouble(inputWidth.text, System.Globalization.CultureInfo.InvariantCulture);
        double heightCoef = Convert.ToDouble(inputHeight.text, System.Globalization.CultureInfo.InvariantCulture);
        double minValue = Convert.ToDouble(inputMinValue.text, System.Globalization.CultureInfo.InvariantCulture);
        double maxValue = Convert.ToDouble(inputMaxValue.text, System.Globalization.CultureInfo.InvariantCulture);

        if (widthCoef < 0.5)
            widthCoef = 0.5;
        if (heightCoef < 0.5)
            heightCoef = 0.5;
        //widthCoef--;
        //heightCoef--;// чтобы при коефициенте 1 не прибавлялось ничего

        newSlider.GetComponent<SliderData>().SetSliderMessage(inputMessage.text);
        newSlider.GetComponent<SliderData>().SetDirection(inputDirection.value);
        newSlider.GetComponent<SliderData>().SetWidthCoef((float)widthCoef);
        newSlider.GetComponent<SliderData>().SetHeightCoef((float)heightCoef);
        newSlider.GetComponent<SliderData>().SetMinValue((float)minValue);
        newSlider.GetComponent<SliderData>().SetMaxValue((float)maxValue);
        newSlider.GetComponent<SliderData>().SetWhole(inputIsWhole.isOn);

        RectTransform rect = newSlider.GetComponent<RectTransform>();

        Vector2 maxAnch = rect.anchorMax;
        Vector2 minAnch = rect.anchorMin;

        float diffX = rect.anchorMax.x - rect.anchorMin.x;
        float diffY = rect.anchorMax.y - rect.anchorMin.y;

        maxAnch.x += (float)(diffX * widthCoef);
        maxAnch.y += (float)(diffY * heightCoef);

       // rect.anchorMax = maxAnch;

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
