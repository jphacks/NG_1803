using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLanguage : MonoBehaviour {

    [SerializeField]
    string japaneseText;
    [SerializeField]
    string englishText;
    [SerializeField]
    string chineseText;

    void OnEnable() {
        if (PlayerData.selectedLanguage == SessionManager.Language.Japanese)
        {
            GetComponent<Text>().text = japaneseText;
        }
        else if (PlayerData.selectedLanguage == SessionManager.Language.English)
        {
            GetComponent<Text>().text = englishText;
        }
        else if (PlayerData.selectedLanguage == SessionManager.Language.Chinese)
        {
            GetComponent<Text>().text = chineseText;
        }
    }
}
