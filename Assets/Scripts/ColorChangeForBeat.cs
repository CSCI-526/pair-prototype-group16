using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ColorChangeForBeat : MonoBehaviour
{
    private Image circleRenderer;
    private bool isCorrect = false; // Flag to toggle color for now
    public bool canSpawnCircle = false; 
    public bool canSpawnSquare = false;
    
    float timeElapsed = 0.0f;
    float timeLastSpawn = 0.5f;

    //float globalWait = 0.0f;
    private bool isCircleBlack = true;

    void Start()
    {
        GameObject circleObject = GameObject.FindWithTag("GameController");

        if (circleObject != null)
        {
            circleRenderer = circleObject.GetComponent<Image>();
        }
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        timeLastSpawn += Time.deltaTime;

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
        else if(timeElapsed >= 1.8f && timeElapsed <= 2.2f)
        {
            isCorrect = true;
            if (timeLastSpawn >= 0.5f)
            {
                canSpawnCircle = true;
                timeLastSpawn = 0.0f;
            }
            
        }
        else if (timeElapsed >= 2.8f && timeElapsed <= 3.2f)
        {
            isCorrect = true;
            if (timeLastSpawn >= 0.5f)
            {
                canSpawnSquare = true;
                timeLastSpawn = 0.0f;
            }
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
