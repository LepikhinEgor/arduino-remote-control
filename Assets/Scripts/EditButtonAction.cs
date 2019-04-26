using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButtonAction : MonoBehaviour
{
    private Object buttonEditorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        buttonEditorPrefab = Resources.Load("Prefabs/ButtonProperties");
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClickEditButton);
    }

    public void OnClickEditButton()
    {
        if (!AppAction.isEditButtonDataMode)
        {
            AppAction.buttonPropertiesDiglog = (GameObject)Instantiate(buttonEditorPrefab, transform.parent);
            AppAction.isEditButtonDataMode = true;
            InputField inputName = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonName").GetComponent<InputField>();
            InputField inputMessage = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonMessage").GetComponent<InputField>();

            string buttonName = AppAction.selectedButton.GetComponent<ButtonData>().GetButtonName();
            string buttonMessage = AppAction.selectedButton.GetComponent<ButtonData>().GetButtonMessage();

            inputName.text = buttonName;
            inputMessage.text = buttonMessage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
