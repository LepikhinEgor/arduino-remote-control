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
            AppAction.propertiesDialog = (GameObject)Instantiate(buttonEditorPrefab, transform.parent);
            AppAction.isEditButtonDataMode = true;

            OkEditButton okButton = AppAction.propertiesDialog.transform.Find("OKButton").GetComponent<OkEditButton>();
            okButton.SetChangeMod();

            InputField inputName = AppAction.propertiesDialog.transform.Find("InputButtonName").GetComponent<InputField>();
            InputField inputMessage = AppAction.propertiesDialog.transform.Find("InputButtonMessage").GetComponent<InputField>();
            InputField inputWidth = AppAction.propertiesDialog.transform.Find("InputButtonWidth").GetComponent<InputField>();
            InputField inputHeight = AppAction.propertiesDialog.transform.Find("InputButtonHeight").GetComponent<InputField>();

            string buttonName = AppAction.selectedItem.GetComponent<ButtonData>().GetButtonName();
            string buttonMessage = AppAction.selectedItem.GetComponent<ButtonData>().GetButtonMessage();
            float buttonWidth = AppAction.selectedItem.GetComponent<ButtonData>().GetWidthCoef();
            float buttonHeight = AppAction.selectedItem.GetComponent<ButtonData>().GetHeightCoef();
            Debug.Log(buttonWidth + " x " + buttonHeight);

            inputName.text = buttonName;
            inputMessage.text = buttonMessage;
            inputWidth.text = buttonWidth.ToString();
            inputHeight.text = buttonHeight.ToString();
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
