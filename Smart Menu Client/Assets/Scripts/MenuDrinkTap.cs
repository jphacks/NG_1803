using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDrinkTap : MonoBehaviour {

    MenuImageDrinkInfo info;

    public void Init (JsonNode infoJson, RectTransform menuImageRect) {
        this.info = new MenuImageDrinkInfo(infoJson);
        Vector2 topleft = new Vector2(info.topLeft.x * menuImageRect.sizeDelta.x, info.topLeft.y * menuImageRect.sizeDelta.y);
        Vector2 bottomRight = new Vector2(info.bottomRight.x * menuImageRect.sizeDelta.x, info.bottomRight.y * menuImageRect.sizeDelta.y);
        RectTransform rect = GetComponent<RectTransform>();
        rect.localPosition = topleft - new Vector2(menuImageRect.sizeDelta.x / 2, 0);
        rect.sizeDelta = bottomRight - topleft;
    }

    public void Tap(){
        StartCoroutine(SessionManager.GetDrinkInfo(info.menuDrinkId, info.language, (DrinkInfo drinkInfo) => {
            Debug.Log(drinkInfo.category.name);
            Debug.Log(drinkInfo.primaryName);
        }));
    }
}
