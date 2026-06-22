using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.TextCore;

public class MiniGame : MonoBehaviour
{
    private RectTransform rectTransform;
    public RandomReward rng;
    public GameObject tutup;
    private RectTransform hitArea;
    private RectTransform spasiArea;
    private RectTransform ijoArea;
    public GameObject hit;
    public Slider proggres;
    public GameObject kanvas;
    public GameObject tamat;
    public GameObject spasi;
    public GameObject buka;
    public GameObject menang;
    public bool selesai;
    public GameObject hp;
    public Slider objektif;

    public float kecepatan = 200f;
    private bool naik = true;
    bool masuk = false;
    public BasicGameplay basicGameplay;
    public AudioManager audioManager;

    void Start()
    {
        spasiArea = spasi.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
        hit = GameObject.Find("hit");
        hitArea = hit.GetComponent<RectTransform>();
        proggres.value = 0;
        proggres.maxValue = Random.Range(3, 5);
    }

    void Update()
    {
        if (naik)
        {
            rectTransform.anchoredPosition += Vector2.up * kecepatan * Time.deltaTime;

            if (rectTransform.anchoredPosition.y >= 44)
            {
                naik = false;
            }
        }
        else
        {
            rectTransform.anchoredPosition += Vector2.down * kecepatan * Time.deltaTime;
            if (rectTransform.anchoredPosition.y <= -44)
            {
                naik = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            spasi.transform.localScale = new Vector3(0.73f, 0.354369f, 0.354369f);
            float acak = Random.Range(-5.5f,5.5f);
            buka.transform.rotation = Quaternion.Euler(0,0,acak);

            if (masuk == true)
            {
                proggres.value += 1;
                pindahTarget();
                audioManager.playSFX(audioManager.sampah);
                if (proggres.value >= proggres.maxValue)
                {
                    kanvas.SetActive(false);
                    rng.Hadiah();
                    proggres.value = 0;
                    tutup.SetActive(true);
                    objektif.value += 1;
                    basicGameplay.StartGame();
                }
            }

            if (objektif.value >= 3)
            {
                menang.SetActive(true);
                selesai = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 awal = new Vector3(1f,0.4854369f,0.4854369f);
            spasi.transform.localScale = awal;
            buka.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == hit)
        {
            masuk = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == hit)
        {
            masuk = false;
        }
    }

    void pindahTarget()
    {
        float posisiBaru = Random.Range(-44, 44);
        hit.GetComponent<RectTransform>().anchoredPosition = new Vector2(hit.GetComponent<RectTransform>().anchoredPosition.x, posisiBaru);
    }
}