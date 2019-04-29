using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsCreatorPanel : MonoBehaviour
{
    private Vector3 hidenInventoryPos;
    private Vector3 defaultInventoryPos;

    private bool isHideAnimation;
    private bool isShowAnimation;

    private float bottomAttachButtonHeight;

    private float panelHeight;

    public void ShowPanel()
    {
        isShowAnimation = true;
    }

    public void HidePanel()
    {
        isHideAnimation = true;
    }

    public void SetBottomAttachButtonHeight(float height)
    {
        bottomAttachButtonHeight = height;
        FindInventoryPositions();
    }

    public float GetPanelHeight()
    {
        return this.panelHeight;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindInventoryPositions();
    }

    private void FindInventoryPositions()
    {
        //высота кнопки в процентах
        panelHeight = transform.GetComponent<RectTransform>().anchorMax.y - GetComponent<RectTransform>().anchorMin.y;
        // в пикселях
        panelHeight *= Screen.height;

        defaultInventoryPos = transform.position;

        Vector3 pos = transform.position;
        pos.y += panelHeight;
        Debug.Log(bottomAttachButtonHeight + " " + panelHeight);
        hidenInventoryPos = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHideAnimation)
        {
            transform.position = Vector3.MoveTowards(transform.position, hidenInventoryPos, 500 * Time.deltaTime);

            if (transform.position.y == hidenInventoryPos.y)
                isHideAnimation = false;
        }

        if (isShowAnimation)
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultInventoryPos, 500 * Time.deltaTime);

            if (transform.position.y == defaultInventoryPos.y)
            {
                isShowAnimation = false;
            }
        }
    }
}
