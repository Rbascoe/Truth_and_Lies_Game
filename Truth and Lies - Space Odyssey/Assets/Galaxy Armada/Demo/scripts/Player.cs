using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private Transform Ship;
	private float delay;
	private int shield; 
	public int maxShield = 20;
	public GameObject Shot;
	public float rate;
	public Camera cam;
	public string BlastFX;
	public string ExplosionFX;
	public GameObject PlayerShip;
	public GameObject[] ships; 
	private int ShipIndex=0;
	public AudioSource pickupAFX;
	public AudioSource impactAFX;



	// Use this for initialization
	void Start () {
		cam = Camera.main;
		Ship = GetComponent<Transform> ();
		delay = Time.time + rate;
		shield = maxShield;
		UI.instance.setupShield (shield);

	}
	
	// Update is called once per frame
	void Update () {
		// move the ship
			move (new Vector3 (Input.GetAxis ("Horizontal") * 5f, Input.GetAxis ("Vertical") * 5f, 0f));		
			
		// change the player ship	
			if (Input.GetKeyDown (KeyCode.Q)) {
				ShipIndex +=1;
				if (ShipIndex == ships.Length) {
					ShipIndex = 0;
				}
				Destroy (PlayerShip);
				PlayerShip =Instantiate( ships [ShipIndex],Ship.position,Quaternion.identity) as GameObject;
				PlayerShip.transform.parent = this.transform;
			}
		// fire!
		if (Input.GetAxis ("Fire1")>0 && Time.time > delay) {
				PoolManager.instance.Spawn("Shots_1",Ship.position + new Vector3 (0.55f, -0.2f, 0f), Quaternion.identity,true);			
				delay = Time.time + rate;
			}

		//} 

	}

	// move the ship and make sure it stay on screen
	void move(Vector3 dir){
		if (Ship.position.y < cam.ScreenToWorldPoint(Vector3.zero).y +0.8f ) {
			Ship.position = new Vector3(Ship.position.x, cam.ScreenToWorldPoint(Vector3.zero).y +0.8f,0f);
		}
		if (Ship.position.y > -cam.ScreenToWorldPoint(Vector3.zero).y -0.8f ) {
			Ship.position = new Vector3(Ship.position.x, -cam.ScreenToWorldPoint(Vector3.zero).y -0.8f,0f);
		}
		if (Ship.position.x < cam.ScreenToWorldPoint(Vector3.zero).x ) {
			Ship.position = new Vector3(cam.ScreenToWorldPoint(Vector3.zero).x,Ship.position.y,0f);
		}

		if (Ship.position.x > -cam.ScreenToWorldPoint(Vector3.zero).x ) {
			Ship.position = new Vector3(-cam.ScreenToWorldPoint(Vector3.zero).x,Ship.position.y,0f);
		}
		Ship.position = Vector3.Lerp (Ship.position, Ship.position + dir, Time.deltaTime);					
	}

	// handle collisiosn 

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("enemy")){			
			shield-=2;
			UI.instance.UpdateShield (shield);
			PoolManager.instance.Spawn(BlastFX,other.transform.position,  Quaternion.Euler(0f,0f,-75f),true);
			PoolManager.instance.Despawn (other.gameObject);	
		}

		if(other.CompareTag("enemyShot")){
			impactAFX.Play ();
			shield-=1;
			UI.instance.UpdateShield (shield);
			PoolManager.instance.Despawn (other.gameObject);	
		}

		if(other.CompareTag("health")){
			pickupAFX.Play ();
			shield = Mathf.Min (maxShield, shield + 5);
			UI.instance.UpdateShield (shield);
			PoolManager.instance.Despawn (other.gameObject);	
		}

		if(other.CompareTag("astroid")){
			
			shield-=3;
			UI.instance.UpdateShield (shield);
			PoolManager.instance.Spawn(BlastFX,other.transform.position,  Quaternion.Euler(0f,0f,-75f),true);
			PoolManager.instance.Despawn (other.gameObject);	
		}

		if(other.CompareTag("mine")){

			shield-=10;
			UI.instance.UpdateShield (shield);
			PoolManager.instance.Spawn(ExplosionFX,other.transform.position,  Quaternion.identity,true);
			PoolManager.instance.Despawn (other.gameObject);	
		}

		// check if shield is zero then you dead.
		if (shield <= 0) {		
			PoolManager.instance.Spawn(BlastFX,other.transform.position,  Quaternion.Euler(0f,0f,75f),true);
			GameManager.instance.gameOver ();
			Destroy (this.gameObject);
		}
	}
}
