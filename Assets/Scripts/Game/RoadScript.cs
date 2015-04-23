using UnityEngine;
using System.Collections;

public class RoadScript : MonoBehaviour {

    public Vector3 RoadPos;
    public Quaternion RoadRot;

	// Use this for initialization
	void Awake () {
        RoadPos = transform.position;
        
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = RoadPos;
        transform.rotation = RoadRot;
	
	}
}
