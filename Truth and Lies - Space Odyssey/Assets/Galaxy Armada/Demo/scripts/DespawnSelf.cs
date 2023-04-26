using UnityEngine;
using System.Collections;

public class DespawnSelf : MonoBehaviour {

	public float Delay;

	//despawn the gameobject after some time
	void OnEnable () {
		Invoke ("DestroyThis", Delay);
	}
	

	void DestroyThis () {
		PoolManager.instance.Despawn (this.gameObject);		
	}
}
