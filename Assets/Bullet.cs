using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int player { get; set; }
    public bool stuck { get; set; }
    private bool previouslyStuck;

    private Rigidbody rb;

    public Material[] materials;
	// Use this for initialization
	void Start () {
	}
	
    public void Initialize(int player)
    {
        this.player = player;
        this.stuck = false;
        this.rb = GetComponent<Rigidbody>();

        GetComponent<Renderer>().sharedMaterial = materials[player];
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            if (!stuck && !previouslyStuck)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.useGravity = false;
                stuck = true;
            }
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            
            Debug.Log("hit");
            if (stuck)
            {
                rb.useGravity = false;
                stuck = false;
                previouslyStuck = true;
            }

        }
    }
}
