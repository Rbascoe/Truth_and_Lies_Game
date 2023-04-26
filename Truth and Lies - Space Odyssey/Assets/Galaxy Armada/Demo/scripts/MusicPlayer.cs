using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public static MusicPlayer instance;

	public AudioSource music;

	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance != this) 	Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		if(!music.isPlaying) music.Play ();
	}

}
