using UnityEngine;
using System.Collections;

public class RandomFlameSpeed : MonoBehaviour {
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.speed = Random.Range (0.7f, 1.5f);
	}	

}
