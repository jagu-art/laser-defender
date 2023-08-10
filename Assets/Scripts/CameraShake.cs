using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;  // how long it will move
    [SerializeField] float shakeMagnitude = 0.5f; // how far it will move

    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsedTime = 0;

        while(elapsedTime < shakeDuration)
        {
            // unit circle is circle with radius of 1
            transform.position = initialPosition + (Vector3) UnityEngine.Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
