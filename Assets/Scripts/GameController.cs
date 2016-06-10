using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private List<CharacterController> characters= new List<CharacterController>();
	
	// Update is called once per frame
	void Update () {
		if (characters.Count == 2) {
			CharacterController character1 = characters [0];
			CharacterController character2 = characters [1];
			if (Vector3.Distance (character1.transform.position, character2.transform.position) <= 2) {
				Debug.Log ("estan cerca");
				character1.Attack ();
				character2.Attack ();

				CharacterController.TypeEnum type1 =  character1.type;
				CharacterController.TypeEnum type2 =  character2.type;

				int takeDamage1 = CalculateDamage(type1, type2);
				int takeDamage2 = CalculateDamage(type2, type1);

				if (character1.TakeDamage (takeDamage1)) {
					character1.PlayDeadAnimation ();
				}

				if (character2.TakeDamage (takeDamage2)) {
					character2.PlayDeadAnimation ();
				}
			}
		}
	}

	public void AddCharacter(CharacterController character){
		if (characters.Count < 2) {
			characters.Add (character);
			if (characters.Count == 2) {
				characters [0].SetTarget (characters [1]);
				characters [1].SetTarget (characters [0]);
			}
			Debug.Log (character.name + " has enter the game");
		}
	}
	public void RemoveCharacter(CharacterController character){
		if (characters.Count > 0) {
			characters.Remove (character);
			Debug.Log (character.name+" has left the game");
		}
	}

	//return the damage that typeB does to typeA
	private int CalculateDamage(CharacterController.TypeEnum typeA, CharacterController.TypeEnum typeB){

		if (typeA.Equals (typeB))
			return 1;
		if (typeA.Equals (CharacterController.TypeEnum.FIRE)) {
			if (typeB.Equals (CharacterController.TypeEnum.WATER) || typeB.Equals (CharacterController.TypeEnum.MASTER))
				return 2;
			if (typeB.Equals (CharacterController.TypeEnum.GRASS))
				return 1;
		}
		if (typeA.Equals (CharacterController.TypeEnum.FIRE)) {
			if (typeB.Equals (CharacterController.TypeEnum.WATER) || typeB.Equals (CharacterController.TypeEnum.MASTER))
				return 2;
			if (typeB.Equals (CharacterController.TypeEnum.GRASS))
				return 1;
		}
		if (typeA.Equals (CharacterController.TypeEnum.WATER)) {
			if (typeB.Equals (CharacterController.TypeEnum.GRASS) || typeB.Equals (CharacterController.TypeEnum.MASTER))
				return 2;
			if (typeB.Equals (CharacterController.TypeEnum.FIRE))
				return 1;
		}
		if (typeA.Equals (CharacterController.TypeEnum.GRASS)) {
			if (typeB.Equals (CharacterController.TypeEnum.FIRE) || typeB.Equals (CharacterController.TypeEnum.MASTER))
				return 2;
			if (typeB.Equals (CharacterController.TypeEnum.WATER))
				return 1;
		}
		if (typeA.Equals (CharacterController.TypeEnum.MASTER)) {
			return 1;
		}
		return 0;

	}
}
