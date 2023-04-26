using UnityEngine;
using System.Collections;

public class shot : MonoBehaviour {

	private Transform trans;
	private Renderer rndr;
	public float speed;

	void Start(){
		trans = GetComponent<Transform> ();
		rndr = GetComponent<Renderer> ();
	}

	void OnEnable () {		
		InvokeRepeating ("removeShot", 2f,0.5f);
	}

	void OnDisable(){
		CancelInvoke ("removeShot");
	}

	// Update is called once per frame
	void Update () {
		trans.position = Vector3.Lerp (trans.position, trans.position + new Vector3 (3f, 0f, 0f), Time.deltaTime * speed);	
	}

	void removeShot(){
		if (!rndr.isVisible) {
			PoolManager.instance.Despawn (this.gameObject);		
		}
	}
}
