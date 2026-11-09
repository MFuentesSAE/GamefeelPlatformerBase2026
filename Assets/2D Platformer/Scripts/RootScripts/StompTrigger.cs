using UnityEngine;
using UnityEngine.Events;

public class StompTrigger : MonoBehaviour
{
	public Rigidbody2D playerRigidbody;
	public UnityEvent onStompEvent;

	private void OnTriggerEnter2D(Collider2D other)
	{
		HpEnemy hp = other.GetComponent<HpEnemy>();

		if(hp != null)
		{
			hp.RemoveHp(hp.maxHp);
			onStompEvent?.Invoke();
        }
	}
}
