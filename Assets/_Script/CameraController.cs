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
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}
		distancia = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = player.transform.position + distancia;
	}
}
