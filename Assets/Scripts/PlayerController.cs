using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;
    private float speed;
    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        speed = 1.2f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // For jumpping
        if (Input.GetKeyDown(KeyCode.Space))
        {
             anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
            // For jogging/running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("isJogging", true);
                    speed = 3f;
                }
                else
                {
                    anim.SetBool("isJogging", false);
                }

            }
            else
            {
                anim.SetBool("isJogging", false);
                speed = 1.2f;
            }


            if (Input.GetKey(KeyCode.W))
            {
                //anim.Play("Female Walk");
                anim.SetBool("isWalking", true);

                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

                // if player walks then press shift, run
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetBool("isWalking", false);
                    if (Input.GetKey(KeyCode.W))
                    {
                        anim.SetBool("isJogging", true);
                        speed = 3f;

                    }
                    else
                    {
                        anim.SetBool("isJogging", false);
                    }

                }
                else
                {
                    anim.SetBool("isJogging", false);
                    speed = 1.2f;
                }

            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("isWalking", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Rotate(0, -speed, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Rotate(0, speed, 0);
            }
        }
    }
}
