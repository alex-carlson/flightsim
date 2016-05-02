using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

public class cameraBehavior : MonoBehaviour {

    [Range(45, 120)] public float fov;
    Rigidbody rb;
    bool targetPlayer = true;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

	
	// Update is called once per frame
	void Update () {
        GetComponent<Camera>().fieldOfView = fov + rb.velocity.magnitude / 2;

        if (Input.GetButton("Fire2"))
        {
            if (targetPlayer == true)
            {
                targetPlayer = false;
                GetComponent<LookatTarget>().SetTarget(transform.parent.transform);
            }
            else
            {
                targetPlayer = true;
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].GetComponent<controller>().playerID != transform.parent.GetComponent<controller>().playerID)
                    {
                        Debug.Log(transform.parent.name +", "+ players[i].name);
                        GetComponent<LookatTarget>().SetTarget(players[i].transform);
                    }
                }
            }
        }
	}
}
