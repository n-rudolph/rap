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
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			attack = true;
			sphere = Instantiate(thunderBall, startPosition.transform.position, Quaternion.identity) as GameObject;
		}
		if (attack && sphere != null) {
			sphere.transform.position = Vector3.MoveTowards (sphere.transform.position, LookAt.instance.target.transform.position, speed * Time.deltaTime);
			if (sphere.transform.position == LookAt.instance.target.transform.position) {
				attack = false;
//				damage = true;
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
		Debug.Log (rnd);
		return rnd;
	}
	override
	public void StartAttacking(bool attack){
		this.attack = attack;
	}
}
