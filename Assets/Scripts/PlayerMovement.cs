using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main; 
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement * movementSpeed * Time.fixedDeltaTime;

        Vector3 minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
        newPosition.x = Mathf.Clamp(newPosition.x, minScreenBounds.x, maxScreenBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minScreenBounds.y, maxScreenBounds.y);

        rb.MovePosition(newPosition);
    }
}
