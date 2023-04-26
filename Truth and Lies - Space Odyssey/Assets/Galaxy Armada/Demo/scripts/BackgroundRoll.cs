using UnityEngine;
using System.Collections;

public class BackgroundRoll : MonoBehaviour {

	public Material mat;

	
	// Update is called once per frame
	void LateUpdate () {
		mat.SetTextureOffset ("_MainTex",new Vector2 (-Mathf.Repeat (Time.time/10f, 1), 0f));
	
	}
}
