using UnityEngine;
using System.Collections;

public class ChalizardAttack : MonoBehaviour, Attack {

	public ParticleSystem fireBlast;
	public Transform instantiatePoint;
	public GameObject prefab;


	private bool attack;
	private bool attacking;
	private float attackTimer;
	private float blastTimer;

	// Use this for initialization
	void Start () {
		fireBlast.Pause ();
		attack = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (attack && attackTimer <= 0) {
			Attack ();
			attack = false;
			attackTimer = 5f;
		}
		if (attackTimer < 0)
			attackTimer -= Time.deltaTime;
		if (blastTimer <= 0)
			fireBlast.Stop ();
	}

	public void StartAttacking(bool attack){
		this.attack = attack;
	}

	private void Attack (){
		fireBlast.Play ();
		//Transform go = Instantiate (prefab, instantiatePoint.position, instantiatePoint.rotation);
		//Rigidbody rb = go.gameObject.GetComponent<Rigidbody> ();
		//rb.AddForce (Vector3.forward * 5f);
	}
}
