using UnityEngine;
using System.Collections;

public class PlayerMoveTest:UUnitTestCase {
	testPlayer myTestPlayer = new testPlayer();
	
	[UUnitTest]		
	public void firstTest()
	{			
		bool returned = false;			
		UUnitAssert.False (myTestPlayer.returnYou ("s" ));			
		Debug.Log("My test passed..!! :D");			
	}		
	
	[UUnitTest]
	public void testSetVelocity()
	{
		float checkX = 15f;
		float checkY = 12f;
		Vector2 myVect = new Vector2 (checkX, checkY);
		UUnitAssert.Equals(myVect,myTestPlayer.setVelocity(5f,12f));
		Debug.Log ("SetVelocityTest Passed..!! Yuhoo..");
		
	}
	[UUnitTest]
	public void testSetVelocityFail()
	{
		float checkX = 10f;
		float checkY = 12f;
		Vector2 myVect = new Vector2 (checkX, checkY);
		//UUnitAssert.NotEquals(myVect, myTestPlayer.setVelocity(15f,12f));
		//UUnitAssert.Equals(myVect,myTestPlayer.setVelocity(15f,12f));
		Debug.Log ("SetVelocityTest failed");
	}
	
	[UUnitTest]
	public void testFlip()
	{
		//bool flipped = true;
		bool check = myTestPlayer.Flip (false);
		UUnitAssert.True (check);
		Debug.Log ("Flipped passed as well..!!");
	}

	[UUnitTest]
	public void testFlipFail()
	{
		//bool flipped = true;
		bool check = myTestPlayer.Flip (true);
		UUnitAssert.False (check);
		Debug.Log ("Flipped failed");
	}
	
	[UUnitTest]
	public void testCheckObsctacle()
	{
		Vector3 myStart = new Vector3 (4.3f, -2.1f, 0.0f);
		Vector3 myEnd = new Vector3 (7.8f, -2.2f, 0.0f);
		bool interact = myTestPlayer.checkObsctacle (myStart, myEnd);
		UUnitAssert.False (interact);
		Debug.Log ("Check obstacle passes.. :)");
	}
	
	[UUnitTest]
	public void testSetRigidBodyForce()
	{//setRigidBodyForce
		bool dJump = true;
		bool grounded = true;
		Vector2 expected = new Vector2 (0, 100);
		Vector2 got = myTestPlayer.setRigidBodyForce (dJump, grounded, 100f);
		UUnitAssert.Equals (expected, got);
		Debug.Log ("Set force to rigidBody2D passed.. ");
		
	}

	public void testSetRigidBodyForceFail()
	{//setRigidBodyForce
		bool dJump = true;
		bool grounded = true;
		Vector2 expected = new Vector2 (0, 100);
		Vector2 got = myTestPlayer.setRigidBodyForce (dJump, grounded, 150f);
		UUnitAssert.NotEquals (expected, got);
		//UUnitAssert.Equals (expected, got);
		Debug.Log ("Set force to rigidBody2D failed.. ");
	}
	
	[UUnitTest]
	public void testDestroyObstacle()
	{
		GameObject myGameObj = new GameObject();
		bool success = myTestPlayer.destroyObstacle (myGameObj);
		UUnitAssert.True (success);
		Debug.Log ("Destroyed obstacle checked..!!");
	}
	
	[UUnitTest]
	public void testCheckStringEqual()
	{
		GameObject myGameObj = new GameObject ();
		myGameObj.name = "Cat(Clone)";
		string userInput = "Cat";
		bool isEqual = myTestPlayer.checkStringEqual (userInput, myGameObj);
		UUnitAssert.True (isEqual);
		Debug.Log ("Trimmed and checkedStringEqual.."); 
	}

	[UUnitTest]
	public void testCheckStringEqualFail()
	{
		GameObject myGameObj = new GameObject ();
		myGameObj.name = "Cat(Clone)";
		string userInput = "Dinosaur";
		bool isEqual = myTestPlayer.checkStringEqual (userInput, myGameObj);
		Debug.Log ("retuend by chek string " + isEqual);
		UUnitAssert.False (isEqual);
		Debug.Log ("Failure of Trimmed and checkedStringEqual.."); 
	}
	/*
	[TestCase]
	public void objectCounterIncreased()
	{
		SpawnMultipleObject spawnTestObject = new SpawnMultipleObject();
		spawnTestObject.objectsSpawned = 0;
		int res = 0;//spawnTestObject.objectsSpawned;
		//spawnTestObject.spawnRandomObject ();
		Assert.AreEqual (res, 0);
		
		
	}
	*/
}
