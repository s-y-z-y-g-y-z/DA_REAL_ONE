using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrans : MonoBehaviour {
    private float x;
    private float y;
    private float z;
    private float rx;
    private float ry;
    private float rz;
    private GM gm;
	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GM>();
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        rx = transform.eulerAngles.x;
        ry = transform.eulerAngles.y;
        rz = transform.eulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.resetLevel == true)
        {
            transform.eulerAngles = new Vector3(rx, ry, rz);
            transform.position = new Vector3(x, y, z);
        }
		
	}
}
