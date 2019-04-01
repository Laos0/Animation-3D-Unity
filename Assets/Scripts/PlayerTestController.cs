using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour {

    private Animator anim;
    private float speed;
    private bool isWalking;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        speed = 1.2f;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            // after this animation is finished
            if (!anim.GetBool("isJumping") && anim.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree"))
            {
                StartCoroutine("playJumpAnim");
            }

        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {

            if (!anim.GetBool("isJumping"))
            {
                //anim.SetBool("isMoving", true);
                // if it is not jumping then run
                //anim.SetFloat("blendX", 1f);
                //anim.SetFloat("blendY", 0f);
                anim.SetFloat("Blend", 2f);

                speed = 3.0f;


                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (!anim.GetBool("isJumping"))
            {
                anim.SetBool("isMoving", true);
                
                //isWalking = true;

                // if it is not jumping walk
                //anim.SetFloat("blendX", 1f);
                //anim.SetFloat("blendY", 0f);
                anim.SetFloat("Blend", 1f);
                /*
                if(isWalking == true)
                {
                    speed = 1.2f;
                }
                else
                {
                    speed = 3.0f;
                }
                */
                speed = 1.2f;
                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }

        }
        else
        {

            //anim.SetBool("isMoving", false);
            //anim.SetFloat("blendX", 0f);
            //anim.SetFloat("blendY", 0f);
            anim.SetFloat("Blend", 0f);
            
        }

        // For turning the character
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0, -speed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0, speed, 0);
        }



    }

    IEnumerator playJumpAnim()
    {
        anim.SetBool("isJumping", true);

        yield return new WaitForEndOfFrame();

        while (!anim.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree"))
        {
            yield return null;
        }

        anim.SetBool("isJumping", false);

    }

    /* Original code
      if (Input.GetKey(KeyCode.Space))
        {
            // when jumping
            anim.SetFloat("blendX", -1);
            anim.SetFloat("blendY", 0);
            
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                isWalking = true;
                anim.SetFloat("blendX", 1); // walking
                anim.SetFloat("blendY", 0f);
               
                // if shift is also pressed down, then run
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //anim.SetFloat("Blend", 1f);
                    //isWalking = false;
                }

                if (isWalking == true)
                {
                    speed = 1.2f;
                }
                else
                {
                    speed = 3.0f;
                }

                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
               
            }

            // These are for taunting
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetFloat("Blend", 1.25f);
            }

            // The turning of the character
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Rotate(0, -speed, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Rotate(0, speed, 0);
            }

        }
     
     
     */

}
