using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh namespace to access the functions

public class ScoreText : MonoBehaviour {

    private TextMeshPro myText;
   
	void Awake () {
        myText = GetComponent<TextMeshPro>();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = "Score: " + GameManager.instance.score + " Best: " + GameManager.instance.highScore;
    }
}
