using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 2.5f;
    public float jumpForce = 7f;
    public float gravity = -20f;

    private int lane = 0;
    private float verticalVelocity;

    private CharacterController controller;

    private Vector2 startInput;
    private Vector2 endInput;
    private bool isSwiping = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 move = Vector3.zero;

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -1;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity;

        float targetX = lane * laneDistance;
        float deltaX = targetX - transform.position.x;
        move.x = deltaX * 10f;

        controller.Move(move * Time.deltaTime);
    }

    void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startInput = touch.position;
                isSwiping = true;
            }

            if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                endInput = touch.position;
                ProcessSwipe();
                isSwiping = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            startInput = Input.mousePosition;
            isSwiping = true;
        }

        if (Input.GetMouseButtonUp(0) && isSwiping)
        {
            endInput = (Vector2)Input.mousePosition;
            ProcessSwipe();
            isSwiping = false;
        }
    }

    void ProcessSwipe()
    {
        Vector2 swipe = endInput - startInput;

        if (swipe.magnitude < 50) return;

        swipe.Normalize();

        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
        {
            if (swipe.x > 0)
                MoveRight();
            else
                MoveLeft();
        }
        else
        {
            if (swipe.y > 0)
                Jump();
        }
    }

    void MoveLeft()
    {
        lane = Mathf.Max(lane - 1, -1);
    }

    void MoveRight()
    {
        lane = Mathf.Min(lane + 1, 1);
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }
}