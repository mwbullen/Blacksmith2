using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
/*	public GameObject iron_ingot;
	public GameObject copper_ingot;
	public GameObject steel_ingot;
	public GameObject oak_plank;
	public GameObject elm_plank;
	public GameObject ruby;
	public GameObject diamond;
	public GameObject sapphire;
	public GameObject redBerry;
	public GameObject smallHealthPotion;
*/
	public GameObject[] contentPrefabs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject getPrefabforContentType (ContentType.contentItem requestedContentItem) {
		foreach (GameObject contentPrefab in contentPrefabs) {
			if (contentPrefab.name == requestedContentItem.ToString ()) {
				return GameObject.Instantiate(contentPrefab);
			}
		}

		return null;
	}
}
