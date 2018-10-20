using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;

public class SessionManager : MonoBehaviour
{
    public enum Langage {
        Japanese,
        English,
        Chinese
    }

    const string requestUrl = "https://c0f97acd.ngrok.io/api/";
    const int sampleUserId = 8;
    const string sampleToken = "mMK7P4U5rSJ6FN8oN9g4";

    public static IEnumerator PostMenuImage(Texture2D tex, Action<string> callback = null, string fileName = "fileName.jpg")
    {
        // テクスチャをpngに変換
        byte[] img = tex.EncodeToJPG();

        WWWForm form = new WWWForm();
        form.AddField("id", sampleUserId);
        form.AddField("auth_token", sampleToken);
        LocationInfo location = LocationManager.location;
        /*
        if (location.timestamp != 0)
        {
            form.AddField("lat", location.latitude.ToString());
            form.AddField("lon", location.longitude.ToString());
            form.AddField("alt", location.altitude.ToString());
        }
        */
        form.AddField("lat", "23.134");
        form.AddField("lon", "135.2314");
        form.AddField("alt", "123.56");
        form.AddBinaryData("image_data", img, fileName, "image/jpeg");

        // HTTPリクエストを送る
        string url = requestUrl + "menu_images/create";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(www.error);
        }
        else
        {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log(www.responseCode);
            Debug.Log(www.downloadHandler.text);
        }

        //コールバックが登録されていれば実行
        if (callback != null)
        {
            callback(www.downloadHandler.text);
        }
    }

    // 直前のメニューを取得する関数
    public void GetPreviousMenu(int userId, string authToken)
    {
        StartCoroutine(GetPreviousMenu_IE(userId, authToken));
    }
    IEnumerator GetPreviousMenu_IE(int userId, string authToken)
    {
        // HTTPリクエストを送る
        string url = requestUrl + "";
        url += "?";
        url += "id=" + userId;
        url += "&auth_token=" + authToken;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(www.error);
        }
        else
        {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log(www.responseCode);
            Debug.Log(www.downloadHandler.text);
        }
    }

    // ドリンク情報を取得する関数
    public void GetDrinkTest(){
        GetDrinkInfo(sampleUserId, sampleToken, 0, Langage.Japanese);
    }
    public void GetDrinkInfo(int userId, string authToken, int menuDrinkId, Langage language)
    {
        StartCoroutine(GetDrinkInfo_IE(userId, authToken, menuDrinkId, language));
    }
    IEnumerator GetDrinkInfo_IE(int userId, string authToken, int menuDrinkId, Langage language)
    {
        // HTTPリクエストを送る
        string url = requestUrl + "get_menu_drink";
        url += "?";
        url += "id=" + userId;
        url += "&auth_token=" + authToken;
        url += "&menu_drink_id=" + menuDrinkId;
        url += "&language=" + language;
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(www.error);
        }
        else
        {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log(www.responseCode);
            Debug.Log(www.downloadHandler.text);
        }
    }

    // User の新規作成
    public void CreateUser(){
        StartCoroutine(CreateUser_IE());
    }
    IEnumerator CreateUser_IE(){
        // postするデータ
        WWWForm form = new WWWForm();
        form.AddField("app_version", Application.version);
        form.AddField("device", SystemInfo.deviceModel);
        form.AddField("os", SystemInfo.operatingSystem);

        // HTTPリクエストを送る
        string url = requestUrl + "users/sign_up";
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(www.error);
        }
        else
        {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log(www.responseCode);
            Debug.Log(www.downloadHandler.text);
        }
    }
}