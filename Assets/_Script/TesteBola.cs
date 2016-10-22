using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TesteBola : MonoBehaviour
{
	public Text labelX;
	public Text labelZ;
	public Text labelVel;
	public Slider velControol;

	public float velocidade;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		Vector3 movement;
		velocidade = velControol.value;
		labelVel.text = "Vel: " + velocidade;

		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
		float moveX = Input.GetAxis ("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");
		#elif UNITY_IOS || UNITY_ANDROID
		float moveX = Input.acceleration.x;
		float moveZ = Input.acceleration.y;
		#endif

		labelX.text = " X: " + moveX;
		labelZ.text = " Z: " + moveZ;
		movement = new Vector3 (moveX, 0.0f, moveZ);

		rb.AddForce (movement * velocidade);
		//transform.Translate (movement);
	}
}
