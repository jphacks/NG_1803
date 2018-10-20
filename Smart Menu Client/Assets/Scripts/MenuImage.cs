using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuImage : MonoBehaviour {

    const int canvasWidthScale = 900;
    const int menuImageMoveDown = -150;

    [SerializeField]
    private RawImage rawImage;
    [SerializeField]
    GameObject tapPrefab;

    RectTransform rect;

    // Use this for initialization
    void Start () {
        rect = GetComponent<RectTransform>();
        //表示
        rawImage.texture = SMCamera.captureTexture;
        rawImage.SetNativeSize();
        float scale = canvasWidthScale / rawImage.rectTransform.sizeDelta.x;
        rawImage.rectTransform.localScale = Vector3.one * scale;
    }

    public void MoveDown(){
        rect.anchoredPosition += new Vector2(0, menuImageMoveDown);
    }
    public void MoveRight(int right)
    {
        rect.anchoredPosition += new Vector2(right, 0);
    }

    public void AddTaps(JsonNode tapInfos)
    {
        foreach (JsonNode tapInfo in tapInfos)
        {
            GameObject tapObj = Instantiate<GameObject>(tapPrefab);
            tapObj.transform.SetParent(transform, false);
            tapObj.GetComponent<MenuDrinkTap>().Init(tapInfo, rect);
        }
    }
}
