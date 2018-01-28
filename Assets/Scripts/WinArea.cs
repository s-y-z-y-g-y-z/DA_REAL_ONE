using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * JOSH KARMEL
 * USED
 * 
 * ATTACHED TO THE WIN AREA OBJECT
*/

public class WinArea : MonoBehaviour {

    //PUBLIC REFERENCED SCRIPTS
    public ParameterScreen ps;      //to pause the game
    public GM gm;

    [HideInInspector]
    public bool win;

	// Use this for initialization
	void Start () {
        win = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ps.isPaused = true;
            win = true;
        }
    }
}
