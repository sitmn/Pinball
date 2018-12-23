using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int point;
    
    private int smallstarhit = 50;
    private int largestarhit = 20;
    private int smallcloudhit = 10;
    private int largecloudhit = 80;
    
    private GameObject scorepoint;
    private GameObject ball;

    private BallController ballcontroller;
    private Text scoretext;
   
    
    // Use this for initialization
    void Start () {
        this.ball = GameObject.Find("Ball");
        this.ballcontroller = this.ball.GetComponent<BallController>();
    
        this.scorepoint = GameObject.Find("Scorepoint");
        this.scoretext = this.scorepoint.GetComponent<Text>();

        //タグ別にポイントを代入
        if (tag == "SmallStarTag")
        {
            this.point = smallstarhit;
        }
        else if (tag == "LargeStarTag")
        {
            this.point = largestarhit;
        }
        else if (tag == "SmallCloudTag")
        {
            this.point = smallcloudhit;
        }else if(tag == "LargeCloudTag")
        {
            this.point = largecloudhit;
        }

        this.scoretext.text = "score" + ballcontroller.score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        ballcontroller.score += this.point;
        this.scoretext.text = "score"+ ballcontroller.score;
    }
}
