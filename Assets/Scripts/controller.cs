using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controller : MonoBehaviour {

    public int Health = 100;
    public int maxSpeed = 30;
    Vector3 speed;
    Vector3 rotation;
    Rigidbody rb;
    public int playerID;
    Text speedUI;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        //rb.AddForce(transform.right * 10, ForceMode.Impulse);
        playerID = transform.GetSiblingIndex();
        //Debug.Log(playerID * 0.5f);
        transform.FindChild("Camera").GetComponent<Camera>().rect = new Rect(playerID * 0.5f, 0, 0.5f, 1);
        speedUI = transform.GetComponentInChildren<Text>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = Input.GetAxis("Horizontal"+playerID);
        float y = Input.GetAxis("Vertical"+playerID);
        bool dash = Input.GetButtonDown("Jump"+playerID);

        // base movement

        rb.AddRelativeTorque(new Vector3(x * -2, 0, y * -2), ForceMode.Acceleration);
        if(rb.velocity.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(Vector3.right * 85f);
        }

        //speed boost
        if (dash)
        {
            rb.AddRelativeForce(Vector3.right * 400, ForceMode.Impulse);
        }

        string speednum = Mathf.Round(rb.velocity.magnitude * 1000) / 100 + " MPH";

        speedUI.text = speednum;

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Player")
        {
            float theirSpeed = col.transform.GetComponent<Rigidbody>().velocity.magnitude;
            if(theirSpeed > rb.velocity.magnitude)
            {
                Debug.Log("ow");
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (transform.right * 10));
    }
}
