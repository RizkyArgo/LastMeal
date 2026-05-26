using UnityEngine;
using System.Collections; // Wajib untuk Coroutine

public class RandomReward : MonoBehaviour
{
    public GameObject[] hadiah;
    public GameObject efek;
    public GameObject terpilih;
    public void Hadiah()
    {
        int index = Random.Range(0, hadiah.Length);
        terpilih = hadiah[index];
        terpilih.SetActive(true);

        StartCoroutine(AnimateScale(terpilih.transform));
    }

    IEnumerator AnimateScale(Transform target)
    {
        float durasi = 0.5f;
        Vector3 skalaAwal = Vector3.zero;
        Vector3 skalaTarget = new Vector3(2.5f,2.5f,2.5f);
        float elapsed = 0f;
        efek.SetActive(true);

        target.localScale = skalaAwal;

        while (elapsed < durasi)
        {
            elapsed += Time.deltaTime;
            target.localScale = Vector3.Lerp(skalaAwal, skalaTarget, elapsed / durasi);
            yield return null;
        }

        target.localScale = skalaTarget;
    }

   public void TutupHadiah()
    {
    efek.SetActive(false);
    terpilih.SetActive(false);
    
    terpilih = null;
    }

}