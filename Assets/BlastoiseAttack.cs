using UnityEngine;
using System.Collections;

public class BlastoiseAttack : Attack {


	public GameObject rightBeam;
	public GameObject leftBeam;
	public CharacterController ctrl;

	private float timer;
	private bool attack;

	// Use this for initialization
	void Start () {
		leftBeam.SetActive(false);
		rightBeam.SetActive(false);
	}

	void Awake () {
		leftBeam.SetActive(false);
		rightBeam.SetActive(false);
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
		leftBeam.SetActive(true);
		rightBeam.SetActive(true);
		timer = 2f;
	}

	private void Stop(){
		attack = false;
		leftBeam.SetActive(false);
		rightBeam.SetActive(false);
		ctrl.AttackFinished ();
	}
}
