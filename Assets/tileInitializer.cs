using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileInitializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gameControl = GameObject.Find ("GameControl");

		GameObject newTileDragFSMChild = GameObject.Instantiate( gameControl.GetComponent<prefabManager> ().tileDragControlPrefab);

		newTileDragFSMChild.transform.SetParent (gameObject.transform);
		newTileDragFSMChild.transform.localPosition = new Vector3 (0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
