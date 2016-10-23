using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	//GameObject para armazenar o jogador
	private GameObject player;

	//Vetor para calcular a distancia da bola para a camera
	private Vector3 distancia;

	void Start ()
	{
		if (player == null) {	//caso o objeto player esteja vazio
			player = GameObject.FindGameObjectWithTag ("Player");	//o unity ira procurar o gameobject com a Tag player, e ira associa-lo ao objeto player.
		}

		distancia = transform.position - player.transform.position;	//diferença do local onde a camera está e o jogador
	}

	void LateUpdate ()
	{
		if (player != null) {
			transform.position = player.transform.position + distancia;	//a camera ira receber a
		}
	}
}
