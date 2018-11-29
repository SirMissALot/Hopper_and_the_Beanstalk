using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayAds : MonoBehaviour {

	void Start() {
        // Advertisement.Initialize("2659783");
    }

	public void ShowAd() {
		
        #if UNITY_ANDRIOD
        Advertisement.Initialize("2818295");
        #endif
        #if UNITY_IOS
        Advertisement.Initialize("2818296");
        #endif
        Advertisement.Show();
		if(Advertisement.IsReady()) {
			Advertisement.Show();
			SceneManager.LoadScene("Menus", LoadSceneMode.Single);
		} else {
			Advertisement.Show();
			SceneManager.LoadScene("Menus", LoadSceneMode.Single);
		}
	}
}
