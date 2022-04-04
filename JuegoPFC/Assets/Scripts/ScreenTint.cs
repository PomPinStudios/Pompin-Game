using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTint : MonoBehaviour
{
    public Color unTintenColor;
    public Color tintedColor;
    float f;
    
    Image image;
    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Tint()
    {
        f = 0f;
        StartCoroutine(TintScreen());
    }

    public void UnTint()
    {
        f = 0f;
        StartCoroutine(UnTintScreen());
    }

    private IEnumerator TintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(unTintenColor, tintedColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator UnTintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime;
            f = Mathf.Clamp(f, 0, 1f);

            Color c = image.color;
            c = Color.Lerp(tintedColor, unTintenColor, f);
            image.color = c;

            yield return new WaitForEndOfFrame();
        }
    }


}
