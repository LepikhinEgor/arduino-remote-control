using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelEditButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(DestroyDialogWindow);
    }

    public void DestroyDialogWindow()
    {
        AppAction.isEditButtonDataMode = false;
        Destroy(this.transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
