using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuImage : MonoBehaviour {

    const int canvasWidthScale = 900;
    const int menuImageMove = -150;

    [SerializeField]
    private RawImage rawImage;

    float scale;

    // Use this for initialization
    void Start () {
        //表示
        rawImage.texture = SMCamera.captureTexture;
        rawImage.SetNativeSize();
        scale = canvasWidthScale / rawImage.rectTransform.sizeDelta.x;
        rawImage.rectTransform.localScale = Vector3.one * scale;
    }

    public void MoveDown(){
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, menuImageMove);
    }
}
