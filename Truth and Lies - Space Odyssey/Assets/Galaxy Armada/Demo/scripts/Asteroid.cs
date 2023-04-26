using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	private Transform astroid;
	private Renderer rndr;
	private int sheild;
	public float speed = 0.5f;
	public string BlastFX;
	public int PointValue;

	void Awake(){
		astroid = GetComponent<Transform> ();
		rndr = GetComponent<Renderer> ();
	}

	void OnEnable () {				
		sheild = Random.Range (3, 6);
		speed = Random.Range (0.5f, 1.5f);
		astroid.localScale = new Vector3 (-speed, speed, 1f);
		InvokeRepeating ("RemoveAstroid", 2f,0.5f);
	}

	void OnDisable(){
		CancelInvoke ("RemoveAstroid");
	}

	// Update is called once per frame
	void Update () {
		astroid.position = Vector3.Lerp (astroid.position, astroid.position + new Vector3 (-3f, 0f, 0f), Time.deltaTime * speed);
		astroid.Rotate (0f, 0f, Time.deltaTime * speed * 100f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("shot")){
			PoolManager.instance.Despawn (other.gameObject);		
			sheild -=1;
			if(sheild<=0){		
				UI.instance.UpdatePoints (PointValue);
				PoolManager.instance.Spawn(BlastFX,astroid.position,  Quaternion.Euler(0f,0f,-75f),true);
				PoolManager.instance.Despawn (this.gameObject);		
			}
		}
	}


	void RemoveAstroid(){
		if (!rndr.isVisible) {
			PoolManager.instance.Despawn (this.gameObject);		
		}
	}
}
