using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class HeroStatus : MonoBehaviour {

	public HeroInfo heroInfo;

	public GameObject nameTxt;
	public GameObject activityTxt;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void refreshDisplay() {
		nameTxt.GetComponent<TextMesh> ().text = heroInfo.heroName;	
		activityTxt.GetComponent<TextMesh> ().text = heroInfo.currentActivity.ToString ();
	}
}
