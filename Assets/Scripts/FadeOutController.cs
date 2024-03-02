using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FadeOutController : MonoBehaviour
{
    public bool FadeOnStart = true;
    public float fadeDuration;
    public Color fadeColor;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (FadeOnStart) { FadeIn(); }
        else FadeOut();
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }  
    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphain, float alphaout)
    {
        StartCoroutine(FadeRoutine(alphain, alphaout));
    }
    public IEnumerator FadeRoutine(float alphain, float alphaout)
    {
		float timer = 0;
		while (timer <= fadeDuration)
		{
            Color newColor = fadeColor;
            newColor.a =  Mathf.Lerp(alphain, alphaout, timer/fadeDuration);

            rend.material.SetColor("_Color", newColor);
			timer += Time.deltaTime;
			yield return null;
		}
		Color newColor2 = fadeColor;
        newColor2.a = alphaout;

		rend.material.SetColor("_Color", newColor2);
		transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
	}

}
