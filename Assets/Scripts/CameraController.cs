using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all Update methods
    void LateUpdate()
    {
        //Apply Camera position after any physics updates to player for frame
        transform.position = player.transform.position + offset;
    }
}
