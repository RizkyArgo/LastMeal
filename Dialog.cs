using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public string[] teks;
    public BasicGameplay gameplayScript;
    private int index;
    public AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    textComponent.text = string.Empty;
    gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == teks[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = teks[index];
            }
        }
    }

    public void startDialog()
    {
        audioManager.PlayBGM(audioManager.backsound);
        index = 0;
        audioManager.playSFX(audioManager.ngetik);
        StartCoroutine(tulis());   
            
    }
    IEnumerator tulis()
    {
        foreach(char t in teks[index].ToCharArray())
        {
            textComponent.text += t;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if (index < teks.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(tulis());
        }
        else
        {
            gameObject.SetActive(false);
            audioManager.playSFX(audioManager.laper);
            gameplayScript.StartGame();
        }
    }

    public void MulaiDialog()
    {
    gameObject.SetActive(true);
    startDialog();
    }
}
