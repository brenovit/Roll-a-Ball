using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
	public Text label;
	public float speed;

	private Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 movement;
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		#elif UNITY_IOS || UNITY_ANDROID
		float moveX = Input.acceleration.x;
		float moveY = Input.acceleration.y;
		movement = new Vector3 (moveX, 0.0f, moveY);
		#endif

		rb.AddForce (movement * speed);

		label.text = "0000";
	}

	void OnCollisionStay (Collision coll)
	{
		if (coll.gameObject.tag.Equals ("Wall")) {
			label.text = "Te adoro minha flor. :)";
		}
	}
}
