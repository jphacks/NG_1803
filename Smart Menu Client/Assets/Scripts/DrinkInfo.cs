using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkInfo {

    public class Technique {
        public string name;
        public string description;

        public Technique(JsonNode json){
            this.name = json["name"].Get<string>();
            this.description = json["description"].Get<string>();
        }
    }

    public class Glass {
        public int totalAmount;
        public string name;
        public string glassType;

        public Glass(JsonNode json)
        {
            this.totalAmount = json["total_amount"].Get<int>();
            this.name = json["name"].Get<string>();
            this.glassType = json["grass_type"].Get<string>();
        }
    }

    public class DrinkBase {
        public string imageUrl;
        public string name;
        public string description;

        public DrinkBase(JsonNode json)
        {
            this.imageUrl = json["image_url"].Get<string>();
            this.name = json["name"].Get<string>();
            this.description = json["description"].Get<string>();
        }
    }

    public enum ViewType {
        NotCocktail,
        Cocktail
    }

    public class Category {
        public ViewType viewType;
        public string name;

        public Category(JsonNode json)
        {
            this.viewType = (ViewType)json["view_type"].Get<int>();
            this.name = json["name"].Get<string>();
        }
    }

    public class Source {
        public string name;
        public string url;

        public Source(JsonNode json)
        {
            this.name = json["name"].Get<string>();
            this.url = json["url"].Get<string>();
        }
    }

    public class Compornent {
        public int compornentId;
        public int minDegree;
        public int maxDegree;
        public string imageUrl;
        public string shopUrl;
        public string name;
        public string description;
        public float amountNumber;
        public string amountString;

        public Compornent(JsonNode json)
        {
            this.compornentId = json["compornent_id"].Get<int>();
            this.minDegree = json["min_degree"].Get<int>();
            this.maxDegree = json["max_degree"].Get<int>();
            this.imageUrl = json["image_url"].Get<string>();
            this.shopUrl = json["shop_url"].Get<string>();
            this.name = json["name"].Get<string>();
            this.description = json["description"].Get<string>();
            this.amountNumber = json["amount_number"].Get<float>();
            this.amountString = json["amount_string"].Get<string>();
        }
    }

    public int menuDrinkId;
    public SessionManager.Language language;
    public int minDegree;
    public int maxDegree;
    public string imageUrl;
    public string shopUrl;
    public string primaryName;
    public string[] names;
    public string taste;
    public string description;
    public string recipe;
    public string color;
    public string location;
    public string company;
    public Technique technique;
    public Glass glass;
    public DrinkBase drinkBase;
    public Category category;
    public Source source;
    public Compornent[] compornents;

    public DrinkInfo()
    {}
    public DrinkInfo(JsonNode json)
    {
        this.menuDrinkId = json["menu_drink_id"].Get<int>();
        this.language = (SessionManager.Language)json["language"].Get<int>();
        json = json["drink"];
        this.minDegree = json["min_degree"].Get<int>();
        this.maxDegree = json["max_degree"].Get<int>();
        this.imageUrl = json["image_url"].Get<string>();
        this.shopUrl = json["shop_url"].Get<string>();
        this.primaryName = json["primary_name"].Get<string>();
        this.names = new string[json["names"].Count];
        for (int i = 0; i < this.names.Length; i++) {
            this.names[i] = json["names"][i].Get<string>();
        }
        this.taste = json["taste"].Get<string>();
        this.description = json["description"].Get<string>();
        this.recipe = json["recipe"].Get<string>();
        this.color = json["color"].Get<string>();
        this.location = json["location"].Get<string>();
        this.company = json["company"].Get<string>();
        this.technique = new Technique(json["technique"]);
        this.glass = new Glass(json["grass"]);
        this.drinkBase = new DrinkBase(json["base"]);
        this.category = new Category(json["category"]);
        this.source = new Source(json["source"]);
        this.compornents = new Compornent[json["compornents"].Count];
        for (int i = 0; i < this.compornents.Length; i++)
        {
            this.compornents[i] = new Compornent(json["compornents"][i]);
        }
    }
}
