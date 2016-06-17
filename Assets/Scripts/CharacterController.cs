using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public Attack characterAttack;

	public string name;

	public TypeEnum type;

	public int life;

	private LookAt lookAt;

	void Start(){
		lookAt = GetComponent<LookAt> ();
	}
	public void Attack(){
		characterAttack.StartAttacking (true);
	}

	public void PlayDeadAnimation(){
		Animator anim = gameObject.GetComponent<Animator> ();
		anim.applyRootMotion = false;
		anim.SetBool ("dead", true);
	}

	public bool TakeDamage(int damage){
		life -=damage;
		return life <= 0;
	}

	public bool IsAlive(){
		return life > 0;
	}

	public void SetTarget(CharacterController target){
		lookAt.SetTarget(target.transform);
	}

	public enum TypeEnum{
		FIRE, WATER, GRASS, MASTER
	}

	public void AttackFinished(){
		if (!IsAlive ()) {
			PlayDeadAnimation ();
		}
	}
}
