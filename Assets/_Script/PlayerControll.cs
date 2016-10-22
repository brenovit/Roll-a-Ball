using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
	public Text label;
	public float velocidade;

	//componente de corpo rigido
	private Rigidbody rb;
	public GameController gm;

	//gameobject da particula que será isntaciada quando o jogador for destuido
	public GameObject particula;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		label.text = "0000";	
	}

	void FixedUpdate ()
	{
		Vector3 movement;

		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		#elif UNITY_IOS || UNITY_ANDROID
		float moveHorizontal = Input.acceleration.x * 1.5f;
		float moveVertical = Input.acceleration.y * 1.5f;
		#endif

		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * velocidade);
	}

	void OnCollisionEnter (Collision coll)
	{
		if (coll.gameObject.CompareTag ("Parede")) {
			Instantiate (particula, this.transform.position, Quaternion.identity);
			gm.PerdeuJogo ();
			Destroy (this.gameObject);
		}
	}
}
