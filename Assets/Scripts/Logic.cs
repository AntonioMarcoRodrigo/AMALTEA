using UnityEngine;

public class Logic : MonoBehaviour
{
    public static Logic Instance { get; private set; }

    [SerializeField]
    static GameObject CurrentScreen;

    [SerializeField]
    GameObject ParentScreen;

    [SerializeField]
    GameObject TopUI;

    [SerializeField]
    GameObject LanguageScreen;

    public GameObject GetCurrentScreen()
    {
        return CurrentScreen;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)       
            Destroy(gameObject);     
        else
            Instance = this;

        Application.targetFrameRate = 120;
    }

    public void UpdateScreens(GameObject current, GameObject parent)
    {      
        CurrentScreen = current;
        ParentScreen = parent;

        if (CurrentScreen.CompareTag("Init"))
            TopUI.SetActive(false);
        else
            TopUI.SetActive(true);
    }

    public void GoBack()
    {
        CurrentScreen.transform.GetChild(0).gameObject.SetActive(false);
        ParentScreen.transform.GetChild(0).gameObject.SetActive(true);
        UpdateScreens(ParentScreen, ParentScreen.transform.parent.gameObject);
    }

    public void OpenSettings()
    {
        LanguageScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        LanguageScreen.SetActive(false);
    }

    public void UpdateAllCanvases()
    {
        Canvas.ForceUpdateCanvases();
    }
}