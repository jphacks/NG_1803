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
        this.menuDrinkId = (int)json["menu_drink_id"].Get<long>();
        this.drinkNames = new string[] {json["drink_names"][0].Get<string>(), json["drink_names"][1].Get<string>() , json["drink_names"][2].Get<string>() };

        JsonNode xJson = json["points"][0];
        float x = 0;
        if (xJson.IsType<double>()) x = (float)xJson.Get<double>();
        else x = (float)xJson.Get<long>();
        JsonNode yJson = json["points"][1];
        float y = 0;
        if (yJson.IsType<double>()) y = (float)yJson.Get<double>();
        else x = (float)yJson.Get<long>();
        this.topLeft = new Vector2(x, y);

        xJson = json["points"][2];
        x = 0;
        if (xJson.IsType<double>()) x = (float)xJson.Get<double>();
        else x = (float)xJson.Get<long>();
        yJson = json["points"][3];
        y = 0;
        if (yJson.IsType<double>()) y = (float)yJson.Get<double>();
        else x = (float)yJson.Get<long>();
        this.bottomRight = new Vector2(x, y);

        this.language = (SessionManager.Language)json["language"].Get<long>();
    }
}
