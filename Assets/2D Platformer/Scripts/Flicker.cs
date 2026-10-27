using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Flicker : MonoBehaviour
{
    public SpriteRenderer renderer;
    public GameObject playerGameObject;
    public Color targetColor;
    public float tweenTime;
    public int loops;
    public Ease ease;
    public LoopType loopType;

    public UnityEvent onStartFlickr, OnEndFlickr;

    private Tween flickerTween;

    private int playerLayer = 3;
    private int inmuneLayer = 8;

    void Start()
    {
        
    }

    public void Flickr()
    {
        /*if(flickerTween != null)
        {
            flickerTween.Kill();
        }*/

        flickerTween?.Kill(true);

        flickerTween = renderer.DOColor(targetColor, tweenTime)
            .SetLoops(loops, loopType)
            .OnComplete(EndInmunity)
            .OnStart(Inmunity);
    }

    private void Inmunity()
    {
		playerGameObject.layer = inmuneLayer;
        onStartFlickr.Invoke();

	}

    private void EndInmunity()
    {
		playerGameObject.layer = playerLayer;
        OnEndFlickr.Invoke();
    }
}
