using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderData : MonoBehaviour
{
    private const int SLIDER_HEIGHT = 10;
    private float defaultSliderWidth = Screen.width/5;
    private Slider slider;

    [SerializeField]
    private int direction;

    public void SetDirection(int direction)
    {
        slider = this.GetComponent<Slider>();
        slider.direction = Slider.Direction.LeftToRight;

        if (direction == 1)
        {
            RectTransform rect = this.GetComponent<RectTransform>();
            rect.Rotate(Vector3.forward, 90);
        }

        this.direction = direction;
    }

    public int GetDirection()
    {
        return this.direction;
    }

    [SerializeField]
    private string sliderMessage;

    public void SetSliderMessage(string sliderMessage)
    {
        this.sliderMessage = sliderMessage;
    }

    public string GetSliderMessage()
    {
        return sliderMessage;
    }

    [SerializeField]
    private float widthCoef;

    public void SetWidthCoef(float widthCoef)
    {
        RectTransform rect = this.GetComponent<RectTransform>();

        Vector2 offsetMax = rect.offsetMax;
        Vector2 offsetMin = rect.offsetMin;

        Debug.Log(offsetMax + "ixi" + offsetMin);

        offsetMax.x = defaultSliderWidth / 2 * widthCoef;
        offsetMin.x = -defaultSliderWidth / 2 * widthCoef;

        rect.offsetMin = offsetMin;
        rect.offsetMax = offsetMax;

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
        RectTransform rect = this.GetComponent<RectTransform>();

        Vector2 offsetMax = rect.offsetMax;
        Vector2 offsetMin = rect.offsetMin;

        offsetMax.y = SLIDER_HEIGHT * heightCoef;
        offsetMin.y = -SLIDER_HEIGHT * heightCoef;

        rect.offsetMin = offsetMin;
        rect.offsetMax = offsetMax;

        this.heightCoef = heightCoef;
    }

    public float GetHeightCoef()
    {
        return heightCoef;
    }

    [SerializeField]
    private float maxValue;

    public void SetMaxValue(float maxValue)
    {
        this.maxValue = maxValue;
    }

    public float GetMaxValue()
    {
        return maxValue;
    }

    [SerializeField]
    private float minValue;

    public void SetMinValue(float minValue)
    {
        this.minValue = minValue;
    }

    public float GetMinValue()
    {
        return minValue;
    }

    [SerializeField]
    private bool isWhole;

    public void SetWhole(bool isWhole)
    {
        this.isWhole = isWhole;
    }

    public bool IsWhole()
    {
        return isWhole;
    }

    void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
