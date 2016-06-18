using UnityEngine;
using System.Collections;

public class PikachuAttack : Attack {

	private bool attack = false;
	private bool damage = false;
	public GameObject startPosition;
	public GameObject thunderBall;
	private GameObject sphere = null;
	private float speed = 2f;
	public GameObject lightning;
	private GameObject[] beams = new GameObject[2];
	private bool damaging = false;

	private CharacterController ctrl;
	private LookAt lookAt;
	// Use this for initialization
	void Start () {
		lookAt = GetComponent<LookAt> ();
		ctrl = gameObject.GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (attack && sphere != null ) {
			Debug.Log ("1");
			sphere.transform.position = Vector3.MoveTowards (sphere.transform.position, lookAt.target.transform.position, speed * Time.deltaTime);
			if (Vector3.Distance(sphere.transform.position, lookAt.target.transform.position)<=0.1 ) {
				Debug.Log ("2");
				attack = false;
//				damage = true;
				ctrl.AttackFinished();
				Destroy (sphere);
			}
		}


//		if (damage) {
//			for (int i = 0; i < 2; i++) {
//				GameObject newBeam = Instantiate (lightning, LookAt.instance.target.transform.position, Quaternion.identity) as GameObject;
//				GameObject start = newBeam.transform.GetChild (0).gameObject;
//				GameObject end = newBeam.transform.GetChild (1).gameObject;
//				start.transform.position = LookAt.instance.target.transform.position;
//				end.transform.position = GetRandomEndPosition (start.transform.position);
//				beams [i] = newBeam;
//			}
//			damage = false;
//			damaging = true;
//		}
//		if (damaging) {
//			foreach (GameObject beam in beams){
//				
//				GameObject start = beam.transform.GetChild(0).gameObject;
//				GameObject end = beam.transform.GetChild(1).gameObject;
//				start.transform.position = Vector3.MoveTowards (start.transform.position, end.transform.position, speed * 5 * Time.deltaTime);
//				if (start.transform.position == end.transform.position) {
//					damaging = false;
//				}
//			}
//		}
	}

	private Vector3 GetRandomEndPosition(Vector3 start){
		Vector3 rnd = new Vector3 (start.x + (Random.Range(5f, 10f)* -1), start.y + (Random.Range(5f, 10f)* -1), start.z + (Random.Range(5f, 10f)* -1));
		return rnd;
	}
	override
	public void StartAttacking(bool attack){
		this.attack = true;
		sphere = Instantiate(thunderBall, startPosition.transform.position, Quaternion.identity) as GameObject;
	}
}
