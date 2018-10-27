using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDrinkTap : MonoBehaviour {

    MenuImageDrinkInfo info;

    [SerializeField]
    GameObject drinkInfoPrefab;

    Text text;
    Image image;
    RectTransform rect;

    public void Init (JsonNode infoJson, RectTransform menuImageRect, GameObject iconsPre) {
        this.info = new MenuImageDrinkInfo(infoJson);
        Vector2 topleft = new Vector2(info.topLeft.x * menuImageRect.sizeDelta.x, info.topLeft.y * menuImageRect.sizeDelta.y);
        Vector2 bottomRight = new Vector2(info.bottomRight.x * menuImageRect.sizeDelta.x, info.bottomRight.y * menuImageRect.sizeDelta.y);
        rect = GetComponent<RectTransform>();
        rect.localPosition = new Vector2(topleft.x, topleft.y * -1) - new Vector2(menuImageRect.sizeDelta.x / 2, 0);
        rect.sizeDelta = bottomRight - topleft;

        transform.SetParent(transform.parent.GetChild(0), true);

        if (iconsPre) {
            GameObject icons = Instantiate<GameObject>(iconsPre);
            icons.transform.SetParent(transform, false);
            icons.transform.localPosition = new Vector2(-25, rect.sizeDelta.y/2 * -1);
            icons.transform.SetParent(transform.parent.parent, true);
        }

        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
        OnEnable();
    }

    private void OnEnable()
    {
        if (info != null){
            if (info.language != PlayerData.selectedLanguage)
            {
                text.text = info.drinkNames[(int)PlayerData.selectedLanguage];
                text.fontSize = (int)(rect.sizeDelta.y * 3/5);
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                text.text = "";
                image.color = new Color(1, 1, 0.8f, 0.3f);
            }
        }
    }

    public void Tap(){
        Transform canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
        GameObject drinkInfoPanel = Instantiate<GameObject>(drinkInfoPrefab);
        drinkInfoPanel.transform.SetParent(canvas, false);
        StartCoroutine(SessionManager.GetDrinkInfo(info.menuDrinkId, PlayerData.selectedLanguage, (DrinkInfo drinkInfo) => {
            drinkInfoPanel.GetComponent<DrinkInfoPanel>().Set(drinkInfo);
        }));
        /*
        string json = "{\"menu_drink_id\":\"1\",\"language\":0,\"drink\":{\"min_degree\":25,\"max_degree\":30,\"image_url\":\"https://www.suntory.co.jp/wnb/img/cocktail/p_gimlet.gif\",\"shop_url\":\"\",\"primary_name\":\"ルガリータ\",\"names\":[],\"taste\":\"中甘辛口\",\"description\":\"とっても美味しいお酒だよ！すごーい！\",\"recipe\":\"気合いと根性でまぜる\",\"color\":\"白\",\"location\":\"\",\"company\":\"\",\"technique\":{\"name\":\"シェイク\",\"description\":\"ふります\"},\"grass\":{\"total_amount\":60,\"name\":\"カクテルグラス\",\"grass_type\":\"ショート\"},\"base\":{\"image_url\":\"\",\"name\":\"てきいら\",\"description\":\"強いお酒だよ\"},\"category\":{\"view_type\":1,\"name\":\"カクテル\"},\"source\":{\"name\":\"サントリーカクテル検索\",\"url\":\"\"},\"compornents\":[{\"compornent_id\":1,\"min_degree\":0,\"max_degree\":0,\"shop_url\":\"\",\"image_url\":\"\",\"name\":\"テキーラ\",\"description\":\"おいしいおさけだよ．たぶんね．\",\"amount_number\":0.5,\"amount_string\":\"\"}]}}";
        string json = "{\"menu_drink_id\":\"1\",\"language\":0,\"drink\":{\"min_degree\":25,\"max_degree\":30,\"image_url\":\"https://cdn-ak.f.st-hatena.com/images/fotolife/b/bollet/20180329/20180329010558.jpg\",\"shop_url\":\"\",\"primary_name\":\"ルガリータ\",\"names\":[],\"taste\":\"中甘辛口\",\"description\":\"とっても美味しいお酒だよ！すごーい！\",\"recipe\":\"気合いと根性でまぜる\",\"color\":\"白\",\"location\":\"\",\"company\":\"\",\"technique\":{\"name\":\"シェイク\",\"description\":\"ふります\"},\"grass\":{\"total_amount\":60,\"name\":\"カクテルグラス\",\"grass_type\":\"ショート\"},\"base\":{\"image_url\":\"\",\"name\":\"てきいら\",\"description\":\"強いお酒だよ\"},\"category\":{\"view_type\":0,\"name\":\"カクテル\"},\"source\":{\"name\":\"サントリーカクテル検索\",\"url\":\"https://cdn-ak.f.st-hatena.com/images/fotolife/b/bollet/20180329/20180329010558.jpg\"},\"compornents\":[{\"compornent_id\":1,\"min_degree\":0,\"max_degree\":0,\"shop_url\":\"\",\"image_url\":\"\",\"name\":\"テキーラ\",\"description\":\"おいしいおさけだよ．たぶんね．\",\"amount_number\":0.5,\"amount_string\":\"\"}]}}";
        JsonNode node = JsonNode.Parse(json);
        drinkInfoPanel.GetComponent<DrinkInfoPanel>().Set(new DrinkInfo(node));
        */
    }
}
