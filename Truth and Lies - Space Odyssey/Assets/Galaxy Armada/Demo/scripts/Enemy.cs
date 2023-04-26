using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Transform enemy;
	private Renderer rndr;
	private int sheild;
	public float speed = 0.5f;
	private int randomShot;
	public string BlastFX;
	public string Shots;
	public string Pickup;
	public int PointValue;

	void Awake(){
		enemy = this.GetComponent<Transform> ();
		rndr = this.GetComponent<Renderer> ();
	}

	// run when enemy spawn (active)
	void OnEnable () {				
		sheild = Random.Range (3, 6);
		speed = Random.Range (0.8f, 1.1f);
		enemy.localScale = new Vector3 (-speed, speed, 1f);
		StartCoroutine (shoot ());
		InvokeRepeating ("RemoveShip", 2f,0.5f);
	}

	// run when enemy despawn (disable)
	void OnDisable(){
		StopCoroutine (shoot ());
		CancelInvoke ("RemoveShip");
	}
	
	// move the enemy ship
	void Update () {
		enemy.position = Vector3.Lerp (enemy.position, enemy.position + new Vector3 (-3f, 0f, 0f), Time.deltaTime * speed);
	}

	// handle collision with shots
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("shot")){
			PoolManager.instance.Despawn (other.gameObject);		
			sheild -=1;
			if(sheild<=0){	
				UI.instance.UpdatePoints (PointValue);	
				PoolManager.instance.Spawn(BlastFX,enemy.position,  Quaternion.Euler(0f,0f,-75f),true);
				SpawnPickup ();
				PoolManager.instance.Despawn (this.gameObject);		
			}
		}
	}

	// despawn the ship prefab when off the screen
	void RemoveShip(){
		if (!rndr.isVisible) {
			PoolManager.instance.Despawn (this.gameObject);		
		}
	}

	// choose is spawn pickup bonus when enemy ship explode
	void SpawnPickup(){
		int chance = Random.Range (0, 10);
		if (chance < 3) {
			PoolManager.instance.Spawn(Pickup,enemy.position , Quaternion.identity,true);
		}
	}

	// choose if shoot back at the player and wait between shots
	IEnumerator shoot(){
		randomShot = Random.Range (0, 10);
		if (randomShot == 5) {			
			PoolManager.instance.Spawn(Shots,enemy.position + new Vector3 (-0.55f, -0.2f, 0f), Quaternion.identity,true);
		}
		yield return new WaitForSeconds(Random.Range(0,1f));
		StartCoroutine (shoot ());
	}
}
