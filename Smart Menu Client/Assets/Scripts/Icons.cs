using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour {

    const float time = 0.5f;
    const float intervalTime = 1;

    Animator animator;
    bool isTrue = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(Coro());
	}

    float dTime = 0;
    private void Update()
    {
        dTime += Time.deltaTime;        
    }

    IEnumerator Coro(){
        yield return new WaitForSeconds(time);
        animator.SetBool("isShow", false);
    }

    public void ToSmall(){
        if (dTime > intervalTime){
            dTime = 0;
            if (isTrue)
            {
                animator.SetBool("isShow", false);
            }
            else
            {
                animator.SetBool("isShow", true);
            }
            isTrue = !isTrue;
        }
    }
}
