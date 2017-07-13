using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameStateManager : MonoBehaviour {

	public GameStateInfo currentGameStateInfo;
	public GameObject workBenchPrefab;

	public GameObject WorkBenchArea;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void loadWorkBenches() {
		foreach (ContentsManagerInfo workInfo in currentGameStateInfo.workBenches) {
			GameObject newWorkBench = GameObject.Instantiate (workBenchPrefab);

			newWorkBench.GetComponent<ContentsManager> ().loadContents (workInfo);

			//newWorkBench.loadWorkbenchInfo (workInfo);

			newWorkBench.transform.SetParent (WorkBenchArea.transform);
		}
	}

	void saveContentInfo() {
		//serialize gamestateinfo

		BinaryFormatter bf = new BinaryFormatter ();

		FileStream fs = File.Create (Application.persistentDataPath + "/" + "savegame.gam");

		bf.Serialize (fs, currentGameStateInfo);

		fs.Flush();
		fs.Close();

	}

	void loadSavedGame() {
		
		if (File.Exists (Application.persistentDataPath + "/" + "savegame.gam")) {
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream fs = File.Open (Application.persistentDataPath + "/" + "savegame.gam", FileMode.Open);

			currentGameStateInfo = (GameStateInfo)bf.Deserialize (fs);

			fs.Close ();
		}
					}
}
