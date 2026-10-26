using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform, destination;
    public float tweenTime;
    public LoopType loopType;
    public Ease ease;
    private Tween platformTween;
    private const string PLAYER_TAG = "Player";
    
    void Start()
    {
        platformTween = platform.DOMove(destination.position, tweenTime)
            .SetLoops(-1, loopType) //-1 loop infinito
            .SetEase(ease);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            platformTween.Pause();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            platformTween.Play();
        }
    }


}
