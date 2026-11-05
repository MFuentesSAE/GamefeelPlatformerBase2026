using UnityEngine;

public class Player3D : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rigidbody;
    public Animator animator;

    public KeyCode dodgeKey;
    public float dodgeSpeed;

    private bool blockMovement;

    private Vector2 movementVector;
    private string horizontal = "Horizontal";
    private string animMove = "MoveSpeed";
    private string animDodge = "Dodge";
    private float animEaseTime = 0.15f;


    void Start()
    {

    }


    void Update()
    {
        movementVector.x = (Input.GetAxis(horizontal));
        movementVector.y = rigidbody.linearVelocity.y;

        if (!blockMovement)
        {
            Move();
        }

        if (Input.GetKeyDown(dodgeKey))
        {
            Dodge();
        }
	}

	private void Move()
	{
		rigidbody.linearVelocity = movementVector.normalized * moveSpeed;
        animator.SetFloat(animMove, movementVector.x, animEaseTime, Time.deltaTime);
    }

    private void Dodge()
    {
        blockMovement = true;
        float dogeDir = movementVector.x;

        if (dogeDir == 0)
        {
            dogeDir = 1;
        }

        rigidbody.linearVelocity = Vector3.zero;

        Vector3 dodgeVector = new Vector3(dogeDir*dodgeSpeed, 0, 0);

        rigidbody.AddForce(dodgeVector, ForceMode.Impulse);

        animator.SetTrigger(animDodge);
    }

    public void EndDodge()
    {
        blockMovement = false;
    }
}
