using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    private bool _active = false;

    [SerializeField]
    GameObject InitScreen;

    [SerializeField]
    List<Image> LanguageButtons = new List<Image>();
    [SerializeField]
    List<TextMeshProUGUI> LanguageTexts = new List<TextMeshProUGUI>();

    [SerializeField]
    List<ContentSizeFitter> ContentSizeFitters = new List<ContentSizeFitter>();

    private Color selectedColor = new Color(0.3803922f, 0f, 0.4705882f, 1f); //Purple

    public void ChangeLocale(int localeID)
    {
        if (_active)
            return; 

        ChangeLanguageMenuUI(localeID);
        StartCoroutine(SetLocale(localeID));
    }

    private IEnumerator SetLocale(int localeID)
    {
        localeID--;

        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        _active = false;
        if (InitScreen.transform.GetChild(0).gameObject.activeSelf == false)
            GoToInit();
    }

    private void GoToInit()
    {
        InitScreen.transform.GetChild(0).gameObject.SetActive(true);
        Logic.Instance.GetCurrentScreen().transform.GetChild(0).gameObject.SetActive(false);
        Logic.Instance.UpdateScreens(InitScreen, InitScreen);
    }

    void ChangeLanguageMenuUI(int localeID)
    {
        localeID--;
        
        foreach (var button in LanguageButtons)       
            button.color = Color.white;
        foreach (var button in LanguageTexts)
            button.color = Color.black;

        LanguageButtons[localeID].color = selectedColor;
        LanguageTexts[localeID].color = Color.white;
    }
}