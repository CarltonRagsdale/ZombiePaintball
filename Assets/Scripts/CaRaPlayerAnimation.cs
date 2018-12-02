using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaRaPlayerAnimation : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }
	}
}
