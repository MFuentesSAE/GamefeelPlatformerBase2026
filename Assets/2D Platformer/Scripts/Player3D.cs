using UnityEngine;

public class Player3D : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rigidbody;

    private Vector2 movementVector;
    private string horizontal = "Horizontal";


    void Start()
    {
        
    }


    void Update()
    {
        Move();
	}

	private void Move()
	{
        movementVector.x = (Input.GetAxis(horizontal));
        movementVector.y = rigidbody.linearVelocity.y;

		rigidbody.linearVelocity = movementVector.normalized * moveSpeed;


	}
}
