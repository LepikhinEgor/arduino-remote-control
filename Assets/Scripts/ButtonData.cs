using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    [SerializeField]
    private string buttonName;

    public void SetButtonName(string buttonName)
    {
        this.transform.Find("Text").GetComponent<Text>().text = buttonName;
        this.buttonName = buttonName;
    }

    public string GetButtonName()
    {
        return buttonName;
    }

    [SerializeField]
    private string buttonMessage;

    public void SetButtonMessage(string buttonMessage)
    {
        this.buttonMessage = buttonMessage;
    }

    public string GetButtonMessage()
    {
        return buttonMessage;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
