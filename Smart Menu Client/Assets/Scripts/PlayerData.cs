using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {
    public static SessionManager.Language selectedLanguage {
        get { return (SessionManager.Language)PlayerPrefs.GetInt("SelectedLanguage", 0); }
        set { PlayerPrefs.SetInt("SelectedLanguage", (int)value); }
    }
}
