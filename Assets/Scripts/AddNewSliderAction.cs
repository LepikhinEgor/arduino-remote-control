using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewSliderAction : MonoBehaviour
{
    private Object sliderEditorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        sliderEditorPrefab = Resources.Load("Prefabs/SliderPropertiesWindow");
        this.GetComponent<Button>().onClick.AddListener(CreateDialog);
    }

    // Update is called once per frame


    void CreateDialog()
    {
        GameObject editorCanvas = GameObject.FindGameObjectWithTag("EditorCanvas");

        if (AppAction.propertiesDialog != null)
            Destroy(AppAction.propertiesDialog);

        AppAction.propertiesDialog = (GameObject)Instantiate(sliderEditorPrefab, editorCanvas.transform);
        OkEditSlider okButton = AppAction.propertiesDialog.transform.Find("OKButton").GetComponent<OkEditSlider>();

       
        okButton.SetCreateMod();
    }
    void Update()
    {

    }
}
