using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ColorChangeForBeat : MonoBehaviour
{
    private SpriteRenderer circleRenderer;
    private bool isCorrect = false; // Flag to toggle color for now
    public bool canSpawnCircle = false; 
    public bool canSpawnSquare = false;
    float timeElapsed = 0.0f;
    //float globalWait = 0.0f;
    private bool isCircleBlack = true;

    void Start()
    {
        GameObject circleObject = GameObject.FindWithTag("GameController");

        if (circleObject != null)
        {
            circleRenderer = circleObject.GetComponent<SpriteRenderer>();
        }
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        //Debug.Log(timeElapsed);
    if (timeElapsed >= 4.00f)
        {
            timeElapsed = 0.0f;
        }
        float timeDecimal = timeElapsed - (float)Math.Truncate(timeElapsed);
        if (timeDecimal >= 0.2f && timeDecimal <= 0.9f)
        {
            if (!isCircleBlack)
            {
                // wait 0.1 seconds
                StartCoroutine(WaitingForColorChange());
                circleRenderer.color = Color.black;
                isCircleBlack = true;
            }
        }

    }

    IEnumerator WaitingForColorChange()
    {
        yield return new WaitForSeconds(0.1f);
    }

    public void ChangeColor()
    {
        // check how much time has passed
        //timeElapsed += Time.deltaTime;
        //Debug.Log(timeElapsed);

        if(timeElapsed >= 0.9f && timeElapsed <= 1.1f)
        {
            isCorrect = true;
        }
        else if(timeElapsed >= 1.9f && timeElapsed <= 2.1f)
        {
            isCorrect = true;
            canSpawnCircle = true;
        }
        else if (timeElapsed >= 2.9f && timeElapsed <= 3.1f)
        {
            isCorrect = true;
            canSpawnSquare = true;
        }

        if (circleRenderer != null)
        {
            isCircleBlack = false;
            if (isCorrect)
            {
                circleRenderer.color = Color.green;
            }

        }

        isCorrect = false;
    }
}
