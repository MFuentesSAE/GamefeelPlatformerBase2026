using Platformer;
using UnityEngine;

public class Player2DAnimEventHolder : MonoBehaviour
{
	public PlayerController player;

	public void EndDash()
	{
		player?.EndDash();
	}

	public void UnblockAttack()
	{
		player.UnblockAttack();
	}

	public void EndAttackCollider()
	{
		player.EndAttackCollider();
	}
}
