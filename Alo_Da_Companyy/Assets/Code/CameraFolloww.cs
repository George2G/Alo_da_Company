using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolloww : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;
    public Animator anim;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatISGround;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTransform.position;//camera position = player position

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatISGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {

            transform.position = Vector2.Lerp(transform.position, playerTransform.position, speed);
            if (isGrounded != true)
            {
                anim.SetBool("isIntheAir",true);
            }
            else
            {
                anim.SetBool("isIntheAir", false);

            }
        }

    }
}
