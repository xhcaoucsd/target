using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Material[] materials;

    private int playerBlueStuck;
    private int playerPinkStuck;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet.player == 0) playerPinkStuck++;
            else playerBlueStuck++;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet.player == 0) playerPinkStuck--;
            else playerBlueStuck--;
        }
    }

    public void winMaterial(int player)
    {
        if (player == 0)
            GetComponent<Renderer>().sharedMaterial = materials[0];
        else 
            GetComponent<Renderer>().sharedMaterial = materials[1];
    }

    public int score()
    {
        if (playerPinkStuck > playerBlueStuck) return 0;
        else if (playerPinkStuck < playerBlueStuck) return 1;
        else return 0;
    }
}
