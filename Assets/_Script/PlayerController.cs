using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	//velocidade do jogador
	public float velocidade;
	//componente de corpo rigido
	private Rigidbody rb;
	//Classe game controller
	public GameController gm;
	//gameobject da particula que será instaciada quando o jogador for destuido
	public GameObject particula;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();	//instanciando o objeto rb, com o componente presetne neste game object
	}

	void FixedUpdate ()
	{
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL		//verificador em tempo de contrução caso esteja no unity, no desktop ou na web
		float moveHorizontal = Input.GetAxis ("Horizontal");	//o valor do eixo horizontal será armazenado
		float moveVertical = Input.GetAxis ("Vertical");		//o valor do eixo vertical será armazenado

		#elif UNITY_IOS || UNITY_ANDROID						//caso seja compilado no android ou ios
		float moveHorizontal = Input.acceleration.x * 1.5f;		//o eixo recebe o valor do acelerometro
		float moveVertical = Input.acceleration.y * 1.5f;
		#endif

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);	//Vector3 que vai receber o direcionamento do jogador

		rb.AddForce (movement * velocidade);	//adiciona uma força no rigidbody do jogador, na nova posição especificada, multiplicando-a pela velocidade escolhida
	}

	void OnCollisionEnter (Collision coll)	//quando algum objeto entrar no collider deste objeto ou vice-versa
	{
		if (coll.gameObject.CompareTag ("Parede")) { 								//verifica se o objeto tem a tag Parede
			Instantiate (particula, this.transform.position, Quaternion.identity); 	//Instancia a particula
			gm.PerdeuJogo ();														//muda o estado do jogo para perdeu
			Destroy (this.gameObject);												//destroi o jogador
		}
	}
}
