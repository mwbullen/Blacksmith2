using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class tileDetail : MonoBehaviour {

	public string tileType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  ContentType.contentItem tileContentType { 
		get 
		{ 
			return (ContentType.contentItem) System.Enum.Parse (typeof(ContentType.contentItem), tileType); 
		}
	}
}
