using UnityEngine;

public class UIPage : MonoBehaviour
{
    [SerializeField]
    private string _pageName;

    public string pageName{
        get => _pageName;
    }

    public void OpenPage()
    {
        this.gameObject.SetActive(true);
    }

    public void ClosePage()
    {
        this.gameObject.SetActive(false);
    }
}
