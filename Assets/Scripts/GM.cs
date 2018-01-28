using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * JOSH KARMEL
 * BEN SPURR
 * USED
*/

public class GM : MonoBehaviour
{
    //PUBLIC REFERENCES
    private SideScrollController pCtrl;
    private FWSInput inputCtrl;
    public ParameterScreen ps;
    public HealthDepletion hd;
    public GrappleController gCtrl;
    public WinArea winArea;
   
    //PUBLIC ATTRIBUTES
    public bool resetLevel;
    public float colScore;
    public float scoreColCount;
    public float totalScore;
    public int healthVal;
    public bool touchHazard;
    public bool gameOver;
    public Text clock;
    public GameObject ks;
    public GameObject ws;
    public GameObject pauseScreen;


    private GameObject[] interactables;
	private GameObject[] hazards;
    private List<float> positions = new List<float>();
    private List<float> rotations = new List<float>();
	private List<float> h_positions = new List<float> ();
	private List<float> h_rotations = new List<float> ();
    private float timer;
    private float roundedTimer;
    private float startTime;

	// Use this for initialization
	void Start ()
    {
        resetLevel = false;
        gameOver = false;
        touchHazard = false;
        inputCtrl = FindObjectOfType<FWSInput>();
        pCtrl = FindObjectOfType<SideScrollController>();
        healthVal = hd.healthVal;
        ks.SetActive(false);
        ws.SetActive(false);
        pauseScreen.SetActive(false);
        startTime = 6000;
        timer = startTime;
		GenerateObjectArrays ();
    }

    // Update is called once per frame
    void Update()
    {
        healthVal = hd.healthVal;
        checkPause();
        checkDead();
        handlePauses();
        resetLevel = false;
    }

    //adds value to score
    public void HandleColScore(float value)
    {
        colScore += value;
    }

    public void HandleBonusColScore()
    {
        scoreColCount++;
    }

    //checks if the player is dead
    public void checkDead()
    {
        if(healthVal <= 0 || inputCtrl.reset || pCtrl.isDead)
        {
            pCtrl.isDead = true;
            pCtrl.EnableRagdoll();
            gameOver = true;
        }
        else
        {
            pCtrl.DisableRagdoll();
            gameOver = false;
        }
    }

    //handles each case for pausing
    public void handlePauses()
    {
        if (gameOver)
        {
            ks.SetActive(true);
            pCtrl.isDead = true;
            gCtrl.Retract();
            if (Input.GetButtonDown("Jump"))
            {
                ResetScene();
            }
        }
        else if (winArea.win)
        {
            ws.SetActive(true);
            gCtrl.Retract();
            if (Input.GetButtonDown("Jump"))
            {
                ResetScene();
            }
        }
        else if (ps.isPaused && !gameOver && !pCtrl.isDead)
        {
            pauseScreen.SetActive(true);
            pCtrl.DisableRagdoll();
            gCtrl.Retract();
            if (Input.GetButtonDown("Jump"))
            {
                ResetScene();
            }
        }
        else
        {
            ks.SetActive(false);
            ws.SetActive(false);
            pauseScreen.SetActive(false);
            pCtrl.isDead = false;
            updateClock();
        }
    }
    
    public void LerpUI(GameObject uiObject,Vector2 target, float speed, bool lerp)
    {
        if(lerp)
        {
            uiObject.transform.position = Vector2.Lerp(uiObject.transform.position, target, Time.unscaledDeltaTime * speed);
        }
        else
        {
            uiObject.transform.position = Vector2.MoveTowards(uiObject.transform.position, target, Time.unscaledDeltaTime * speed);
        }
    }
    
    //function to reset the scene
    public void ResetScene()
    {
        resetLevel = true;
        pCtrl.isDead = false;
        pCtrl.DisableRagdoll();
        gameOver = false;
        pCtrl.transform.position = pCtrl.initPlayerPos;
        pCtrl.playerRb.velocity = Vector3.zero;
        hd.healthVal = 100;
        scoreColCount = 0;
        totalScore = 0;
        timer = startTime;
        touchHazard = false;
        if (ps.isPaused)
        {
            ps.isPaused = false;
        }

        winArea.win = false;
        
        for (int i = 0; i < interactables.Length; i++)
        {
            interactables[i].GetComponent<Rigidbody>().isKinematic = true;
            interactables[i].transform.eulerAngles = new Vector3(rotations[i * 3], rotations[i * 3 + 1], rotations[i * 3 + 2]);
            interactables[i].transform.position = new Vector3(positions[i * 3], positions[i * 3 + 1], positions[i * 3 + 2]);
        }
    }

    public void updateClock()
    {
        timer -= Time.deltaTime * 12f;

        roundedTimer = Mathf.RoundToInt(timer);

        clock.text = roundedTimer.ToString();
    }

    //checks isPaused to stop the Time
    public void checkPause()
    {
        //pauses the game
        if (ps.isPaused && !pCtrl.isDead && !gameOver)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public float calculateScore()
    {
        if (gameOver)
        {
            roundedTimer = 0;
        }

        totalScore = roundedTimer + (colScore * 1500) + (scoreColCount * 3000);
        return totalScore;

    }

    public void kill()
    {
        gameOver = true;
    }

	private void GenerateObjectArrays()
	{
		interactables = GameObject.FindGameObjectsWithTag("Interactable");
		hazards = GameObject.FindGameObjectsWithTag ("Hazard");

		for (int i = 0; i < interactables.Length; i++)
		{
			positions.Add(interactables[i].transform.position.x);
			positions.Add(interactables[i].transform.position.y);
			positions.Add(interactables[i].transform.position.z);

			rotations.Add(interactables[i].transform.eulerAngles.x);
			rotations.Add(interactables[i].transform.eulerAngles.y);
			rotations.Add(interactables[i].transform.eulerAngles.z);
		}

		for (int i = 0; i < hazards.Length; i++) 
		{
			h_positions.Add (hazards[i].transform.position.x);
			h_positions.Add(hazards[i].transform.position.y);
			h_positions.Add(hazards[i].transform.position.z);

			h_rotations.Add (hazards[i].transform.eulerAngles.x);
			h_rotations.Add (hazards[i].transform.eulerAngles.y);
			h_rotations.Add (hazards [i].transform.eulerAngles.z);
		}
	}

	private void ResetObjects()
	{

	}
}
