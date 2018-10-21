using UnityEngine;

public class Player_Controller : MonoBehaviour
{

	public float speed;
	public Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		var horizontalMove = Input.GetAxis("Horizontal");
		var verticalMove = Input.GetAxis("Vertical");
		var movement = new Vector3(horizontalMove, 0.0f, verticalMove);
		
		rb.AddForce(movement * speed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
//			Destroy(other.gameObject);			
		}
	}
}