using UnityEngine;
using UnityEngine.InputSystem;

public class player_conroller_script : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); 
        rb.AddForce(movement);
    } 
    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movement= movementValue.Get<Vector2>();
        movementX = movement.x;
        movementY = movement.y;
    }
}
