﻿using UnityEngine;
using System.Collections;

public class MeganiumAttack : Attack {

	private bool attack = false;
	private bool damage = false;
	public GameObject leaves;
	public GameObject meganium;
	private GameObject instance;
	private Transform target;
	// Use this for initialization
	void Start () {
		target = GetComponent<LookAt> ().target;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			attack = true;
			instance = Instantiate(leaves, target.transform.position + target.transform.up*5, Quaternion.identity) as GameObject;
		}
	}
	override
	public void StartAttacking(bool attack){
		this.attack = attack;
	}
}
