using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace EdulandUnitTest{

[TestFixture]
public class PlayerMoveTest{
		PlayerMove player;

	[SetUp]
	public void Init()
	{
			player = new PlayerMove ();
	}

	[Test]
	public void obstacleDestroyed() 

	{
			if (PlayerMove.destroyedPrevious == true) {
			//Assert.Pass();
			Debug.Log ("Previous Object Destroyed");
		}
		
	}
	[Test]
	public void counter(){
						player.interact = true;
				}


}
}