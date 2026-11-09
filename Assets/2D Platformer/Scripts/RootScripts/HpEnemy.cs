using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class HpEnemy : HpBase
{
	public Animator animator;
	public SpriteRenderer sprite;
	public Collider2D collider;
	public Rigidbody2D rb;

	private Tween fadeTween;

	private float fadeDelay = 0.5f;
	private float fadeTime = 1;

	private float camAmplitude = 4;
    private float camFrequency = 2;
    private float shakeDuration = 0.7f;


    public override void RemoveHp(int amount)
	{
		base.RemoveHp(amount);
		if(currentHp <= 0)
		{
			VirtualCameraManager.instance.ShakeCamera(camAmplitude, camFrequency, shakeDuration);
			Freeze();
			fadeTween?.Kill();
			fadeTween = sprite.DOFade(0, fadeTime).SetDelay(fadeDelay).OnComplete(RemoveEnemy);

			onDeathEvent?.Invoke();
		}
	}

	private void Freeze()
	{
		sprite.color = Color.grey;
		rb.gravityScale = 0;
		rb.linearVelocity = Vector2.zero;
		collider.enabled = false;
		animator.speed = 0; //pausar el animador
	}

	private void RemoveEnemy()
	{
		gameObject.SetActive(false);
	}
}
