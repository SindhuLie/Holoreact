﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraduallyChangeColor : MonoBehaviour
{
    [SerializeField]
    private Color targetColor, startColor;
    [SerializeField]
    private float duration;


    private Renderer _renderer;
    private float tick;

    // Start is called before the first frame update
    private void Awake()
    {
        try
        {
            _renderer = gameObject.GetComponent<Renderer>();
            tick = 0f;
            StartChangeColor();
        }
        catch (System.Exception ex)
        {
            Debug.Log("There's no Renderer in the object please place renderer in the object!!!");
            Debug.Log(ex.Message);
        }
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void StartChangeColor()
    {
        if (duration == 0)
        {
            _renderer.material.color = targetColor;
        }
        else
        {
            StartCoroutine(ChangeColor());
        }
    }

    private IEnumerator ChangeColor()
    {
        while (startColor != targetColor)
        {
            tick += Time.deltaTime / duration;
            _renderer.material.color = Color.Lerp(startColor, targetColor, tick);
            yield return null;
        }
    }

}
