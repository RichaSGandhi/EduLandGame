using UnityEngine;
using System.Collections;
using NUnit.Framework;


internal class PlayerMoveTest{

	[Test]
	public void obstacleDestroyed() 

	{
			if (PlayerMove.destroyedPrevious == true) {
			Assert.Pass();
			Debug.Log ("Previous Object Destroyed");
		}
		
	}
}