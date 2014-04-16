using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace EdulandUnitTest{

internal class PlayerMoveTest{

	[Test]
	public void obstacleDestroyed() 

	{
			if (PlayerMove.destroyedPrevious == true) {
			//Assert.Pass();
			Debug.Log ("Previous Object Destroyed");
		}
		
	}
}
}