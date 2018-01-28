using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * USED 
 * JOSH KARMEL
 * 
 * The parameter screen
 * 
 * script attached to the CameraRig
*/

public class ParameterScreen : MonoBehaviour {

    //Script References
    public SideScrollController player;
    public WeponRecoil gunRecoil;
    public GrappleController hook;
    public CameraController cam;
    public GM gm;

    //references the Canvas Text
    public Image paramScreen;
    public GameObject pauseScreen;

    //player sliders attached to SideScrollerController on the player
    public Slider groundAccSlider;
    public Text GANum;
    public Slider airAccSlider;
    public Text AANum;
    public Slider jumpPowerSlider;
    public Text JPNum;
    public Slider maxSpeedSlider;
    public Text MaxSpeedNum;
    public Slider stickForceSlider;
    public Text SFNum;
    public Toggle isSideScrollingToggle;

    //recoil sliders attached to WeponRecoil on the gun of the player
    public Slider recoilSpeedSlider;
    public Text RSNum;
    public Slider recoilLengthSlider;
    public Text RLNum;

    //grapple sliders attached the GrappleController on the player
    public Slider hookRangeSlider;
    public Text HRNum;
    public Slider hookPowerSlider;
    public Text HPNum;
    public Slider hookRecoilForceSlider;
    public Text HRFNum;
    public Slider hookMassInfluenceSlider;
    public Text HMINum;
    //rope
    public Slider ropeSmoothSlider;
    public Text ropeSNum;
    public Slider ropeDroopSlider;
    public Text RDNum;

    //camera
    public Slider camMovementDampSlider;
    public Text CMDNum;
    public Slider camDistanceSlider;
    public Text CDNum;

    //the score nuber in the HUD
    public Text scoreNum;
    
    public bool isPaused;

    public FWSInput finput;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<SideScrollController>();
        gunRecoil = FindObjectOfType<WeponRecoil>();
        hook = FindObjectOfType<GrappleController>();
        cam = FindObjectOfType<CameraController>();
        gm = FindObjectOfType<GM>();
        isPaused = false;
        paramScreen.gameObject.SetActive(false);
        pauseScreen.SetActive(false);
        updateSliders();
    }
	
	// Update is called once per frame
	void Update () {
        updateScripts();
        updateScore();
        //checkPause();

        if (isPaused && Input.GetButtonDown("Jump"))
        {
            gm.ResetScene();
            pauseScreen.gameObject.SetActive(false);
        }
    }

    /*
     * MOVED TO THE GM
    //checks isPaused to stop the Time
    public void checkPause()
    {
        //pauses the game
        if (isPaused && !player.isDead && !gm.gameOver)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
    */

    //Called in fInput.cs when escape is pressed
    public void handleParamScreen()
    {
        //changes staus of being paused
        isPaused = !isPaused;

        //pauses the game and changes the text on the canvas
        if (isPaused)
        {
            paramScreen.gameObject.SetActive(true);
        }
        else
        {
            paramScreen.gameObject.SetActive(false);
        }
    }

    //Calls in the pause screen
    public void handlePauseScreen()
    {
        isPaused = !isPaused;

        if (isPaused && !gm.gameOver && !player.isDead)
        {
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseScreen.gameObject.SetActive(false);
        }
    }
    
    //all values are updated from the slider values
    public void updateScripts()
    {
        //player
        player.groundAccelerationPower = groundAccSlider.value;
        player.airAccelerationPower = airAccSlider.value;
        player.jumpPower = jumpPowerSlider.value;
        player.maxSpeed = maxSpeedSlider.value;
        player.stickForce = stickForceSlider.value;
        player.isSideScrolling = isSideScrollingToggle.isOn;

        //recoil
        //gunRecoil.recoilSpeed = recoilSpeedSlider.value;
        //gunRecoil.recoilLength = recoilLengthSlider.value;

        //hook
        hook.maxRopeRange = hookRangeSlider.value;
        hook.power = hookPowerSlider.value;
        hook.recoilForce = hookRecoilForceSlider.value;
        hook.massInfluence = hookMassInfluenceSlider.value;
        //rope
        hook.ropeSmoothness = (int)ropeSmoothSlider.value;
        hook.ropeDroop = ropeDroopSlider.value;

        //camera
        //cam.movementDamp = camMovementDampSlider.value;
        cam.distance = camDistanceSlider.value;

        updateSliders();
    }
 
    //all slider values are set from the player initial values
    public void updateSliders()
    {
        //player values
        groundAccSlider.value = player.groundAccelerationPower;
        GANum.text = player.groundAccelerationPower.ToString();

        airAccSlider.value = player.airAccelerationPower;
        AANum.text = player.airAccelerationPower.ToString();

        jumpPowerSlider.value = player.jumpPower;
        JPNum.text = player.jumpPower.ToString();

        maxSpeedSlider.value = player.maxSpeed;
        MaxSpeedNum.text = player.maxSpeed.ToString();

        stickForceSlider.value = player.stickForce;
        SFNum.text = player.stickForce.ToString();

        isSideScrollingToggle.isOn = player.isSideScrolling;

        //recoil values
        recoilSpeedSlider.value = gunRecoil.recoilSpeed;
        RSNum.text = gunRecoil.recoilSpeed.ToString();

        recoilLengthSlider.value = gunRecoil.recoilLength;
        RLNum.text = gunRecoil.recoilLength.ToString();

        //hook
        hookRangeSlider.value = hook.maxRopeRange;
        HRNum.text = hook.maxRopeRange.ToString();

        hookPowerSlider.value = hook.power;
        HPNum.text = hook.power.ToString();

        hookRecoilForceSlider.value = hook.recoilForce;
        HRFNum.text = hook.recoilForce.ToString();

        hookMassInfluenceSlider.value = hook.massInfluence;
        HMINum.text = hook.massInfluence.ToString();
        //rope
        ropeSmoothSlider.value = hook.ropeSmoothness;
        ropeSNum.text = hook.ropeSmoothness.ToString();

        ropeDroopSlider.value = hook.ropeDroop;
        RDNum.text = hook.ropeDroop.ToString();

        //camera
        //camMovementDampSlider.value = cam.movementDamp;
        //CMDNum.text = cam.movementDamp.ToString();
        camDistanceSlider.value = cam.distance;
        CDNum.text = cam.distance.ToString();
    }

    //sends data to the text in the UI
    public void updateScore()
    {
        scoreNum.text = gm.colScore.ToString();
    }
   
}
