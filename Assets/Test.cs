using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 dir = Camera.main.transform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, dir);
        // transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 1.0f* Time.fixedDeltaTime);

        //transform.rotation = toRotation;
        Debug.Log("dir " + dir);
        Debug.Log("rot " + toRotation.eulerAngles);
        //transform.rotation = toRotation;
        transform.LookAt(Camera.main.transform.position);
    }
}
