using UnityEngine;
public class BasicGameplay : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    public bool sampah = false;
    public GameObject E;
    public GameObject miniGame;
    public GameObject kamera;
    float batasXkiri = 5.0f;
    float batasXkanan = 4.5f;
    bool mulai = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (mulai == true){
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        movement = new Vector2(hInput, vInput).normalized;
        anim.SetFloat("velocityX", hInput);
        anim.SetFloat("velocityY", vInput);
        }

        if (sampah && Input.GetKeyDown(KeyCode.E))
            {
                miniGame.SetActive(true);
                E.SetActive(false);
            }
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
            E.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sampah"))
        {
            sampah = false;
            E.SetActive(false);
        }
    }

    public void StartGame()
    {
        mulai = true;
    }
}