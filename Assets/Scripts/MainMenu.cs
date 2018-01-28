using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/* USED
 * =================
 * Zachary Lopez
 * 
 * Script for controlling Main Menu Screen including
 * Starting from Level 1
 * Selecting a level by switching scenes
 * Quit and exit application
 */
public class MainMenu : MonoBehaviour {

	public Button start; 
	public Button lvl;
	public Button quit;
	public Canvas menu;
	public Canvas select;
	// Use this for initialization
	// adding listeners to buttons
	void Start () {

		Button btn = start.GetComponent<Button> ();
		btn.onClick.AddListener (GameStart);

		btn = quit.GetComponent<Button> ();
		btn.onClick.AddListener (Quit);

		btn = lvl.GetComponent<Button> ();
		btn.onClick.AddListener (LevelSelect);

	}
	// Start the game, proto scene
	void GameStart()
	{
		SceneManager.LoadScene ("Level_1", LoadSceneMode.Single);
	}

	//Quits out application
	void Quit()
	{
		Application.Quit ();
	}

	//seperact scene?
	void LevelSelect()
	{
		menu.enabled = false;
		select.enabled = true;
	}
		
}
