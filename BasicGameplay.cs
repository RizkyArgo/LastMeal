using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class BasicGameplay : MonoBehaviour
{
    public float speed = 15f;
    float walkSpeed = 15f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    public bool sampah = false;
    public GameObject E;
    public GameObject miniGame;
    public GameObject kamera;
    public GameObject menuPause;
    public GameObject atribut;
    public GameObject barHp;
    public GameObject menang;
    public GameObject proggres;
    public Slider darah;
    public Slider objektif;
    public GameObject vignette;
    public GameObject petunjuk;
    public GameObject screenGameOver;
    public GameObject terimaKasih;
    public GameObject dialog;
    bool berhenti = false;
    float batasXkiri = 5.0f;
    float batasXkanan = 4.5f;
    public bool mulai = false;
    bool mentok = false;
    bool kelaparan = false;
    bool ketangkep = false;
    bool gameOver = false;
    bool boost = false;
    public bool finish = false;
    bool petunjukSudahMuncul = false;
    bool selesai = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Vector3 kameraPosisi = new Vector3(-0.17f,kamera.transform.position.y,kamera.transform.position.z);
        int range = Random.Range(40,70);
        darah.value = range;
    }

    void Update()
    {

        if (finish == true)
        {
            menang.SetActive(true);
            barHp.SetActive(false);
            proggres.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                selesai = true;
            }
        }
        if (selesai == true)
        {
            terimaKasih.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(1);
                }
        }
        
        if (mulai == true){
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        movement = new Vector2(hInput, vInput).normalized;
        anim.SetFloat("velocityX", hInput);
        anim.SetFloat("velocityY", vInput);
        atribut.SetActive(true);
        darah.value -= 1f * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift) && darah.value >20)
        {
            boost = true;
            speed = walkSpeed * 2f;
            darah.value -= 10f * Time.deltaTime;
            }
            else
            {
                speed = walkSpeed;
            }
        }

        if (sampah && Input.GetKeyDown(KeyCode.E))
        {
            miniGame.SetActive(true);
            E.SetActive(false);
            mulai = false;
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
                barHp.SetActive(false);
                mulai = false;
                speed =0;
            }
        }

        if (darah.value <= 20)
        {
            vignette.SetActive(true);
            speed = 7f;
            boost = false;
        }

        if (darah.value == 0)
        {
            kelaparan = true;
            speed = 0;
            mulai = false;
            barHp.SetActive(false);
            proggres.gameObject.SetActive(false);
            screenGameOver.SetActive(true);
            gameOver = true;
            dialog.SetActive(false);
        }

        if (gameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
            // string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(1);
            }
        }

        if (objektif.value >= 3 && !petunjukSudahMuncul)
        {
            petunjukSudahMuncul = true;
         StartCoroutine(TampilkanPetunjuk());
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

        if (collision.CompareTag("Enemy"))
        {
            mulai = false;
            speed = 0;
        }

         if (collision.gameObject.CompareTag("Finish") && objektif.value == 3)
        {
            finish = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sampah"))
        {
            sampah = false;
            E.SetActive(false);
        }

        if (collision.CompareTag("Finish"))
        {
            finish = false;
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
        barHp.SetActive(true);
        berhenti = false;
    }

    public void Exit()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void Dialog()
    {
        mulai = false;
        atribut.SetActive(false);
    }

    IEnumerator TampilkanPetunjuk()
    {
    petunjuk.SetActive(true);
    yield return new WaitForSeconds(2f);
    petunjuk.SetActive(false);
    }
}