using UnityEngine;
using System.Collections;

public class BlaizikenAttack : Attack {

	private bool attack = false;
	private LookAt lookAt;

	public ParticleSystem leftHand;
	public ParticleSystem rightHand;

	private Vector3 initialPosition;
	private bool direction;

	private CharacterController ctrl;

	void Start(){
		leftHand.Stop ();
		rightHand.Stop ();
		ctrl = gameObject.GetComponent<CharacterController> ();
	}
	void Update(){
		if (attack) {
			Transform target = lookAt.target;
			transform.RotateAround (transform.position, Vector3.up, 1080 * Time.deltaTime);
			if (Vector3.Distance (target.position, transform.position) < 0.25f) {
				direction = false;
			}
			if (direction)
				transform.position = Vector3.Lerp (transform.position, target.position, 2f * Time.deltaTime);
			else {
				transform.position = Vector3.Lerp (transform.position, initialPosition, 2f * Time.deltaTime);
				if (Vector3.Distance (transform.position, initialPosition) < 0.1f) {
					attack = false;
					lookAt.enabled = true;
					leftHand.Stop ();
					rightHand.Stop ();
					ctrl.AttackFinished ();
				}
			}
		}

	}

	public override void StartAttacking (bool attack)
	{
		this.attack = attack;
		lookAt = GetComponent<LookAt> ();
		lookAt.enabled = false;
		initialPosition = transform.position;
		direction = true;
		leftHand.Play ();
		rightHand.Play ();
	}
}
