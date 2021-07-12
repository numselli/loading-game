using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test5 : MonoBehaviour {

    public Color color1;
    public Color color2;
    public Color color3;
    public float duration = 3f;
    Color lerpedColor = Color.white;

    private float t = 0;
    private bool flag;

    Renderer _renderer;
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(color1, color2, t);
        _renderer.material.color = lerpedColor;

        if (flag == true)
        {
            t -= Time.deltaTime / duration;
            if (t < 0.01f)
                flag = false;
        }
        else
        {
            t += Time.deltaTime / duration;
            if (t > 0.99f)
                flag = true;
        }
    }
}