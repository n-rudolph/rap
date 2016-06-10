using UnityEngine;
using System.Collections;

public class ChalizardAttack : Attack {

	public ParticleSystem fireBlast;

	private bool attack;
	private bool attacking;
	private float attackTimer;
	private float blastTimer;

	// Use this for initialization
	void Start () {
		fireBlast.Stop ();
		attack = false;
		attackTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (attackTimer > 0)
			attackTimer -= 1 * Time.deltaTime;
		if (attackTimer <= 0)
			fireBlast.Stop ();
	}

	public override void StartAttacking(bool attack){
		Attack ();
		attackTimer = 1f;
		this.attack = attack;
	}

	private void Attack (){
		fireBlast.Play ();
	}
}
