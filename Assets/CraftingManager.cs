using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class CraftingManager : MonoBehaviour {

	public WeaponTemplate[] WeaponTemplates;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public WeaponTemplate getTemplateforType (WeaponInfo.weaponTypes newWeaponType) {
		foreach (WeaponTemplate w in WeaponTemplates) {
			if (w.weaponType == newWeaponType) {
				return w;
			}
		}

		return null;
	}
}
