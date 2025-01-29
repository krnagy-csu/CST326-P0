using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //my own rigidbody
    private Vector2 movementVector;

    public float speed = 1.0f;
    public float speedModifier = 1;
    public float jumpPower = 10;
    public int maxJumps = 2;
    private int jumps = 0;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winText;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        SetScoreText();
    }

    private void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
    }

    private void OnJump(InputValue button)
    {
        if (button.isPressed & jumps < maxJumps)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpPower, rb.linearVelocity.z); ;
            jumps++;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movementValue = movementVector * (speed * speedModifier + speed*speedModifier*(rb.linearVelocity.magnitude * 0.1f));
        rb.AddForce(new Vector3(movementValue.x,0,movementValue.y));

        if (gameObject.transform.position.y < -20)
        {
            gameObject.transform.position = new Vector3(0, 2, 0);
            rb.linearVelocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumps = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickupable"))
        {
            other.gameObject.SetActive(false);
            score += other.gameObject.GetComponent<Rotator>().pointValue;
            SetScoreText();
            if (score >= 20)
            {
                winText.SetActive(true);
            }
        } 
        else if (other.gameObject.CompareTag("JumpRefill"))
        {
            jumps = 0;
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}  
