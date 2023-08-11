using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed; // control of x and y components of our texture

    Vector2 offset = new Vector2(0, 0); // offset of the amount of movement on each frame
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;    // make offset frame rate independent
        material.mainTextureOffset += offset;
    }
}
