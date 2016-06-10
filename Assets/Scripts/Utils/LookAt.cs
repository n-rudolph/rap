using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public Transform target;	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
	}

	public void SetTarget(Transform target){
		this.target = target;
	}
}
