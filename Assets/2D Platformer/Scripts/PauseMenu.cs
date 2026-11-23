using UnityEngine;
using DG.Tweening;//importar tweens

public class PauseMenu : MonoBehaviour
{
    public KeyCode pauseKey;
    public CanvasGroup canvasGroup;
    private bool gamePaused;

    private float tweenTime = 0.3f;
    private Tween pasueTween;// guardar el tween de pausa en una variable

    void Start()
    {
        gamePaused = false;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause(!gamePaused);
        }
    }

    public void TogglePause(bool pauseGame)
    {
        float canvasAlpha = pauseGame ? 1 : 0;
        float targetTimescale = pauseGame ? 0 : 1;

        Time.timeScale = targetTimescale;

        /*if(pasueTween != null)
        {
            pasueTween.Kill();
        }*/

        pasueTween?.Kill();

        //Set upadate permite indicar si usar un timescale independiente (real time) o no
        pasueTween = canvasGroup.DOFade(canvasAlpha, tweenTime).SetUpdate(true);

        gamePaused = pauseGame;
    }
}
