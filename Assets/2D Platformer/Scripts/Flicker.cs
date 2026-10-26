using DG.Tweening;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Color targetColor;
    public float tweenTime;
    public int loops;
    public Ease ease;
    public LoopType loopType;

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
        renderer.gameObject.layer = inmuneLayer;
    }

    private void EndInmunity()
    {
        renderer.gameObject.layer = playerLayer;
    }
}
