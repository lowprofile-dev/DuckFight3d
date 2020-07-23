using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
    GameManager gameManager;

	// Update is called once per frame
	void Update () {
        // Time Remaining: 0:37

        if (gameManager.TimeLeft > 0)
        {
            System.TimeSpan ts = new System.TimeSpan(0, 0, 0, Mathf.CeilToInt(gameManager.TimeLeft));

            string s = System.String.Format("Time Remaining: {0:d2}:{1:d2}", ts.Minutes, ts.Seconds);

            GetComponent<Text>().text = s;
        }
        else
        {
            GetComponent<Text>().text = "Time for bed!";
        }
	}
}
