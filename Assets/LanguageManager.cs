using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public Language currentLanguage;

    public delegate void LanguageChanged(Language language);
    public event LanguageChanged OnLanguageChanged;

    public enum Language
    {
        English,
        Spanish
    }

    public void ChangeLanguage(Language language)
    {
        if (language != currentLanguage)
        {
            currentLanguage = language;
            OnLanguageChanged(language);
        }
    }

    public string GetLanguageChars()
    {
        return GetLanguageChars(currentLanguage);
    }

    public string GetLanguageChars(Language language)
    {
        switch (language)
        {
            case Language.English:
                return "EN";
            case Language.Spanish:
                return "ES";
        }
        return "";
    }
}
