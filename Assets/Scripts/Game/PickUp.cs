using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	//We could use this script for all kind of pickups (Jefone) 
	public enum TypesOfPickUP {
		armour,
		spike,
		nitro,
		supplies,
		zombieSolo,
		zomebieHeard,
		barricade
	}

	public TypesOfPickUP thisPickUp;

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
		//collision.gameObject.BroadcastMessage ("Hit", this, SendMessageOptions.DontRequireReceiver);

		//The list will be longer, but for now if this works then others must works as well(Jefone)
		switch (thisPickUp) {
		case TypesOfPickUP.armour:
			collision.gameObject.BroadcastMessage ("PickupArmour", SendMessageOptions.DontRequireReceiver);
			break;
		case TypesOfPickUP.zombieSolo:
			collision.gameObject.BroadcastMessage ("Hit", SendMessageOptions.DontRequireReceiver);
			break;
		case TypesOfPickUP.nitro:
			collision.gameObject.BroadcastMessage("PickupNitro", SendMessageOptions.DontRequireReceiver);
			break;
		case TypesOfPickUP.barricade:
			collision.gameObject.BroadcastMessage("ObstacleBarricade", SendMessageOptions.DontRequireReceiver);
			break;
		case TypesOfPickUP.spike:
			collision.gameObject.BroadcastMessage("PickupSpikes", SendMessageOptions.DontRequireReceiver);
			break;
			//Do similar things with the other enum types.
		}
		

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
		//Speical case for barricade (Jefone)
		if (thisPickUp != TypesOfPickUP.barricade) {
			GameObject.Destroy (gameObject);
		}

		//This might be over killed (Jefone);
		if (thisPickUp == TypesOfPickUP.barricade && collision.gameObject.CompareTag("Player")) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10, ForceMode2D.Impulse);
		}
	}
}
