using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public int playerCount = 1;
    public GameObject player;
    public GameObject spawn;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < playerCount; i++)
        {
            GameObject newPlayer = Instantiate(player, spawn.transform.GetChild(i).transform.position, spawn.transform.GetChild(i).transform.rotation) as GameObject;
            newPlayer.transform.parent = this.transform;
            newPlayer.transform.name = "Player " + i;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
