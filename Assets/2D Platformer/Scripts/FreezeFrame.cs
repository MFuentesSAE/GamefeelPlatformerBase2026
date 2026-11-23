using System.Collections;
using UnityEngine;

public class FreezeFrame : MonoBehaviour
{
    public static FreezeFrame instance;

    public KeyCode testKey;
    private Coroutine freezeRoutine;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(testKey))
        {
            Freeze();
        }
    }

    public void Freeze(float delay = 0.1f, float duration = 0.3f)
    {
        if(freezeRoutine != null)
        {
            StopCoroutine(freezeRoutine);
        }

        freezeRoutine = StartCoroutine(FreezeRotuine(delay, duration));
    }


    IEnumerator FreezeRotuine(float delay, float duration)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;

    }

}
