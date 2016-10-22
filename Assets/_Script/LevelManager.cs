using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void LoadLevel (string nome) {
		SceneManager.LoadScene (nome);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
