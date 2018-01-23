using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("in");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("dest");
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
