using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    private float defaultDiffX = 0.1F;
    private float defaultDiffY = 0.113F;

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

    [SerializeField]
    private float widthCoef;

    public void SetWidthCoef(float widthCoef)
    {
        CalcButtonSize();
        RectTransform rect = this.GetComponent<RectTransform>();

        Vector2 maxAnch = rect.anchorMax;
        Vector2 minAnch = rect.anchorMin;

        float diffX = rect.anchorMax.x - rect.anchorMin.x;

        maxAnch.x = minAnch.x + (float)(defaultDiffX * widthCoef);

        rect.anchorMax = maxAnch;

        this.widthCoef = widthCoef;
    }

    public float GetWidthCoef()
    {
        return widthCoef;
    }

    [SerializeField]
    private float heightCoef;

    public void SetHeightCoef(float heightCoef)
    {
        CalcButtonSize();
        RectTransform rect = this.GetComponent<RectTransform>();

        Vector2 maxAnch = rect.anchorMax;
        Vector2 minAnch = rect.anchorMin;

        maxAnch.y = minAnch.y + (float)(defaultDiffY * heightCoef);

        rect.anchorMax = maxAnch;

        this.heightCoef = heightCoef;
    }

    public float GetHeightCoef()
    {
        return heightCoef;
    }

    // Start is called before the first frame update

    void CalcButtonSize()
    {
        defaultDiffY = defaultDiffX / ((float)Screen.height / (float)Screen.width);
    }
    void Start()
    {
        CalcButtonSize();

        /*RectTransform rect = this.GetComponent<RectTransform>();

        Vector2 maxAnch = rect.anchorMax;
        Vector2 minAnch = rect.anchorMin;

        maxAnch.x = minAnch.x + defaultDiffX;
        maxAnch.y = minAnch.y + defaultDiffY;

        rect.anchorMin = minAnch;
        rect.anchorMax = maxAnch;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
