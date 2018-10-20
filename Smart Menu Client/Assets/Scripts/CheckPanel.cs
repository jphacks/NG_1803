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
        /*
        // サーバーへデータを送る
        StartCoroutine(SessionManager.PostMenuImage(SMCamera.captureTexture, (JsonNode menuImageDrinkInfos) => {
            if (menuImageDrinkInfos == null) {
                // 実際には写真の読み込みに失敗しましたとか表示する
                Cancel();
            } else {
                muneImage.AddTaps(menuImageDrinkInfos);
                LocationManager.Stop();
                loadingPanel.OnEndable(this);
            }
        }));
        */
        string str = "[{\"menu_drink_id\":2,\"drink_names\":[\"ザ・プレミアム・モルツ 香るエール\",\"The Premium Malt's\",\"优质麦芽\"],\"points\":[0.1,0.2,0.4,0.25],\"language\":0,\"option\":[]}]";
        JsonNode menuImageDrinkInfos = JsonNode.Parse(str);
        muneImage.AddTaps(menuImageDrinkInfos);
        LocationManager.Stop();
        loadingPanel.OnEndable(this);
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
