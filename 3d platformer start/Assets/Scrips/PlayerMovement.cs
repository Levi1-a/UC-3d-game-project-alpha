using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float upForce = 2f;
    public bool canJump;
    public bool isGrounded;
    public Animator anime;

    private void Start()
    {
        anime = GetComponent<Animator>();
    }


    void OnCollisionStay()
    {
        // stays on when player is on ground
        isGrounded = true;
    }


    void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


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

        if (isGrounded == false)
        {
            anime.SetBool("isJumping", true);
        }
        else
        {
            anime.SetBool("isJumping", false);
        }
    }


}
