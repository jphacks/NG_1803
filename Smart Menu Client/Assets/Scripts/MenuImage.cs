using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuImage : MonoBehaviour {

    const int canvasWidthScale = 900;

    [SerializeField]
    private RawImage rawImage;

	// Use this for initialization
	void Start () {
        //表示
        rawImage.texture = SMCamera.captureTexture;
        rawImage.SetNativeSize();
        float scale = canvasWidthScale / rawImage.rectTransform.sizeDelta.x;
        rawImage.rectTransform.localScale = Vector3.one * scale;
    }

    public void OnClick(){
        SceneManager.LoadScene("Main");
    }
}
