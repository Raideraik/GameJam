using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance { get; private set; }
    public float _fadeDuration = 2f; // Длительность затухания

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        Instance = this;
        FadeOut();

    }

    public void FadeIn(string sceneNumber)
    {
        StartCoroutine(Fade(1f, _fadeDuration, 0));
        SceneManager.LoadSceneAsync(sceneNumber);
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0f, _fadeDuration, 1));
    }

    private IEnumerator Fade(float targetAlpha, float duration, float startAlpha)
    {
        float time = 0f;

        while (time < duration)
        {
            _canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        _canvasGroup.alpha = targetAlpha;
    }
}


