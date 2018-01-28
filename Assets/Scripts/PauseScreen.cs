using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    //PUBLIC SCRIPT REFERENCES
    public GM gm;
    public ParameterScreen ps;

    //public buttons
    public Button reset;
    public Button menu;
    public GameObject targetPos;
    public Vector3 initPos;

    // Use this for initialization
    void Start () {

        gm = FindObjectOfType<GM>();
        ps = FindObjectOfType<ParameterScreen>();
        reset.onClick.AddListener(buttonReset);
        menu.onClick.AddListener(buttonMenu);
        initPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.transform.position = initPos;
        }

        if (gameObject.activeSelf)
        {
            gm.LerpUI(gameObject, targetPos.transform.position, 5f, true);
        }
    }

    public void buttonReset()
    {
        gm.ResetScene();
        gameObject.SetActive(false);

    }

    public void buttonMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
