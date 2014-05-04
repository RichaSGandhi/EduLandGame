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

	public Vector2 setVelocity2(float move, float rB2DYVelocity)
	{
		//Debug.Log ("Yayy..!! Setting new velocity from separate class");
		Vector2 vect= new Vector2();
		float xValue = move * 6f;
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
			//Debug.Log ("Line start value" + lineStart);
			//Debug.Log ("Line end value" + lineEnd);
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
		//char[] endClone = {'(','C','l','o','n','e',')'};
		string trimmedString = gameObj.name.Remove((gameObj.name.Length - 7),7);
		//Debug.Log(trimmedString);
		//textBoxString = textBoxString.ToUpper();
		trimmedString = trimmedString.ToUpperInvariant();
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
	string highScoreText;
	public static int score;
	int highScore;
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
	public bool L5 = false;
	private bool skipped = false;
	bool doubleJump = false;
	public static bool destroyedPrevious= false;
	public static float timer;
	public GUIStyle cutSceneStyle;
	public bool cs01 = false;
	public bool cs12 = false;
	public bool isCutScene = false;


	void Start ()
	{
		highScore = PlayerPrefs.GetInt(Application.loadedLevelName + "HighScore");
		Anim = GetComponent<Animator> ();
		if(GameObject.Find ("Spawner")){
			GameObject spawner = GameObject.Find ("Spawner");
			SpawnMultipleObject anotherScript = spawner.GetComponent<SpawnMultipleObject> ();
			anotherScript.spawnRandomObject (-1);
		}
		scoreText = "Score : " + score.ToString();
		highScoreText = "High Score : " + highScore.ToString();
		sounds = GetComponents<AudioSource>();
		noise1 = sounds[0];
		noise2 = sounds[1];
	}
	
	void FixedUpdate ()
	{
				//myFixedUpdate ();
		if (isCutScene == true) {
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			Anim.SetBool ("Ground", grounded);
			
			if (grounded) {
				doubleJump = false;
			}
			
			
			Anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
			
			float move = Input.GetAxis ("Horizontal");
			
			Anim.SetFloat ("Speed", Mathf.Abs (move));
			
			/*if (move > 0 && transform.position.x < 10) {
				if (!grounded && L5) {
					rigidbody2D.velocity = tp.setVelocity2 (move, rigidbody2D.velocity.y);// new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
				} else {
					rigidbody2D.velocity = tp.setVelocity (move, rigidbody2D.velocity.y);
				}
			} else if (move < 0 && transform.position.x <= 8.5f) {	
				if (!grounded && L5) {
					rigidbody2D.velocity = tp.setVelocity2 (move, rigidbody2D.velocity.y);// new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
				} else {*/
			rigidbody2D.velocity = tp.setVelocity (move, rigidbody2D.velocity.y);
			//}
			//}
			
			if(transform.position.x > 10 && cs01 == true){
				Application.LoadLevel ("Level1");
			}
			else if(transform.position.x > 10 && cs12 == true){
				Application.LoadLevel ("Level2");
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
				else{
					grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
					Anim.SetBool ("Ground", grounded);
			
					if (grounded) {
						doubleJump = false;
					}
			
			
					Anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
			
					float move = Input.GetAxis ("Horizontal");
			
					Anim.SetFloat ("Speed", Mathf.Abs (move));
			
					if (move > 0 && transform.position.x < 4) {
						if (!grounded && L5) {
							rigidbody2D.velocity = tp.setVelocity2 (move, rigidbody2D.velocity.y);// new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
						} else {
							rigidbody2D.velocity = tp.setVelocity (move, rigidbody2D.velocity.y);
						}
					} else if (move < 0 && transform.position.x <= 8.5f) {	
						if (!grounded && L5) {
							rigidbody2D.velocity = tp.setVelocity2 (move, rigidbody2D.velocity.y);// new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
						} else {
							rigidbody2D.velocity = tp.setVelocity (move, rigidbody2D.velocity.y);
						}
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
			if (skipped == false)
				score = score + 20;
			else 
				score = score - 5; 
			scoreText = "Score : " + score.ToString();
			Debug.Log ("In start" + score);
			//highScoreText = "High Score : " + highScore.ToString();
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
		if (isCutScene == true) {
						if (cs01 == true) {
								GUI.contentColor = Color.black;
				
								GUI.Label (new Rect (500, 50, 700, 500), "Our story begins with a young girl named Kairi waking up to find that her entire town is empty aside from one oddity: a fairy floating in the middle of town.  \n\nKairi: \"Where has everyone gone? Who are you? WHAT are you? \n\n\"Fairy: \"You seek answers? Head to the plains of Language Arts in the East. Perhaps there are some for you there.\"", cutSceneStyle);
						} else if (cs12 == true) {
								GUI.contentColor = Color.black;
				
								GUI.Label (new Rect (500, 50, 700, 500), "Kairi:\"I haven't seen so many creatures on the plains in a while, something must be wrong.\"\n\nFairy:\"Correct! Something is indeed wrong. I will answer one of your questions from home: I am a Fairy! Please proceed further east to the Forest of Mathematics to receive more answers.\"\n\nKairi: \"Mythological creatures are appearing now? I better investigate these woods.\"", cutSceneStyle);
				
						}
				} else {
						
						GUI.Label (new Rect (1100, 25, 30, 30), scoreText, labelStyle);
				
						GUI.Label (new Rect (1250, 25, 30, 30), highScoreText, labelStyle);
						if (interact) {
								if (Application.loadedLevelName == "Level1"){
								GUI.contentColor = Color.black;
								}
								GUI.color = Color.white;
								stringToEdit = GUI.TextField (new Rect (900, 120, 350, 50), stringToEdit, 25);
								//char[] endClone = {'C','l','o','n','e','(',')'};
								if (whatIHit) {
										//Debug.Log(whatIHit.collider.gameObject.name.TrimEnd(endClone));
										//string objectName = ;
										isCollision = tp.checkStringEqual (stringToEdit, whatIHit.collider.gameObject);
										if (isCollision) {
												stringToDisplay = "Correct Answer! You got 20 Points. Hit 'Enter' and Go Ahead.";
												skipped = false;
										} else {
												stringToEdit = stringToEdit.ToUpperInvariant ();
												if (stringToEdit == "SKIP") {
														stringToDisplay = "Sorry! You lost 5 points. Hit 'Enter' and Go Ahead.";
														isCollision = true;	
														skipped = true;
												} else
														stringToDisplay = "Hey!! Guess me OR Enter 'SKIP' to move ahead";
										}
				
										GUI.Label (new Rect (910, 170, 370, 60), stringToDisplay);

								}
						}
				}
}
}

