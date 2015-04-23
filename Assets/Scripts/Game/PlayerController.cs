using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private GameController gameController;
    public Blood bloodPrefab;

    private float gameoverTime = 2f;
    private float gameoverTimer;
    public bool hasBeenHit, armourPickedUp;

    public float playerSpeed;
    private float playerAcceleration;
    private float playerBreak;
    private UIScore score;
    public float SpikeTime;
	private Rigidbody2D carPhy;

    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        score = GameObject.FindObjectOfType<UIScore>();
		carPhy = GetComponent<Rigidbody2D> ();

        //sets initial values
        playerAcceleration = 5 * Time.deltaTime;
        playerBreak = 10 * Time.deltaTime;
        playerSpeed = 0f;
        SpikeTime = 0f;
    }

    void Update()
    {
        //this line will always move the car based on its "current" speed
        //transform.position += transform.right * playerSpeed * Time.deltaTime;

		///Moving the transform doesn't corellate with the mass, nor that the car drops slower or gained more height,
		/// Thus, the car might net to be pushed by physcial instead (Jefone)
		/// 

		carPhy.AddRelativeForce (Vector2.right * playerSpeed, ForceMode2D.Force);

        //if the Right Arrow is pressed, and the speed is lower than 5
        //speed will be set to 5, gives some instant acceleration
        if (playerSpeed < 5 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerSpeed = 5;
        }

        //handles speed increase/decrease based on Right Arrow input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SpeedUp();
        }
        else
        {
            SpeedDown();
        }

        //handles breaking based on Left Arrow input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SpeedBreak();
        }

        //prevents player moving backwards while no key is being held
        if (playerSpeed < 0 && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            playerSpeed = 0;
        }

        //left over from what this prototype was before this
        //keep as it may be useful to reset the car if it gets stuck
        if (gameoverTimer > 0)
        {
            gameoverTimer -= Time.deltaTime;
            if (gameoverTimer <= 0)
            {
                gameController.GameOver();
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            carPhy.mass = 5;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
			carPhy.mass = 0.01f; //reduced (Jefone)
        }
        else
        {
            if (carPhy.mass != 1)
            {
                carPhy.mass = 1;
            }
        }
    }

    //handles increasing the player speed over time
    void SpeedUp()
    {
        if (playerSpeed < 15f)
        {
            playerSpeed += playerAcceleration;
        }
    }

    //handles decreasing the player speed over time
    void SpeedDown()
    {
        if (playerSpeed > 0f)
        {
            playerSpeed -= playerAcceleration;
        }
    }

    //handles decreasing the player speed over time, faster than slowdown
    void SpeedBreak()
    {
        if (playerSpeed > 5f)
        {
            playerSpeed -= playerBreak;
        }
    }

    //current hit function, just ends the game after spawning some 'blood'
    //expand for each type of hit, see "Car" script for more details
    void HittedZombieHeard()
    {
        //blood can be used on the zombies
        //Blood newBlood = GameObject.Instantiate(bloodPrefab) as Blood;
        //newBlood.transform.position = transform.position;
		//For some reaons Blood.cs can't be attached at all (Jefone)

        //hit check is used for gameover and to 'turn off' some functions
        //may be useful for  other things, or remove when other stuff is working
        if (armourPickedUp == false && SpikeTime <= 0)
        {
			playerSpeed *= 0.1f;
        }

		//score.SetScore (80);

		if (armourPickedUp && SpikeTime <= 0) {
			armourPickedUp = false;
		}

		if (SpikeTime > 0) {
			SpikeTime--;
		}
    }

    //USE the functions below for the pickup messages

    void PickupArmour()
    {
        //something here to add armour pickup
        armourPickedUp = true; //As the current set up, armour will protect player once (Jefone);

    }

    void PickupSpikes()
    {
        //something here to add spikes pickup
        SpikeTime = 10;
    }

    void PickupNitro()
    {
        //something here to add nitro pickup
        //Give player a slight boost in their current speed.
        playerSpeed *= 1.5f;
    }

    void PickupSupplies()
    {
        //something here to add supplie score
		print ("picked up subs");
    }

    void ObstacleSoloZombie()
    {
        //something here to run single zombie hit - score, damage
    }

    void ObstacleBarricade()
    {
        //something here to add barricade hit - slow speed
        score.SetScore(98);
        if (SpikeTime <= 0)
        {
            playerSpeed *= 0.5f;
        }
        else
        {
            SpikeTime--;
        }
    }
}
