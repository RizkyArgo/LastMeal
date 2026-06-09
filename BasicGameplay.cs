using UnityEngine;
using UnityEngine.SceneManagement;
public class BasicGameplay : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    public bool sampah = false;
    public GameObject E;
    public GameObject miniGame;
    public GameObject kamera;
    public GameObject pause;
    public GameObject menuPause;
    bool berhenti = false;
    float batasXkiri = 5.0f;
    float batasXkanan = 4.5f;
    bool mulai = false;
    bool mentok = false;
    

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
        pause.SetActive(true);
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


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            float lari = speed *=2;
            speed = lari;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 15f;
        }

         if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            berhenti = true;
            if (berhenti == true)
            {
                menuPause.SetActive(true);
                mulai = false;
                speed =0;

            }
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

    public void Pause()
    {
        berhenti = true;
        mulai = false;
        speed = 0;
        menuPause.SetActive(true);
    }

    public void Resume()
    {
        mulai = true;
        speed = 15;
        menuPause.SetActive(false);
        berhenti = false;
    }

    public void Exit()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}