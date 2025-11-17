using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class player_conroller_script : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
public TextMeshProUGUI countText; 
private int count; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start( count = 0; )
    {
        rb = GetComponent<Rigidbody>();

    }
    
    void OnTriggerEnter (Collider other)
    {
     if (other.gameObject.CompareTag("PickUp"))
    {
         other.gameObject.SetActive(false);
    }
    count = count +1; 
    }
private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); 
        rb.AddForce (movement);
    } 
    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movement= movementValue.Get<Vector2>();
        movementX = movement.x;
        movementY = movement.y;
    }

    void SetCountText ()
    {
        countText.text = "Count" + count.ToString();
    }
}
