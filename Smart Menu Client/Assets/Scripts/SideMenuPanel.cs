using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenuPanel : MonoBehaviour {

    public const int moveLeft = 450;

    [SerializeField]
    MenuImage menuImage;
    [SerializeField]
    RectTransform mainPanel;

    private void Start()
    {
        Reload();
    }

    public void Open()
    {
        menuImage.MoveRight(moveLeft * -1);
        mainPanel.anchoredPosition += new Vector2(moveLeft * -1, 0);
        gameObject.SetActive(true);
    }
    public void Close()
    {
        menuImage.MoveRight(moveLeft);
        mainPanel.anchoredPosition += new Vector2(moveLeft, 0);
        gameObject.SetActive(false);
    }

    public void SetJapanese(){
        SetLanguage(SessionManager.Language.Japanese);
    }
    public void SetEnglish()
    {
        SetLanguage(SessionManager.Language.English);
    }
    public void SetChinese()
    {
        SetLanguage(SessionManager.Language.Chinese);
    }
    void SetLanguage(SessionManager.Language language){
        PlayerData.selectedLanguage = language;
        Reload();
    }

    Color nomalFontColor = new Color(0.4392157f, 0.4392157f, 0.4392157f);
    Color selectedFontColor = new Color(1, 0.6156863f, 0);
    public void Reload(){
        Transform sideMenu = transform.GetChild(0);
        sideMenu.GetChild(0).GetChild(0).gameObject.SetActive(false);
        sideMenu.GetChild(0).GetComponent<Text>().color = nomalFontColor;
        sideMenu.GetChild(1).GetChild(0).gameObject.SetActive(false);
        sideMenu.GetChild(1).GetComponent<Text>().color = nomalFontColor;
        sideMenu.GetChild(2).GetChild(0).gameObject.SetActive(false);
        sideMenu.GetChild(2).GetComponent<Text>().color = nomalFontColor;

        sideMenu.GetChild((int)PlayerData.selectedLanguage).GetChild(0).gameObject.SetActive(true);
        sideMenu.GetChild((int)PlayerData.selectedLanguage).GetComponent<Text>().color = selectedFontColor;
    }
}
