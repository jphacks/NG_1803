using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionIcon : MonoBehaviour {

    [SerializeField]
    Sprite onTexture;
    [SerializeField]
    Sprite offTexture;

    Image image;
    bool isOn;

    private void Start()
    {
        image = GetComponent<Image>();
        isOn = true;
    }

    Color gray = new Color(0.8f, 0.8f, 0.8f);
    Color white = new Color(1, 1, 1);
    public void OnClick(){
        if (isOn) {
            image.sprite = offTexture;
            image.color = gray;
        } else {
            image.sprite = onTexture;
            image.color = white;
        }

        isOn = !isOn;
    }
}
