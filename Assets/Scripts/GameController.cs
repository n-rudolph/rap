using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private List<CharacterController> characters= new List<CharacterController>();
	
	// Update is called once per frame
	void Update () {
		if (characters.Count == 2) {
			
		}
	}

	public void AddCharacter(CharacterController character){
		characters.Add (character);
		Debug.Log (character.name+" has enter the game");
	}
	public void RemoveCharacter(CharacterController character){
		if (characters.Count > 0) {
			characters.Remove (character);
			Debug.Log (character.name+" has left the game");
		}
	}
}
