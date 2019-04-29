using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkEditButton : MonoBehaviour
{

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(SubmitButtonChanges);
    }

    public void SubmitButtonChanges()
    {
        InputField inputName = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonName").GetComponent<InputField>();
        InputField inputMessage = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonMessage").GetComponent<InputField>();

        AppAction.selectedButton.GetComponent<ButtonData>().SetButtonName(inputName.text);
        AppAction.selectedButton.GetComponent<ButtonData>().SetButtonMessage(inputMessage.text);

        AppAction.isEditButtonDataMode = false;
        Destroy(this.transform.parent.gameObject);
    }

    
}
