using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; //Librería DOTween
using UnityEngine.Events; //Librería de eventos de Unity

public class Fader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime;
    public float fadeDelay = 0.5f;


    public UnityEvent onCompleteFadeToBlack;

    void Start()
    {
        fadeImage.raycastTarget = false;// forzar a que la imagen no sea interactuable.

        //Inicar la imagen en negro
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        FadeFromBlack();
    }


    public void FadeFromBlack()
    {
        fadeImage.DOFade(0, fadeTime).SetDelay(fadeDelay);
    }

    public void FadeToBlack() 
    {
        fadeImage.DOFade(1, fadeTime).OnComplete(onCompleteFadeToBlack.Invoke);
    }



}
