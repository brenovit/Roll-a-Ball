using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public void LoadLevel (string nome)	//rotina para carregar uma cena pelo nome
	{
		SceneManager.LoadScene (nome);	//comando para carregar uma cena
	}

	public void QuitGame ()	//fechar o jogo
	{
		Application.Quit ();	//comando para finalizar o jogo
	}
}