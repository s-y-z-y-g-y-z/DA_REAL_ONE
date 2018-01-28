using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Trap {

    public GameObject dart;

	// Use this for initialization
	void Start () {
        active = false;
	}

    public void shoot()
    {
        var bullet = (GameObject)Instantiate(dart, transform.position + (transform.forward * 2), transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 5;

        Destroy(bullet, 2.0f);
        active = false;
    }

    public override void checkActive()
    {
        if (active)
        {
            shoot();
        }
    }
}
