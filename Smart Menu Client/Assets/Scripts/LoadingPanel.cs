using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : MonoBehaviour {

    bool isEndable = false;
    CheckPanel checkPanel;

    [SerializeField]
    GameObject ok;

    public void OnEndable(CheckPanel checkPanel)
    {
        isEndable = true;
        ok.SetActive(true);
        this.checkPanel = checkPanel;
    }

    public void End(){
        if (isEndable){
            checkPanel.OKEnd();
            gameObject.SetActive(false);
        }
    }
}
