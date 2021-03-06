﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;
    private float flickAngle = -20;

    private int rightid, leftid;
    private bool righttouch, lefttouch;

    // Use this for initialization
    void Start () {
        
    myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
		if(Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        //追加課題
        
            foreach(Touch touch in Input.touches)
            {
                
                
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (touch.position.x >= Screen.width / 2 && tag == "RightFripperTag" && righttouch == false) 
                        {
                            SetAngle(this.flickAngle);
                            rightid = touch.fingerId;
                            righttouch = true;

                        }else if(touch.position.x < Screen.width / 2 && tag == "LeftFripperTag" && lefttouch == false)
                        {
                            SetAngle(this.flickAngle);
                            leftid = touch.fingerId;
                            lefttouch = true;
                        }
                        break;


                    case TouchPhase.Ended:
                    if (tag == "RightFripperTag" && rightid == touch.fingerId && righttouch == true)
                        {
                            SetAngle(this.defaultAngle);
                            righttouch = false;
                        }
                        else if (tag == "LeftFripperTag" && leftid == touch.fingerId && lefttouch == true)
                        {
                            SetAngle(this.defaultAngle);
                            lefttouch = false;
                        }
                        break;
                }
            }
	}

    void SetAngle(float angle)
    {
        
        JointSpring JointSpr = this.myHingeJoint.spring;
        JointSpr.targetPosition = angle;
        this.myHingeJoint.spring = JointSpr;
        
    }
}
