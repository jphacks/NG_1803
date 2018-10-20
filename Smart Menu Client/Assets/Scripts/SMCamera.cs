using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class SMCamera : MonoBehaviour
{
    public static Texture2D captureTexture;

    const int canvasHeightScale = 1600;

    private int m_width;
    private int m_height;
    [SerializeField]
    private RawImage m_displayUI = null;
    [SerializeField]
    RectTransform top;
    [SerializeField]
    RectTransform bottom;

    private WebCamTexture m_webCamTexture = null;


    private IEnumerator Start()
    {
        SetScreenSize();
//        LocationManager.Start();

        if (WebCamTexture.devices.Length == 0)
        {
            Debug.LogFormat("カメラのデバイスが無い.");
            yield break;
        }

        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.LogFormat("カメラを使うことが許可されていない.");
            yield break;
        }

        // とりあえず最初に取得されたデバイスを使ってテクスチャを作る.
        WebCamDevice userCameraDevice = WebCamTexture.devices[0];
        m_webCamTexture = new WebCamTexture(userCameraDevice.name, m_width, m_height);

        m_displayUI.texture = m_webCamTexture;

        // 撮影開始
        m_webCamTexture.Play();
    }

    public void Take()
    {
        if (m_webCamTexture == null)
        {
            return;
        }

        if (!m_webCamTexture.isPlaying)
        {
            return;
        }

        m_webCamTexture.Stop();

        // スクショ
        StartCoroutine(Capture((int)top.sizeDelta.y, (int)bottom.sizeDelta.y, (Texture2D texture) =>
        {
            SMCamera.captureTexture = texture;
//            LocationManager.Stop();
//            StartCoroutine(FileUploader.UploadFile(texture));
            SceneManager.LoadScene("Main");
        }));
    }

    // 端末に合わせてサイズ等を調整する
    private void SetScreenSize()
    {
#if !UNITY_EDITOR && UNITY_IOS
        m_width = Screen.height;
        m_height = Screen.width;
        m_displayUI.rectTransform.Rotate(new Vector3(0, 0, 90));
        m_displayUI.rectTransform.localScale = new Vector3(-1, 1, 1);
#elif !UNITY_EDITOR && UNITY_ANDROID
        m_width = Screen.height;
        m_height = Screen.width;
        m_displayUI.rectTransform.Rotate(new Vector3(0, 0, -90));
#elif UNITY_EDITOR
        m_width = Screen.width;
        m_height = Screen.height;
#endif
        m_displayUI.rectTransform.sizeDelta = new Vector2(m_width, m_height);
    }

    /// <summary>
    /// スクリーンショットを撮る
    /// </summary>
    IEnumerator Capture(int topScale, int bottomScale, Action<Texture2D> callback = null)
    {
        yield return new WaitForEndOfFrame();

        int topHeight = Screen.height * topScale / canvasHeightScale;
        int bottomHeight = Screen.height * bottomScale / canvasHeightScale;

        var texture = new Texture2D(Screen.width, Screen.height - topHeight - bottomHeight);
        texture.ReadPixels(new Rect(0, bottomHeight, Screen.width, Screen.height - topHeight - bottomHeight), 0, 0);
        texture.Apply();

        //コールバックが登録されていれば実行
        if (callback != null)
        {
            callback(texture);
        }

    }

} // class TestCamera