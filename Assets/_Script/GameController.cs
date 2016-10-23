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


	void Start ()															//Assim que essa classe for instanciada no jogo
	{
		jogoAcabou = false;
		qtdBlocos = GameObject.FindGameObjectsWithTag ("Bloco").Length;		//procurar todos os game objects com a tag Bloco, quantificar e armazenar esse valor
		labelBlocos.text = qtdBlocos.ToString ();							//alterar o texto da label de blocos
		pontos = 0;															//inicia os pontos em 0
		Time.timeScale = 1;													//defini a velocidade do jogo para 1;
	}

	public void DestroiBloco ()		//rotina responsavel por reduzir a quantidade de blocos contidos na fase para finalizar o jogo
	{
		qtdBlocos--;								//retira um bloco da memoria
		labelBlocos.text = qtdBlocos.ToString ();	//altera a label que mostra a quantidade de blocos.
		if (qtdBlocos == 0) {						//verifica se os blocos acabaram
			PerdeuJogo ();							//finaliza o jogo
		}
	}

	public void AlteraPontos (int valor)				//altera os pontos do jogo de acordo com o valor passado no parâmetro
	{
		pontos += valor;								//acrescenta nos pontos atuais o valor do parâmetro
		labelPontos.text = pontos.ToString ("0000");	//altera a label de pontos
	}

	public void Restart (string cena)		//rotina para reinicar o jogo
	{
		panel.SetActive (false);			//desativa o painel
		SceneManager.LoadScene (cena);		//carrega a cena com 
	}

	public void PerdeuJogo ()				//rotina que finaliza o jogo
	{
		if (!jogoAcabou) {					//verifica se o jogo realmente acabou
			Time.timeScale = 0.1f;			//reduz a velocidade do jogo
			labelPontosPanel.text = "Points: " + pontos.ToString ("0000");
			panel.SetActive (true);			//ativa o painel de game over
			jogoAcabou = true;				//marca que o jogo acabou
		}
	}
}
