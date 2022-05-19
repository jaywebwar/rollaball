using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    Rigidbody _rb;
    float moveX;
    float moveY;
    int count;

    [SerializeField] float moveSpeed = 1;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    void OnMove(InputValue moveValue)
    {
        Debug.Log("InputValue is getting called");
        Vector2 movementVector = moveValue.Get<Vector2>();
        moveX = movementVector.x;
        moveY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);

        _rb.AddForce(movement * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        count++;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count;
        if(count >= 12)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
