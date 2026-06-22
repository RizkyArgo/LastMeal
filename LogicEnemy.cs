using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicEnemy : MonoBehaviour
{
    public bool ketahuan = false;
    public GameObject player;
    public GameObject hp;
    public GameObject proggres;
    public Animator anim;
    public GameObject vision;
    public GameObject kalah;
    public bool gerakKanan = false;
    public float speed = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemySpawn.masuk == true)
        {
            if (!gerakKanan)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                anim.SetFloat("Arah",0);
            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                anim.SetFloat("Arah",1);
            }
        }

        if (ketahuan == true)
        {
            kalah.SetActive(true);
            hp.SetActive(false);
            proggres.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                String sceneSekarang = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(sceneSekarang);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ketahuan = true;
            speed = 0;
        }

        if (collision.gameObject.CompareTag("kiri"))
        {
            gerakKanan = true;
        }

        if (collision.gameObject.CompareTag("kanan"))
        {
            gerakKanan = false;
        }
    }


}
