using UnityEngine;

public class LocationManager
{
    public static LocationInfo location {
        get
        {
            if (Input.location.status == LocationServiceStatus.Running)
                return Input.location.lastData;
            else 
                return new LocationInfo();
        }
    }

    public static void Start(){
        if (Input.location.isEnabledByUser)
        {
            if (Input.location.status == LocationServiceStatus.Stopped)
                Input.location.Start();
        }
        else
        {
            // FIXME 位置情報を有効にして!! 的なダイアログの表示処理を入れると良さそう
            Debug.Log("location is disabled by user");
        }
    }

    public static void Stop(){
        Input.location.Stop();
    }
}
