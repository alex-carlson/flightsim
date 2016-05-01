using UnityEngine;
using System.Collections;

public class cameraBehavior : MonoBehaviour {

    [Range(45, 120)] public float fov;
    Rigidbody rb;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

	
	// Update is called once per frame
	void Update () {
        GetComponent<Camera>().fov = fov + rb.velocity.magnitude / 2;

	}
}
