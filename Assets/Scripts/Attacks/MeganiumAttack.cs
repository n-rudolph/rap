using UnityEngine;
using System.Collections;

public class MeganiumAttack : Attack {

	private bool attack = false;
	private bool damage = false;
	public GameObject leaves;
	public GameObject meganium;
	private GameObject instance;
	private Transform target;
	private CharacterController ctrl;
	private LookAt lookAt;

	// Use this for initialization
	void Start () {
		lookAt = GetComponent<LookAt> (); 

		ctrl = gameObject.GetComponent<CharacterController> ();

	}

	// Update is called once per frame
	void Update () {
		if (attack && lookAt.target!=null) {
			attack = false;
			instance = Instantiate(leaves, lookAt.target.transform.position + lookAt.target.transform.up*5, Quaternion.identity) as GameObject;
			ctrl.AttackFinished ();
		}
	}
	override
	public void StartAttacking(bool attack){
		this.attack = attack;
	}
}
