using UnityEngine;
using System.Collections;
using System.Text;

public class Princess : MonoBehaviour
{
	public static Princess ctrl;
	//Movement
	public float moveForce = 365f;
	public float maxHSpeed = 5f;
	public float maxVSpeed = 5f;
	private float hSpeedLock = -5;
	private float speedLockLapse = 0.5f;
	public bool facingRight = true;
	//Jumping
	public bool grounded = false;
	private bool wallGrounded = false;
	private bool jump = false;
	private bool wallJump = false;
	public float jumpForce = 1000f;
	public float wallJumpForce = 50f;
	private float wallJumpSpeed = 0.5f;
	private float lastWallJump = 0f;
	public Transform groundCheckStart;
	public Transform groundCheckEnd;
	public Transform wallCheck;
	//Physics
	private Rigidbody2D rb2d;
	//Animation
	//private Animator anim;
	//Inputs
	bool inputJump = false;
	float inputHorizontal = 0;

	void Awake ()
	{
		if (ctrl == null) {
			ctrl = this;
		} else if (ctrl != this) {
			Destroy (gameObject);
		}

		//anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		UpdateChecks ();
		CheckForInputs ();

		if (inputJump && grounded) {
			jump = true;
		} else if (inputJump && wallGrounded) {
			wallJump = true;
		}
	}

	void FixedUpdate ()
	{
		LimitSpeed ();
		Move ();
		Jump ();
		WallJump ();

	}

	private void Move ()
	{
		if (hSpeedLock > Time.time)
			return;
		//anim.SetFloat ("Speed", Mathf.Abs (inputHorizontal));

		if (inputHorizontal * rb2d.velocity.x < maxHSpeed) {
			if (grounded)
				rb2d.AddForce (Vector2.right * inputHorizontal * moveForce * 10);
			else
				rb2d.AddForce (Vector2.right * inputHorizontal * moveForce);
		}
		
		if (inputHorizontal > 0 && !facingRight) 
			Flip ();
		else if (inputHorizontal < 0 && facingRight)
			Flip ();
	}

	private void LimitSpeed ()
	{
		if (Mathf.Abs (rb2d.velocity.y) > maxVSpeed) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, Mathf.Sign (rb2d.velocity.y) * maxVSpeed);
		}

		if (Mathf.Abs (rb2d.velocity.x) > maxHSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxHSpeed, rb2d.velocity.y);
		}
		if (inputHorizontal == 0 && grounded)
			rb2d.velocity = new Vector2 (rb2d.velocity.x * 0.1f, rb2d.velocity.y);
	}

	private void Jump ()
	{
		if (jump) {

			//anim.SetTrigger ("Jump");

			rb2d.AddForce (new Vector2 (0, jumpForce));

			jump = false;
		}
	}

	private void WallJump ()
	{
		if (wallJump && Time.time >= lastWallJump + wallJumpSpeed) {
			rb2d.velocity = Vector2.zero;
			//anim.SetTrigger ("Jump");
			if (facingRight)
				rb2d.AddForce (new Vector2 (-wallJumpForce, jumpForce));
			else
				rb2d.AddForce (new Vector2 (wallJumpForce, jumpForce));

			wallJump = false;
			lastWallJump = Time.time;
			hSpeedLock = Time.time + speedLockLapse;
			Flip ();
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void UpdateChecks ()
	{
		grounded = Physics2D.Linecast (groundCheckStart.position, groundCheckEnd.position, 1 << LayerMask.NameToLayer ("Ground"));
		wallGrounded = Physics2D.Linecast (transform.position, wallCheck.position, 1 << LayerMask.NameToLayer ("Wall")) || Physics2D.Linecast (transform.position, wallCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
	}

	private void CheckForInputs ()
	{
		inputJump = Input.GetButtonDown ("Jump");
		inputHorizontal = Input.GetAxis ("Horizontal");
	}

	public string GetDebugMessage ()
	{
		var sb = new StringBuilder ();
		sb.AppendLine ("Princess");
		sb.AppendLine (string.Format ("Speed: h:{0:0.0} v: {1:0.0}", rb2d.velocity.x, rb2d.velocity.y));
		sb.AppendLine (string.Format ("Jumping: {0}", jump));
		sb.AppendLine (string.Format ("WJumping: {0}", wallJump));

		return sb.ToString ();
	}

	public void Damage ()
	{
		print ("Bam");
	}

}
