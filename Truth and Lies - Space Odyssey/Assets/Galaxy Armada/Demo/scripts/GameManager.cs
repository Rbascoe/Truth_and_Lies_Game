using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private Camera cam;
	public GameObject[] enemies;
	private bool GameRun= false;
	public GameObject player;
	public static GameManager instance;
	private float screenFront;
	private float screenBack;
	private float screenTop;
	private float screenBottom;


	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		screenTop = cam.ScreenToWorldPoint(new Vector3(0f, cam.pixelHeight/2f  ,0f)).y -1f;
		screenBottom = cam.ScreenToWorldPoint(new Vector3(0f,-cam.pixelHeight/2f  ,0f)).y +1f;
		screenFront = cam.ScreenToWorldPoint(new Vector3(Screen.width,0f ,0f)).x;
		UI.instance.FirstRun ();
	}

	public void StartGame(){
		UI.instance.GameRun ();
		GameRun = true;
		StartCoroutine (SpawnEnemy ());
	}

	public void RestartGame(){
		SceneManager.LoadScene ("Game");
	}

	public void gameOver(){
		UI.instance.GameOver ();
		GameRun = false;
		StopCoroutine (SpawnEnemy ());
	}

	IEnumerator SpawnEnemy(){
		while (GameRun) {
			if (!player) {
				GameRun = false;
				Debug.Log ("game over!");
			}

			PoolManager.instance.Spawn (enemies [Random.Range (0, enemies.Length)].name, new Vector3 (screenFront,Random.Range(cam.orthographicSize,-cam.orthographicSize) , 0f), Quaternion.identity,true);
			yield return new WaitForSeconds (Random.Range (0.5f, 2f));
		}
		
	}
}
