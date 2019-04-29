using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddNewButtonAction : MonoBehaviour
{

    private Object buttonEditorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        buttonEditorPrefab = Resources.Load("Prefabs/ButtonProperties");
        this.GetComponent<Button>().onClick.AddListener(CreateDialog);
    }

    // Update is called once per frame


    void CreateDialog()
    {
        GameObject editorCanvas = GameObject.FindGameObjectWithTag("EditorCanvas");
        AppAction.buttonPropertiesDiglog = (GameObject)Instantiate(buttonEditorPrefab, editorCanvas.transform);
        OkEditButton okButton = AppAction.buttonPropertiesDiglog.transform.Find("OKButton").GetComponent<OkEditButton>();
        okButton.SetCreateMod();
        Debug.Log("created dialog");
    }
    void Update()
    {
       
    }
}
