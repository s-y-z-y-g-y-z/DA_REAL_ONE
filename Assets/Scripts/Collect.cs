using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * JOSH KARMEL
 * USED
 * 
 * ATTACHED TO COLLECTABLES
*/

public class Collect : MonoBehaviour {

    //PUBLIC SCRIPT REFERENCES
    public GM gm;
    public HealthDepletion hd;
    public SideScrollController pCtrl;

    private void Start()
    {
        gm = FindObjectOfType<GM>();
        hd = FindObjectOfType<HealthDepletion>();
        pCtrl = FindObjectOfType<SideScrollController>();
        
    }

    private void Update()
    {
        rotateBox();
    }

    //rotates the mesh, not the collider
    public void rotateBox()
    {
        if (tag == "Collectable")
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 60, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //handles collectible count, then special collectible attribute, then the object deactivates
        if (other.gameObject.tag == "Player" && tag == "CollectableCollider")
        {
            gm.HandleColScore(1);

            if(transform.parent.tag == "normieCollectible")
            {
                //normie special TBD
				hd.handleHealth(5, false);
            }
            else if(transform.parent.tag == "healCollectible")
            {
                hd.handleHealth(1, true);
            }
            else if(transform.parent.tag == "scoreCollectible")
            {
                gm.HandleBonusColScore();
            }
            else if(transform.parent.tag == "dmgCollectible")
            {
                //possible hurtful collectible
            }

            transform.parent.gameObject.SetActive(false);
        }
    }

    
}
