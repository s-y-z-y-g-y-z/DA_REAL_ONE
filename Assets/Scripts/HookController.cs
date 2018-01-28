using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * USED
 * BEN SPURR
 * 
 * sends information to GrappleController.cs
*/

public class HookController : MonoBehaviour {

    //force needed to set hook
    public float impactThreshold; //NEEDS FIXIN'

    //privates
    private Rigidbody hookRb;
    private GrappleController grapple;

	// Use this for initialization
	void Start ()
    {
        hookRb = gameObject.GetComponent<Rigidbody>();
        grapple = FindObjectOfType<GrappleController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		//NEED TO ADD NODE GENERATOR FOR BETTER ROPES
	}

    private void OnCollisionEnter(Collision col)
    {

        //hook can't hook the player
        if (col.gameObject.tag != "Player")
        {
            //calls SetHook() from GrappleController.cs
            grapple.SetHook(col.gameObject.GetComponent<Rigidbody>());
        }
        else
        {
            Debug.Log("hookRb instantiated inside player");
            Physics.IgnoreCollision(col.gameObject.GetComponent<CapsuleCollider>(), GetComponent<SphereCollider>());
        }
    }
}
