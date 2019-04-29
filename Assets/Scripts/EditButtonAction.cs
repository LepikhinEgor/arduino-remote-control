using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButtonAction : MonoBehaviour
{
    private Object buttonEditorPrefab;

    private bool isHideAnimation;
    private bool isShowAnimation;

    private bool isShowed;

    Vector3 defaultButtonPos;
    Vector3 showedButtonPos;
    // Start is called before the first frame update
    void Start()
    {
        buttonEditorPrefab = Resources.Load("Prefabs/ButtonProperties");
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClickEditButton);
        FindButtonPositions();
    }

    public void OnClickEditButton()
    {
        if (!AppAction.isEditButtonDataMode)
        {
            AppAction.buttonPropertiesDiglog = (GameObject)Instantiate(buttonEditorPrefab, transform.parent);
            AppAction.isEditButtonDataMode = true;

            OkEditButton okButton = AppAction.buttonPropertiesDiglog.transform.Find("OKButton").GetComponent<OkEditButton>();
            okButton.SetChangeMod();

            InputField inputName = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonName").GetComponent<InputField>();
            InputField inputMessage = AppAction.buttonPropertiesDiglog.transform.Find("InputButtonMessage").GetComponent<InputField>();

            string buttonName = AppAction.selectedButton.GetComponent<ButtonData>().GetButtonName();
            string buttonMessage = AppAction.selectedButton.GetComponent<ButtonData>().GetButtonMessage();

            inputName.text = buttonName;
            inputMessage.text = buttonMessage;
        }
    }
    public void Hide()
    {
        if (isShowed)
            isHideAnimation = true;
    }

    public void Show()
    {
        Debug.Log("Show");
        if (!isShowed)
            isShowAnimation = true;
    }

    public void FindButtonPositions()
    {
        //высота кнопки в процентах
        float buttonHeight = GetComponent<RectTransform>().anchorMax.y - GetComponent<RectTransform>().anchorMin.y;
        // в пикселях
        buttonHeight *= Screen.height;

        showedButtonPos = transform.position;

        float offset = transform.position.y - 0;
        Vector3 pos = transform.position;
        pos.y = 0 - buttonHeight/2;
        defaultButtonPos = pos;
        transform.position = defaultButtonPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowAnimation)
        {
            transform.position = Vector3.MoveTowards(transform.position, showedButtonPos, 500 * Time.deltaTime);

            if (Mathf.Abs(transform.position.y - showedButtonPos.y) < 5)
            {
                transform.position = showedButtonPos;
                isShowAnimation = false;
                isShowed = true;
                Debug.Log("ferbe");
            }
        }

        if (isHideAnimation)
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultButtonPos, 500 * Time.deltaTime);

            if (Mathf.Abs(transform.position.y - defaultButtonPos.y) < 5)
            {
                transform.position = defaultButtonPos;
                Debug.Log("vvdvf");
                isHideAnimation = false;
                isShowed = false;
            }
        }
    }
}
