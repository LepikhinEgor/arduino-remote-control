using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToUserModeButtonHandler : MonoBehaviour
{
    GameObject creatorPanel;
    GameObject editButton;

    private bool isMoving;
    private Vector3 attachPanelPosition;

    private float buttonHeight;

    // Start is called before the first frame update
    void Start()
    {
        creatorPanel = GameObject.FindGameObjectWithTag("ButtonsCreator");
        editButton = GameObject.FindGameObjectWithTag("EditButton");
        this.gameObject.GetComponent<Button>().onClick.AddListener(ToUserMode);

        buttonHeight = GetComponent<RectTransform>().anchorMax.y - GetComponent<RectTransform>().anchorMin.y;
        // в пикселях
        float parentHeigth  = (transform.parent.GetComponent<RectTransform>().anchorMax.y - transform.parent.GetComponent<RectTransform>().anchorMin.y)*Screen.height;
        buttonHeight *= parentHeigth;
        Debug.Log(buttonHeight);
    }

    public void ToUserMode()
    {
        creatorPanel.GetComponent<ElementsCreatorPanel>().SetBottomAttachButtonHeight(buttonHeight);
        creatorPanel.GetComponent<ElementsCreatorPanel>().HidePanel();
        editButton.GetComponent<EditButtonAction>().Hide();
        isMoving = true;

        if (AppAction.propertiesDialog != null)
            Destroy(AppAction.propertiesDialog);
        AppAction.propertiesDialog = null;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isMoving)
        {
            float panelHeight = creatorPanel.GetComponent<ElementsCreatorPanel>().GetPanelHeight();
            attachPanelPosition = creatorPanel.transform.position;
            attachPanelPosition.y -= panelHeight / 2 + buttonHeight / 2;
            transform.position =  attachPanelPosition;

        }*/
    }
}
