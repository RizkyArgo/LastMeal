using UnityEngine;
public class BasicGameplay : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    public bool sampah = false;
    public GameObject button;
    public GameObject kamera;
    float batasXkiri = 5.0f;
    float batasXkanan = 4.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        movement = new Vector2(hInput, vInput).normalized;
        anim.SetFloat("velocityX", hInput);
        anim.SetFloat("velocityY", vInput);
        // if (transform.position.x < -30)
        // {
        //     kamera.transform.position = new Vector3(-1f, kamera.transform.position.y, kamera.transform.position.z);
        // } 
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sampah"))
        {
            sampah = true;
            button.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sampah"))
        {
            sampah = false;
            button.SetActive(false);
        }
    }
}