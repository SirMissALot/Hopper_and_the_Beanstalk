using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

	[SerializeField]
	GameObject Menu;

	Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}
	
	// Loading Function
	public void Loadlevel(string levelName) {
		StartCoroutine(AsyncLoading(levelName));	
	}

	IEnumerator AsyncLoading(string levelName){

		// loadingScreen.SetActive(true);

		AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

		while(!operation.isDone){

			float progress = Mathf.Clamp01(operation.progress / 0.9f);

			// slider.value = progress;
			

			yield return null;
		}

	}

	// Camera animation
	public void StartGame(){
		Menu.SetActive(false);
		anim.SetTrigger("Play");
	}

}
