using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public Transform target;	
	public static LookAt instance;
	// Update is called once per frame
	void Awake(){
		if (!instance) {
			instance = this;
		} else {
			Destroy (this);
		}
	}

	void Update () {
		transform.LookAt (target);
	}

	public void SetTarget(Transform target){
		this.target = target;
	}
}
