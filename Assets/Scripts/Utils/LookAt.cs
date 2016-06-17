using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public Transform target;	
	public static LookAt instance;

	void Update () {
		if (target!=null)
			transform.LookAt (target);
	}

	public void SetTarget(Transform target){
		this.target = target;
	}
}
