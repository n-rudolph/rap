using UnityEngine;
using System.Collections;

public class FeragatorAttack : Attack {

	public ParticleSystem blizzard;
	public CharacterController ctrl;


	private bool attack;
	private float timer;

	// Use this for initialization
	void Start () {
		blizzard.Stop ();
		attack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (attack) {
			if (timer <= 0) {
				Stop ();
			} else {
				timer -= Time.deltaTime;
			}
		}
	}

	override public void StartAttacking (bool attack){
		this.attack = attack;
		blizzard.Play ();
		timer = 2f;

	}

	private void Stop(){
		blizzard.Stop ();
		attack = false;
		ctrl.AttackFinished ();
	}
}
