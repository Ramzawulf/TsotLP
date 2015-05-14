using UnityEngine;
using System.Collections;

public class Princess : MonoBehaviour {

    public float horizontalIn { get { return Input.GetAxisRaw("Horizontal"); } }
    public bool jumpIn { get { return Input.GetKeyDown("Jump"); } }

    //Physics
    private Rigidbody2D rb2d;

    //Movement Variables
    public float hStrength = 10;
    public float hMaxSpeed = 10;


	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        TryMove();
        print(horizontalIn);
    }

	void Update () {
	
	}

    private void TryMove() {
        Vector2 movementDirection = Vector2.right;
        rb2d.AddForce(movementDirection * horizontalIn);
    }
}
