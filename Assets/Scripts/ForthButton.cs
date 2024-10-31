using UnityEngine;

public class ForthButton : MonoBehaviour
{
    [SerializeField]
    GameObject currentScreen;

    [SerializeField]
    GameObject nextScreen;

    public void GoForth()
    {
        currentScreen.transform.GetChild(0).gameObject.SetActive(false);
        nextScreen.transform.GetChild(0).gameObject.SetActive(true);
        Logic.Instance.UpdateScreens(nextScreen, currentScreen);
    }
}