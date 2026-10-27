using Platformer;
using UnityEngine;

public class Coin : MonoBehaviour
{
	GameManager gameManager;

	private void Start()
	{
		gameManager = GameManager.instance;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController player = other.GetComponent<PlayerController>();

		if (player != null)
		{
			gameManager?.AddCoins(1);
			gameObject.SetActive(false);
		}
	}
}
