using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome_Flash : MonoBehaviour
{
    float timeElapsed = 0;
    float lerpDuration = 4;

    Vector3 startPosition = new Vector3(-8.00f, 3.00f, 0.00f);
    Vector3 endPosition = new Vector3(0.00f, 3.00f, 0.00f);

    //float lerpedValue;

    // Start is called before the first frame update
    void Start()
    {
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
            //Debug.Log(timeElapsed);
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
