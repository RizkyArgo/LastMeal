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
    public bool mentok = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Vector3 kameraPosisi = new Vector3(-0.17f,kamera.transform.position.y,kamera.transform.position.z);
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

        if (mentok == false)
            {
                Vector3 kameraPosisi = new Vector3(-0.17f,kamera.transform.position.y,kamera.transform.position.z);
                kamera.transform.position = kameraPosisi;
            }
        else if (transform.position.x <= -31.5f && mentok == true)
            {
                Vector3 kameraMentok = new Vector3(-31.42f,kamera.transform.position.y,kamera.transform.position.z);
                kamera.transform.position = kameraMentok;
            }
        else if (transform.position.x >= 31.5f && mentok == true)
            {
                Vector3 kameraMentok = new Vector3(31.35f,kamera.transform.position.y,kamera.transform.position.z);
                kamera.transform.position = kameraMentok;
            }
        else
        {
            kamera.transform.position = new Vector3(-0.17f,kamera.transform.position.y,kamera.transform.position.z);
        }

        if (transform.position.x <= -31.5f || transform.position.x >= 31.5f)
            {
                mentok = true;
            }
        else
            {
                mentok = false;
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