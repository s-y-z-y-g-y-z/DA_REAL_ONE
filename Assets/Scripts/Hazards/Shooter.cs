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
        var bullet = (GameObject)Instantiate(dart, new Vector3(transform.position.x - 0.75f, transform.position.y, transform.position.z), transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * -5;

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
