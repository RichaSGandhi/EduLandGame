 using UnityEngine;
using System.Collections;

public class testPlayer
{
	public bool facedRight = true;
	public int playerSteps=0;
	public Rigidbody2D rigid;
	public Transform trans;
	
	public bool returnYou(string tp)
	{
		facedRight = false;
		return facedRight;
	}
	
	public Vector2 setVelocity(float move, float rB2DYVelocity)
	{
		//Debug.Log ("Yayy..!! Setting new velocity from separate class");
		Vector2 vect= new Vector2();
		float xValue = move * 3f;
		float yVlaue = rB2DYVelocity;
		vect.Set(xValue,yVlaue);
		return vect;
	}
	
	public bool Flip (bool faceRight){
		bool fR;
		fR = !faceRight; 
		return fR;
	}
	
	public bool checkObsctacle(Vector3 lineStart,Vector3 lineEnd){
		bool myInteract;
		Debug.DrawLine (lineStart, lineEnd, Color.white);
		RaycastHit2D whatIsHit = Physics2D.Linecast (lineStart, lineEnd, 1<< LayerMask.NameToLayer("Enemies"));
		//return whatIsHit;
		if (whatIsHit) {
			myInteract = true;
		} else {
			myInteract = false;
		}
		
		return myInteract;
	} 
	
	public Vector2 setRigidBodyForce(bool isDoubleJump, bool isGrounded, float myJumpForce)
	{
		Vector2 forceVector = new Vector2 ();
		if(!isDoubleJump && !isGrounded)
			forceVector.Set(0, myJumpForce/2);
		else
			forceVector.Set(0, myJumpForce);
		return forceVector;
	}
	
	public bool destroyObstacle(GameObject gameObj)
	{
		bool success = false;
		//Object.Destroy (gameObj);
		Object.DestroyImmediate (gameObj);
		success = true;
		Debug.Log("returns true");
		
		return success;
	}
	
	public bool checkStringEqual(string textBoxString, GameObject gameObj)
	{
		bool isEqual = false;
		char[] endClone = {'C','l','o','n','e','(',')'};
		string trimmedString = gameObj.name.TrimEnd (endClone);
		if (textBoxString == trimmedString)
			isEqual = true;
		
		return isEqual;
	}
	
}

public class PlayerMove : MonoBehaviour {

	testPlayer tp = new testPlayer ();
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
	public string stringToDisplay;
	public bool isCollision = true;
	public AudioClip clip;
	public AudioClip clip2;
	public AudioSource[] sounds;
	public AudioSource noise1;
	public AudioSource noise2;

	bool doubleJump = false;
	public static bool destroyedPrevious= false;
	public static float timer;

	void Start ()
	{
		Anim = GetComponent<Animator> ();
		if(GameObject.Find ("Spawner")){
			GameObject spawner = GameObject.Find ("Spawner");
			SpawnMultipleObject anotherScript = spawner.GetComponent<SpawnMultipleObject> ();
			anotherScript.spawnRandomObject (-1);
		}
		scoreText = "Score : " + score.ToString();
		sounds = GetComponents<AudioSource>();
		noise1 = sounds[0];
		noise2 = sounds[1];
	}
	
	void FixedUpdate ()
	{
				//myFixedUpdate ();
		
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				Anim.SetBool ("Ground", grounded);
		
				if (grounded) {
						doubleJump = false;
				}
		
		
				Anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
				float move = Input.GetAxis ("Horizontal");
		
				Anim.SetFloat ("Speed", Mathf.Abs (move));
		
				if (move > 0 && transform.position.x < 4) {
						rigidbody2D.velocity = tp.setVelocity (move, rigidbody2D.velocity.y);// new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
				} else if (move < 0 && transform.position.x <= 8.5f) {	
						rigidbody2D.velocity = tp.setVelocity (move, rigidbody2D.velocity.y);
				}
		
		
				if (move > 0 && !facingRight) {
						facingRight = tp.Flip (facingRight);
						Vector3 theScale = transform.localScale;
						theScale.x *= -1;
						transform.localScale = theScale;				
				} else if (move < 0 && facingRight) {
						facingRight = tp.Flip (facingRight);
						Vector3 theScale = transform.localScale;
						theScale.x *= -1;
						transform.localScale = theScale;
				}
		}

	void Raycast(){
		Debug.DrawLine (lineStart.position, lineEnd.position, Color.white);
		//whatIHit = PML.checkObsctacle(lineStart.position, lineEnd.position);
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
			
			if(!doubleJump && !grounded)
				doubleJump = true;
			rigidbody2D.AddForce(tp.setRigidBodyForce(doubleJump, grounded, jumpForce));
			/*if(!doubleJump && !grounded){
				doubleJump = true;
				rigidbody2D.AddForce(new Vector2(0, jumpForce/2));
				audio.PlayOneShot(clip);
			}
			else{
				rigidbody2D.AddForce(new Vector2(0, jumpForce));
*/
			noise1.Play ();
		}
		interact = tp.checkObsctacle (lineStart.position, lineEnd.position);
		whatIHit = Physics2D.Linecast (lineStart.position, lineEnd.position, 1<< LayerMask.NameToLayer("Enemies"));
		
		if(Input.GetKeyDown(KeyCode.Return) && isCollision == true){
			interact = false; 
			//whatIHit = Physics2D.Linecast (lineStart.position, lineEnd.position, 1<< LayerMask.NameToLayer("Enemies"));
			Debug.Log ("Destroying" + whatIHit.collider.gameObject.name);
			destroyedPrevious = tp.destroyObstacle(whatIHit.collider.gameObject);
			//Destroy(whatIHit.collider.gameObject);
			//destroyedPrevious = true;
			score = score + 1;
			scoreText = "Score : " + score.ToString();
			
			SpawnMultipleObject.startTime = Time.time;
			stringToEdit = "";
			noise2.Play ();
		}

	
	}
	/*void Flip (){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}*/
	void OnGUI () {
		GUI.Label(new Rect (1200, 25, 30, 30), scoreText, labelStyle);
		
		
		if (interact) {
			GUI.color = Color.white;
			stringToEdit = GUI.TextField (new Rect (1000, 120, 200, 50), stringToEdit, 25);
			if(whatIHit)
			{
				//Debug.Log(whatIHit.collider.gameObject.name.TrimEnd(endClone));
				//string objectName = ;
				isCollision = tp.checkStringEqual(stringToEdit, whatIHit.collider.gameObject);
				if(isCollision)
					stringToDisplay ="Cool, Hit 'Enter' and Go ahead!";
				else 
					stringToDisplay = "Hey!! What's my name?";
				
				GUI.Label(new Rect (1000, 170, 200, 60), stringToDisplay);
				
			}
		}
}
}

