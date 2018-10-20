using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkInfoPanel : MonoBehaviour {

    [SerializeField]
    GameObject compornentPrefab;

    void Start()
    {
    }

    public void Set(DrinkInfo drinkInfo)
    {
        transform.GetChild(0).gameObject.SetActive(false);

        Transform baseInfo = transform.GetChild(1);
        baseInfo.gameObject.SetActive(true);

        StartCoroutine(SetImage(drinkInfo.imageUrl, baseInfo.GetChild(0).GetComponent<RawImage>()));

        baseInfo.GetChild(1).GetComponent<Text>().text = drinkInfo.primaryName;
        baseInfo.GetChild(1).GetChild(0).GetComponent<Text>().text = drinkInfo.category.name;
        baseInfo.GetChild(1).GetChild(1).GetComponent<Text>().text = drinkInfo.drinkBase.name;

        baseInfo.GetChild(3).GetChild(0).GetComponent<Text>().text = drinkInfo.taste;

        SetDegreeGauge(baseInfo.GetChild(4).GetChild(0), drinkInfo.minDegree, drinkInfo.maxDegree);

        SetCompornents(baseInfo.GetChild(5), drinkInfo.compornents);
    }

    // 画像をネットから取得して表示する関数
    IEnumerator SetImage(string url, RawImage rawImage)
    {
        WWW www = new WWW(url);
        yield return www;
        rawImage.texture = www.textureNonReadable;
    }

    Color color0 = new Color(1, 0.827451f, 0.05098039f);
    Color color1 = new Color(0.9098039f, 0.6666667f, 0.6666667f);
    Color color2 = new Color(1, 0.6156863f, 0);
    Color color3 = new Color(0.9098039f, 0.4627451f, 0.04705882f);
    Color color4 = new Color(1, 0.372549f, 0.05098039f);
    // 度数のゲージ表示
    void SetDegreeGauge(Transform gauge, int min, int max){
        if (max <= 8) {
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
}
