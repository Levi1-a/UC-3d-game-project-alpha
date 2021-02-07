using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //rigidbody reference "rb"
    public Rigidbody rb;

    public float speed = 20f;
    public float upForce = 2f;
    public bool canJump;
    public bool isGrounded;


    void OnCollisionStay()
    {
        // stays on when player is on ground
        isGrounded = true;
    }


    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;

        //Jump
        if (canJump)
        {
            canJump = false;
            rb.AddForce(0, upForce, 0, ForceMode.Impulse);
        }
        if (Input.GetKey("space") && isGrounded)
        {
            canJump = true;
            isGrounded = false;
        }

    }
}
