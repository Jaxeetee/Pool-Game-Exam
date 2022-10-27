using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private List<UIPage> _uiPages = new();




    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenCanvas(string id)
    {

        foreach(UIPage page in _uiPages)
        {
            if (page.pageName == id)
            {
                page.OpenPage();
                return;
            }
        }


        if (AreAllCanvasInactive())
        {
            Debug.LogError("No Canvas Found! Double check stringManager or spelling");
        }
    }

    public void CloseCanvas(string id)
    {
        foreach (UIPage page in _uiPages)
        {
            if (page.pageName == id)
            {
                page.ClosePage();
                return;
            }
        }
    }

    private bool AreAllCanvasInactive()
    {
        foreach(UIPage page in _uiPages)
        {
            if (page.gameObject.activeSelf)
            {
                return false;
            }
        }

        return true;
    }
}
