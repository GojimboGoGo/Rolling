using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{

	public float speed;
	public Text countText;
	public Text winText;
	
	public Rigidbody rb;
	private int count;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText();
		winText.text = "";
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
		if (!other.gameObject.CompareTag("Pick Up")) return;
		
		other.gameObject.SetActive(false);
		count++;
		setCountText();
	}

	private void setCountText()
	{
		countText.text = string.Format("Count: {0}", count);
		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	}
}