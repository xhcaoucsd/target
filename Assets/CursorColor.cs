using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorColor : MonoBehaviour {

    public Material[] materials;
    public GameObject objectSpawner;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().sharedMaterial = materials[0];
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().sharedMaterial = materials[objectSpawner.GetComponent<SpawnerController>().currentPlayer];
    }
}
