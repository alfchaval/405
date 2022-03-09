using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TranslatableText : MonoBehaviour
{
    private LanguageManager languageManager;
    private Text text;

    public string english;
    public string spanish;

    private void Awake()
    {
        text = GetComponent<Text>();
        languageManager = FindObjectOfType<LanguageManager>();
        languageManager.OnLanguageChanged += ChangeLanguage;
    }

    private void OnEnable()
    {
        CheckLanguage();
    }

    private void CheckLanguage()
    {
        ChangeLanguage(languageManager.currentLanguage);
    }

    private void ChangeLanguage(LanguageManager.Language language)
    {
        switch (language)
        {
            case LanguageManager.Language.English:
                text.text = english;
                break;
            case LanguageManager.Language.Spanish:
                text.text = spanish;
                break;
        }
    }
}