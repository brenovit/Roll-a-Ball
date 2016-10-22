using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	//variavel para armazenar os pontos
	private int pontos;

	//GameObject do tipo Text para exibir os pontos
	public Text labelPontos;

	//GameObject do tipo Text para exibir a quantidade de blocos
	public Text labelBlocos;

	//variavel auxiliar para armazenar a quantidade de blocos
	private int qtdBlocos;

	//GameObject que compõe o painel de fim de jogo
	public GameObject panel;

	//GameObject do tipo Text para exibir os pontos quando o jogo terminar
	public Text labelPontosPanel;

	//variavel estatica para definir se o jogo acabou ou não
	public static bool jogoAcabou = false;


	void Start ()			//Assim que essa classe for instanciada no jogo
	{
		jogoAcabou = false;
		qtdBlocos = GameObject.FindGameObjectsWithTag ("Bloco").Length;		//procurar todos os game objects com a tag Bloco, quantificar e armazenar esse valor
		labelBlocos.text = qtdBlocos.ToString ();							//alterar o texto da label de blocos
		pontos = 0;		//inicia os pontos em 0
		Time.timeScale = 1;	//defini a velocidade do jogo para 1;
	}

	public void DestroiBloco ()
	{
		qtdBlocos--;
		labelBlocos.text = qtdBlocos.ToString ();
		if (qtdBlocos == 0) {
			PerdeuJogo ();
		}
	}

	public void AlteraPontos (int valor)
	{
		pontos += valor;
		labelPontos.text = pontos.ToString ("0000");
	}

	public void Restart ()
	{
		panel.SetActive (false);
		SceneManager.LoadScene (1);
	}

	public void PerdeuJogo ()
	{
		if (!jogoAcabou) {
			Time.timeScale = 0.1f;
			labelPontosPanel.text = "Points: " + pontos.ToString ("0000");
			panel.SetActive (true);
			jogoAcabou = true;
		}
	}

}
