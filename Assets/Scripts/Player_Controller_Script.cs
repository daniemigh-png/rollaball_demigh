using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class player_conroller_script : MonoBehaviour
{
    private Rigidbody rb;

    private int count;

    private float movementX;
    private float movementY;
    public float speed = 0;
public TextMeshProUGUI countText; 
public GameObject winTextObject;
 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start( )
    
    {
        SetCountText();
        rb = GetComponent<Rigidbody>();
        count = 0;
        winTextObject.SetActive(false);

    }
    
    void OnTriggerEnter (Collider other)
    {
     if (other.gameObject.CompareTag("PickUp"))
    {
        SetCountText (); 
         other.gameObject.SetActive(false);
         count = count +1;

    }
     
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
        countText.text = " Count " + count.ToString(); 

        if (count >= 7) 
       {

        winTextObject.SetActive(true);

         Destroy(GameObject.FindGameObjectWithTag("Enemy")); 
       }

        
    }

    private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       // Destroy the current object
       Destroy(gameObject); 
       // Update the winText to display "You Lose!"
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
}
}
