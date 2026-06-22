using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject musuh;
    public static bool masuk = false;
    public static float speed = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (masuk == true)
        {
            musuh.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            masuk = true;
        }
    }
}
