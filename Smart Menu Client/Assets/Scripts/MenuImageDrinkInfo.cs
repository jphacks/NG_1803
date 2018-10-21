using System.Collections.Generic;
using UnityEngine;

public class MenuImageDrinkInfo {
    public int menuDrinkId;
    public string[] drinkNames;
    public Vector2 topLeft;
    public Vector2 bottomRight;
    public SessionManager.Language language;

    public MenuImageDrinkInfo(JsonNode json)
    {
        this.menuDrinkId = json["menu_drink_id"].Get<int>();
        this.drinkNames = new string[] {json["drink_names"][0].Get<string>(), json["drink_names"][1].Get<string>() , json["drink_names"][2].Get<string>() };
        this.topLeft = new Vector2(json["points"][0].Get<float>(), json["points"][1].Get<float>());
        this.bottomRight = new Vector2(json["points"][2].Get<float>(), json["points"][3].Get<float>());

        this.language = (SessionManager.Language)json["language"].Get<int>();
    }
}
