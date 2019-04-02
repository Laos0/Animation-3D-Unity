﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestController : MonoBehaviour {

    private Animator anim;
    private float speed;
    private bool isWalking;
    private float currentValue;
    public float interpolateSpd;
    private float animationValue;
    private float targetAnimationValue;
    private float idleValue, walkValue, runValue;
    private float animCounter;
    private bool isIdle, isWalk, isRun;

    public AnimationCurve animCurve;
    public AnimationCurve idleCurve;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        speed = 1f;

        currentValue = 0f;
        interpolateSpd = 2f;
        idleValue = 0f;
        walkValue = .5f;
        runValue = 1f;
        animCounter = 0f;
        isIdle = false;
        isWalk = false;
        isRun = false;


    }
	
	// Update is called once per frame
	void Update () {

        //this.gameObject.transform.Translate(new Vector3(0, 0, currentValue));


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
                if (!isRun)
                {
                    animCounter = 0f;
                    isIdle = false;
                    isWalk = false;
                    isRun = true;
                }

                speed = 3f;

                animCounter += Time.deltaTime;
                targetAnimationValue = runValue;
                if (animationValue < targetAnimationValue)
                {

                    animationValue = .5f + animCurve.Evaluate(animCounter * interpolateSpd);

                    anim.SetFloat("Blend", animationValue);
                }


                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            }
            
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (!isWalk)
            {
                animCounter = 0f;
                isWalk = true;
                isRun = false;
                isIdle = false;
            }

            speed = 2f;

            animCounter += Time.deltaTime;
            targetAnimationValue = walkValue;
            if (animationValue < targetAnimationValue)
            {
                animationValue = animCurve.Evaluate(animCounter * interpolateSpd);
                
                anim.SetFloat("Blend", animationValue);
            }
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
        else
        {
            if (!isIdle)
            {
                animCounter = 0f;
                isWalk = false;
                isRun = false;
                isIdle = true;
            }
            animCounter += Time.deltaTime;
            targetAnimationValue = idleValue;
            if (animationValue > targetAnimationValue)
            {
                animationValue = idleCurve.Evaluate(animCounter * interpolateSpd);

                anim.SetFloat("Blend", animationValue);
            }

            //anim.SetFloat("Blend", 0f);
            //animCounter = 0f;
            //animationValue = 0f;
            
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
