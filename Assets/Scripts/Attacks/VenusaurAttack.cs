using UnityEngine;
using System.Collections;

public class VenusaurAttack : Attack {
	private bool attack = false;
	private bool damage = false;
	public GameObject leaves;
	private GameObject instance;
	private Transform target;
	public GameObject beam;
	public GameObject venusaur;
	// Use this for initialization
	void Start () {
		target = GetComponent<LookAt> ().target;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			instance = Instantiate(beam, venusaur.transform.position + new Vector3(0f, 1f, 1f), venusaur.transform.rotation) as GameObject;
			Vector3 subs = venusaur.transform.position - target.transform.position;
			beam.GetComponent<BeamParam> ().MaxLength = Mathf.Abs (subs.x) + Mathf.Abs (subs.z);
			Destroy (instance, 3f);
		}

	}
	override
	public void StartAttacking(bool attack){
		this.attack = attack;
	}
}
