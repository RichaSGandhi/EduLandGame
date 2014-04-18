using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float maxSpeed = 7f;
	bool facingRight= true;
	string scoreText;
	private int score;
	public GUIStyle labelStyle;
	Animator Anim;
	public bool interact = false;
	public Transform lineStart, lineEnd;
	public RaycastHit2D whatIHit;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 100f;
	public string stringToEdit;
	private string stringToDisplay;
	private bool isCollision = true;
	public AudioClip clip;


	bool doubleJump = false;
	public static bool destroyedPrevious= false;
	public static float timer;

	void Start ()
	{
		Anim = GetComponent<Animator> ();
		GameObject spawner = GameObject.Find ("Spawner");
		SpawnMultipleObject anotherScript = spawner.GetComponent<SpawnMultipleObject> ();
		anotherScript.spawnRandomObject (-1);
		scoreText = "Score : " + score.ToString();

	}
	
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		Anim.SetBool ("Ground", grounded);

		if (grounded) {
			doubleJump = false;
		}


		Anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);


		float move = Input.GetAxis ("Horizontal");

		Anim.SetFloat ("Speed", Mathf.Abs(move));

		if (move > 0 && /*GameObject.Find ("object1").*/transform.position.x < 4) {
			//maxSpeed = 1000;
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		}
		else if (move < 0 && /*GameObject.Find ("object1").*/transform.position.x <= 8.5f) {	
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		}

	
		if (move > 0 && !facingRight)
						Flip ();
				
		else if (move < 0 && facingRight)
						Flip ();
	}
	void Raycast(){
		Debug.DrawLine (lineStart.position, lineEnd.position, Color.white);
		whatIHit = Physics2D.Linecast (lineStart.position, lineEnd.position, 1<< LayerMask.NameToLayer("Enemies"));
		if (whatIHit) {
						interact = true;
				} else {
						interact = false;
				}
	}


	void Update()
	{
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
			Anim.SetBool ("Ground", false);
			//rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if(!doubleJump && !grounded){
				doubleJump = true;
				rigidbody2D.AddForce(new Vector2(0, jumpForce/2));
				audio.PlayOneShot(clip);
			}
			else{
				rigidbody2D.AddForce(new Vector2(0, jumpForce));
				audio.PlayOneShot (clip);
			}

		}
		Raycast ();
		if(Input.GetKeyDown(KeyCode.Return) && isCollision == true){
			interact = false; 
			whatIHit = Physics2D.Linecast (lineStart.position, lineEnd.position, 1<< LayerMask.NameToLayer("Enemies"));
			Debug.Log ("Destroying" +whatIHit.collider.gameObject.name);
			Destroy(whatIHit.collider.gameObject);
			destroyedPrevious = true;
			score = score + 1;
			scoreText = "Score : " + score.ToString();
			SpawnMultipleObject.startTime = Time.time;
			stringToEdit = "";
		}

	
	}


	void Flip (){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	//void OnCollisionEnter(Collision hit)
	//{
		//stringToEdit = "Hi Please name me";
		//isCollision = true;
	//}
	
	void OnGUI () {
		GUI.Label(new Rect (1200, 25, 30, 30), scoreText, labelStyle);


		if (interact) {
			stringToEdit = GUI.TextField (new Rect (500, 25, 200, 30), stringToEdit, 25);
			char[] endClone = {'C','l','o','n','e','(',')'};
			if(whatIHit)
			{
				//Debug.Log(whatIHit.collider.gameObject.name.TrimEnd(endClone));
				//string objectName = ;
			
			if (stringToEdit == whatIHit.collider.gameObject.name.TrimEnd(endClone)){
				stringToDisplay = "Cool, Hit 'Enter' and Go ahead!";
				GUI.Label(new Rect (500, 55, 200, 60), stringToDisplay);
				isCollision = true;
			}
			else{
				isCollision = false;
				stringToDisplay = "Hey!! What's my name?";
				GUI.Label(new Rect (500, 55, 200, 60), stringToDisplay);
			}
		}
	}
}
}

