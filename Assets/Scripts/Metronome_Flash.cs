using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome_Flash : MonoBehaviour
{
    float timeElapsed = 0.0f;
    float lerpDuration = 4.0f;

    Vector3 startPosition;
    Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = GetComponent<RectTransform>().anchoredPosition;

        endPosition = startPosition;
        endPosition.x += 1000.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed <= lerpDuration)
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPosition, endPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            //Debug.Log("Time Elapsed: " + timeElapsed);
            if (timeElapsed >= lerpDuration)
            {
                //Debug.Log("Test");
                timeElapsed = 0.00f;
                GetComponent<RectTransform>().anchoredPosition = startPosition;
                //Debug.Log(transform.position);
            }
        }
    }
}
