using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolloww : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTransform.position;//camera position = player position

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position, speed);
        }

    }
}
