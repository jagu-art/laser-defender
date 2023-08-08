using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Shooter shooter;
    float paddingLeft;
    float paddingRight;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    private void Awake() {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)); // bottom left corner of viewport
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1)); // top right corner of viewport
        paddingLeft = paddingRight = gameObject.GetComponentInChildren<Renderer>().bounds.extents.x;
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2(); // stop player from moving out of viewport
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null) // if we found shooter attached to gameobject
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
