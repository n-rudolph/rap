using UnityEngine;
using System.Collections;

public class ThunderSpere : MonoBehaviour {

	public GameObject sphere;
	public GameObject startPosition;
	public GameObject endPosition;

	private float speed = 1f;
	// Use this for initialization
	void Start () {
		sphere.transform.position = startPosition.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		sphere.transform.position = Vector3.MoveTowards (sphere.transform.position, endPosition.transform.position, speed * Time.deltaTime);
		if (sphere.transform.position == endPosition.transform.position) {
			sphere.transform.position = startPosition.transform.position;
		}
	}
}
