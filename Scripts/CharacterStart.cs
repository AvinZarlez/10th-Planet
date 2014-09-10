using UnityEngine;

//This scrits makes the character move when the screen is pressed and handles the jump
public class CharacterStart : MonoBehaviour
{
	public bool jump = false;				// Condition for whether the player should jump.	
	public float jumpForce = 10.0f;			// Amount of force added when the player jumps.
	private bool grounded = false;			// Whether or not the player is grounded.
	public bool startedMovement = false; 	// Is the character moving?
	public int movementSpeed = 10;			// The vertical speed of the movement

	//Called when the game starts, but we set our movement variable to false, so we activate it later
	void Start()
	{
		startedMovement = false;
	}

	//This method is called when the character collides with a collider (could be a platform).
	void OnCollisionEnter2D(Collision2D hit)
	{
		grounded = true;
	}

	//The update method is called many times per seconds
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{		
			// If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
		    if( (grounded == true) && (startedMovement == true))						
			{
				jump = true;
				grounded = false;
			}
			else // if the game is set now to start the character will start to run forward in the FixedUpdate
			{
				startedMovement = true;
			}
		}
	}

	//Since we are using physics for movement, we use the FixedUpdate method
	void FixedUpdate ()
	{
		// If the character started moving, we move him forward
		if (startedMovement == true) 
		{
			rigidbody2D.velocity = new Vector2(movementSpeed, rigidbody2D.velocity.y );
		}

		// If jump is set to true we add a quick force impulse for the jump
		if(jump == true)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);

			// We set the variable to false again to avoid adding force constantly
			jump = false;
		}
	}
}
