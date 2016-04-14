using UnityEngine;
using System.Collections;

public class MM : MonoBehaviour {

	public void startGame(string changeTo)
	{
		Application.LoadLevel(changeTo);
	}

}
