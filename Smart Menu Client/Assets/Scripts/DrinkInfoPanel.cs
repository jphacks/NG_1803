using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DrinkInfoPanel : MonoBehaviour {

    [SerializeField]
    GameObject compornentPrefab;
    [SerializeField]
    Texture defualtDrinkImage;

    void Start()
    {
    }

    public void Set(DrinkInfo drinkInfo)
    {
        GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);

        Transform baseInfo = transform.GetChild(1);
        baseInfo.gameObject.SetActive(true);
        // 画像
        StartCoroutine(SetImage(drinkInfo.imageUrl, baseInfo.GetChild(0).GetComponent<RawImage>()));
        // 名前、カテゴリー、ベース
        baseInfo.GetChild(1).GetComponent<Text>().text = drinkInfo.primaryName != "" ? drinkInfo.primaryName : "ー";
        baseInfo.GetChild(1).GetChild(0).GetComponent<Text>().text = drinkInfo.category.name != "" ? drinkInfo.category.name : "ー";
        baseInfo.GetChild(1).GetChild(1).GetComponent<Text>().text = drinkInfo.drinkBase.name != "" ? drinkInfo.drinkBase.name : "ー";
        // 味
        baseInfo.GetChild(3).GetChild(0).GetComponent<Text>().text = drinkInfo.taste != "" ? drinkInfo.taste : "ー";
        // 度数
        SetDegreeGauge(baseInfo.GetChild(4).GetChild(0), drinkInfo.minDegree, drinkInfo.maxDegree);

        // パターンA
        if (drinkInfo.category.viewType == DrinkInfo.ViewType.Cocktail){
            // 構成要素
            SetCompornents(baseInfo.GetChild(5), drinkInfo.compornents);

        // パターンB
        } else {
            baseInfo.GetChild(5).gameObject.SetActive(false);
            Transform patternB = baseInfo.GetChild(6);
            patternB.gameObject.SetActive(true);
            // 産地
            patternB.GetChild(0).GetChild(0).GetComponent<Text>().text = drinkInfo.location != "" ? drinkInfo.location : "ー";
            // 出典
            if (drinkInfo.source.url == ""){
                patternB.GetChild(1).gameObject.SetActive(false);
            } else {
                patternB.GetChild(1).GetChild(0).GetComponent<Text>().text = drinkInfo.source.url;
            }
        }
    }

    // 画像をネットから取得して表示する関数
    IEnumerator SetImage(string url, RawImage rawImage)
    {
//        url = "https://www.suntory.co.jp/wnb/img/cocktail/p_gimlet.gif";
//        url = "https://cdn-ak.f.st-hatena.com/images/fotolife/b/bollet/20180329/20180329010558.jpg";
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
                rawImage.texture = defualtDrinkImage;
            }
            else
            {
                Texture dlTexture = DownloadHandlerTexture.GetContent(uwr);
                if (dlTexture.isBogus()) // 失敗
                    rawImage.texture = defualtDrinkImage;
                else // 成功
                    rawImage.texture = dlTexture;
            }
        }
    }

    Color color0 = new Color(1, 0.827451f, 0.05098039f);
//    Color color1 = new Color(0.9098039f, 0.6666667f, 0.6666667f);
    Color color2 = new Color(1, 0.6156863f, 0);
//    Color color3 = new Color(0.9098039f, 0.4627451f, 0.04705882f);
    Color color4 = new Color(1, 0.372549f, 0.05098039f);
    // 度数のゲージ表示
    void SetDegreeGauge(Transform gauge, int min, int max){
        if (max <= 0) {
            // ノンアルなので色はつけない
        } else if (max <= 8) {
            gauge.GetChild(0).GetChild(0).GetComponent<Image>().color = color0;
        } else if (max <= 25) {
            if (min < 8){
                gauge.GetChild(0).GetChild(0).GetComponent<Image>().color = color2;
            }
            gauge.GetChild(1).GetChild(0).GetComponent<Image>().color = color2;
        }
        else {
            if (min < 8)
            {
                gauge.GetChild(0).GetChild(0).GetComponent<Image>().color = color4;
            } else if (min < 25) {
                gauge.GetChild(0).GetChild(0).GetComponent<Image>().color = color4;
                gauge.GetChild(1).GetChild(0).GetComponent<Image>().color = color4;
            }
            gauge.GetChild(2).GetChild(0).GetComponent<Image>().color = color4;
        }
    }

    // 構成要素の表示
    void SetCompornents(Transform CompornentsTransform, DrinkInfo.Compornent[] compornents){
        for (int i = 0; i < compornents.Length; i++){
            GameObject compornent = Instantiate<GameObject>(compornentPrefab);
            compornent.transform.SetParent(CompornentsTransform, false);
            compornent.transform.localPosition = new Vector2(100, -50 * i);
            compornent.GetComponent<Text>().text = compornents[i].name;
            compornent.transform.GetChild(0).GetComponent<Text>().text = compornents[i].amountNumber != 0 ? compornents[i].amountNumber.ToString() : compornents[i].amountString;
        }
    }

    // 閉じる
    public void Close(){
        Destroy(gameObject);
    }
}
