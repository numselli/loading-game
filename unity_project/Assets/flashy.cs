using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashy : MonoBehaviour {
    [SerializeField]
    Gradient gradient;
    [SerializeField]
    public float duration;
    public float t = 0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float value = Mathf.Lerp(0f, 1f, t);
        t += Time.deltaTime / duration;
        Color color = gradient.Evaluate(value);
        Camera.main.backgroundColor = color;
        var colorkeys = new GradientColorKey[2];
        var alphakeys = new GradientAlphaKey[2];

        colorkeys[0].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        colorkeys[0].time = 0f;
        colorkeys[1].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        colorkeys[1].time = 1f;

        alphakeys[0].alpha = 1f;
        alphakeys[0].time = 0f;
        alphakeys[1].alpha = 1f;
        alphakeys[1].time = 1f;

        gradient.SetKeys(colorkeys, alphakeys);
    }
}
