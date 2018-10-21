using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icons : MonoBehaviour {

    const float time = 0.5f;

    Animator animator;
    bool isTrue = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        StartCoroutine(Coro());
	}

    IEnumerator Coro(){
        yield return new WaitForSeconds(time);
        animator.SetBool("isShow", false);
    }

    public void ToSmall(){
        if (isTrue){
            animator.SetBool("isShow", false);
        } else {
            animator.SetBool("isShow", true);
        }
        isTrue = !isTrue;
    }
}
