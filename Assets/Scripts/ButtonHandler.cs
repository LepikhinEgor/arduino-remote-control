using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler

{
    private float pressTimer = 0;
    private Vector3 clickOffset;
    private Vector3 oldPosition;

    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Input.mousePosition - clickOffset;

            pressTimer += Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonData button = this.transform.GetComponent<ButtonData>();
        Debug.Log("button " + button.GetButtonName() + " pressed, message = "+ button.GetButtonMessage());
        byte[] message = StringToByteArray(button.GetButtonMessage());
        //for (int i = 0; i < message.Length; i++)
       //     Debug.Log(message[i]);
        BluetoothController.SetMessage(message);
        isMoving = true;

        oldPosition = transform.position;

        clickOffset = Input.mousePosition - transform.position;
    }

    private byte[] StringToByteArray(string str)
    {
        char[] charStr = str.ToCharArray();
        byte[] byteStr = new byte[charStr.Length];

        for (int i = 0; i <  charStr.Length; i++)
        {
            byteStr[i] = (byte)charStr[i];
        }

        return byteStr;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("button unpressed");
        BluetoothController.SetMessage(null);
        isMoving = false;
        Debug.Log("timer " + pressTimer);

        Vector3 moveOffset = oldPosition - transform.position;
        Debug.Log(moveOffset.magnitude);

        if (pressTimer < 0.3 && Mathf.Abs(moveOffset.magnitude) < 0.001F)
        {
            ButtonClickAction();
        }

        pressTimer = 0;
    }


    private void ButtonClickAction()
    {
        Debug.Log("button clicked");
        if (!AppAction.isEditButtonDataMode)
        {
            if (AppAction.selectedButton == this.gameObject)
            {
                AppAction.selectedButton = null;
                Destroy(this.gameObject.GetComponent<Outline>());
            }
            else
            {
                if (AppAction.selectedButton != null)
                    Destroy(AppAction.selectedButton.GetComponent<Outline>());
                AppAction.selectedButton = this.gameObject;
                this.gameObject.AddComponent<Outline>();
                this.gameObject.GetComponent<Outline>().effectColor = Color.yellow;
                this.gameObject.GetComponent<Outline>().effectDistance = new Vector2(3, 3);
            }
        }
    }
    /*public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("button clicked");
        if (!AppAction.isEditButtonDataMode)
        {
            if (AppAction.selectedButton == this.gameObject)
            {
                AppAction.selectedButton = null;
                Destroy(this.gameObject.GetComponent<Outline>());
            }
            else
            {
                if (AppAction.selectedButton != null)
                    Destroy(AppAction.selectedButton.GetComponent<Outline>());
                AppAction.selectedButton = this.gameObject;
                this.gameObject.AddComponent<Outline>();
                this.gameObject.GetComponent<Outline>().effectColor = Color.yellow;
                this.gameObject.GetComponent<Outline>().effectDistance = new Vector2(3, 3);
            }
        }
    }*/
}
