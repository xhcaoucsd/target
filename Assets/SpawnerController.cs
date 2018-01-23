using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SpawnerController : MonoBehaviour, IInputClickHandler {
    public GameObject pf_Target;
    public GameObject pf_Bullet;

    public float defaultDistance = 3.0f;
    public float bulletForce = 150.0f;
    public float speed = 100.0f;
    public int shotsPerTurn = 3;
    public int maxRounds = 2;

    private bool isPlacingTarget = false;
    private bool targetPlaced = false;


    private int round = 1;
    private GameObject ins_Target;

    // 0: pink 1: blue
    public int playerTurn { get; set; }
    public int currentPlayer { get; set; }
    public bool gameOn { get; set; }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!gameOn) {
            return;
        }
        Debug.Log("clicked");
        if (!targetPlaced && !isPlacingTarget)
        {
            ins_Target = Instantiate(pf_Target);
            ins_Target.GetComponentInChildren<Collider>().enabled = false;
            isPlacingTarget = true;
        }
        else if (isPlacingTarget)
        {
            isPlacingTarget = false;
            targetPlaced = true;
            ins_Target.GetComponentInChildren<Collider>().enabled = true;
        }
        else if (targetPlaced)
        {
            GameObject ins_Bullet = Instantiate(pf_Bullet, Camera.main.transform.position, Quaternion.identity);
            
            ins_Bullet.GetComponent<Bullet>().Initialize(playerTurn / shotsPerTurn);
            ins_Bullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletForce);
            playerTurn = ++playerTurn % (2 * shotsPerTurn);
            Debug.Log(playerTurn);
            currentPlayer = playerTurn / shotsPerTurn;
            if (playerTurn % (2 * shotsPerTurn) == 0)
            {
                round++;
                if (round == maxRounds)
                {
                    shotsPerTurn = 1;
                }
            }
        }
    }
    // Use this for initialization
    void Start () {
        this.gameOn = true;
        this.playerTurn = 0;
        InputManager.Instance.PushModalInputHandler(gameObject);
        this.ins_Target = null;
        Physics.gravity = Vector3.down * 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (round > maxRounds)
        {
            gameOn = false;
            ins_Target.GetComponentInChildren<Target>().winMaterial(ins_Target.GetComponentInChildren<Target>().score());

        }
        if (isPlacingTarget && ins_Target != null)
        {
            RaycastHit hitInfo;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo))
            {
                ins_Target.transform.position = hitInfo.point;
            }
            else
            {
                ins_Target.transform.position = Camera.main.transform.position + Camera.main.transform.forward * defaultDistance;
            }

    
            ins_Target.transform.LookAt(Camera.main.transform.position);
        }
    }
}
