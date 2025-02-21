using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome_Flash : MonoBehaviour
{
    float timeElapsed = 0.0f;
    float lerpDuration = 4.0f;

    Vector3 startPosition = new Vector3(104.0f, 380f, 0.00f);
    Vector3 endPosition = new Vector3(504.00f, 380f, 0.00f);

    //float lerpedValue;

    // Start is called before the first frame update
    void Start()
    {
        var metPos = GameObject.Find("Metronome");
        Vector3 tempPos = metPos.transform.position;
        //Debug.Log(tempPos);
        //Vector3 startPosition = transform.position;
        //Debug.Log(startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed <= lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            //Debug.Log("Time Elapsed: " + timeElapsed);
            if (timeElapsed >= lerpDuration)
            {
                //Debug.Log("Test");
                timeElapsed = 0.00f;
                transform.position = startPosition;
                //Debug.Log(transform.position);
            }
        }
    }
}
