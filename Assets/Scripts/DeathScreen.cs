using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * USED
 * JOSH KARMEL
 * 
 * ATTACHED TO THE DEATHSCREEN
*/

public class DeathScreen : MonoBehaviour {

    //PUBLIC SCRIPT REFERENCES
    public GM gm;

    //public buttons
    public Button reset;
    public Button menu;
    public Text scoreText;
    public GameObject targetPos;
    private Vector3 initPos;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GM>();
        reset.onClick.AddListener(buttonReset);
        menu.onClick.AddListener(buttonMenu);
        scoreText.text = "Score: ";
        initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + gm.calculateScore();
        if(gameObject.activeSelf)
        {
            gm.LerpUI(gameObject, targetPos.transform.position, 5f, true);
        }
	}

    public void buttonReset()
    {
        gm.ResetScene();
        transform.position = initPos;

    }

    public void buttonMenu()
    {
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
    }
}
