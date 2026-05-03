using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	Rigidbody2D rb2d;
	public float speed;
	public float JumpForce;
	public bool isJumping;
	Vector2 moveInput;
	float move;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		rb2d.AddForce(moveInput * speed);
		/* move = Input.GetAxis("Horizontal");
		 rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);
		 Debug.Log(move);
 */
		if (Input.GetButtonDown("Jump") && !isJumping)
		{
			rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
			Debug.Log("Jump!");
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			isJumping = false;
		}
	}
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			isJumping = true;
		}
	}
}
