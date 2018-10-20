using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPanel : MonoBehaviour {

    [SerializeField]
    MenuImage muneImage;
    [SerializeField]
    GameObject mainPanel;
    [SerializeField]
    LoadingPanel loadingPanel;

    public void OK(){
        loadingPanel.gameObject.SetActive(true);
        // サーバーへデータを送る
        StartCoroutine(SessionManager.PostMenuImage(SMCamera.captureTexture, (JsonNode menuImageDrinkInfos) => {
            muneImage.AddTaps(menuImageDrinkInfos);
            LocationManager.Stop();
            loadingPanel.OnEndable(this);
        }));
    }

    public void OKEnd()
    {
        // 表示を変更する
        mainPanel.SetActive(true);
        muneImage.MoveDown();
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        SceneManager.LoadScene("Camera");
    }
}
