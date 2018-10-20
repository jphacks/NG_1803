using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPanel : MonoBehaviour {

    [SerializeField]
    MenuImage muneImage;
    [SerializeField]
    GameObject mainPanel;

    public void OK(){
        mainPanel.SetActive(true);
        muneImage.MoveDown();
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        SceneManager.LoadScene("Camera");
    }
}
