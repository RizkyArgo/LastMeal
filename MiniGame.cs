using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    private RectTransform rectTransform;
    public RandomReward rng;
    public GameObject tutup;
    private RectTransform hitArea;
    private RectTransform ijoArea;
    public GameObject hit;
    public Slider proggres;
    public GameObject kanvas;

    public float kecepatan = 200f;
    private bool naik = true;
    bool masuk = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        hit = GameObject.Find("hit");
        hitArea = hit.GetComponent<RectTransform>();
        proggres.value = 0;
        proggres.maxValue = 4;
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
            if (masuk == true)
            {
                proggres.value += 1;
                pindahTarget();
                if (proggres.value >= 4)
                {
                    kanvas.SetActive(false);
                    rng.Hadiah();
                    proggres.value = 0;
                    tutup.SetActive(true);
                }
            }
            else
            {
                
            }
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
        float posisiBaru = Random.Range(-44,44);
        hit.GetComponent<RectTransform>().anchoredPosition = new Vector2(hit.GetComponent<RectTransform>().anchoredPosition.x,posisiBaru);
    }

   
    
}