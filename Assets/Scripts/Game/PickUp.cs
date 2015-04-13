using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	//sends message if collision happens, expand this for each pickup
	void OnCollisionEnter2D(Collision2D collision)
	{
		//send a message of type of hit - armour, spikes, nitro, supplies, zombies, barricades etc
		collision.gameObject.BroadcastMessage ("Hit", this, SendMessageOptions.DontRequireReceiver);

		//you will either need a different script and message for each type of pickup
		//or a universal message (eg "Hit") that also passes what type of hit it was (pickup etc)
		//the player script can then figure out what to do and how

		//"PickupArmour"
		//"PickupSpikes"
		//"PickupNitro"
		//"PickupSupplies"
		//"ObstacleSoloZombie"
		//"ObstacleHordeZombie"
		//"ObstacleBarricade"

		//for each of these have a function within the player
		//these will check and apply what is required for the player
		//(eg pickup to use, score, damage reduction, speed reduction etc)

		//removes game object from the scene after message is sent
		GameObject.Destroy(gameObject);
	}
}
