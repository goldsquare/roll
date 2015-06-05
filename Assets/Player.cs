using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		updateCount ();
	}

	void updateCount()
	{
		countText.text = "Count :" + count.ToString ();
		if (count == 5) {
			winText.text = "Game Over You Win";
			countText.text = "";

		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count = count+1;
			updateCount();
		}
	}

	void FixedUpdate () {
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);


	}
}
