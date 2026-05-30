using UnityEngine;

public class NPCZoneDetector : MonoBehaviour
{
    // Fungsi otomatis Unity saat ada objek lain masuk ke dalam Collider Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang masuk memiliki Tag "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + ": Hei Player! Kamu masuk ke wilayah kekuasaanku!");
            
            // TULIS AKSI KAMU DI SINI
            // Contoh: Panggil fungsi buat munculin teks dialog, manggil monster, dll.
            MulaiAksiWilayah();
        }
    }

    // Fungsi otomatis Unity saat Player keluar dari area wilayah NPC
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(gameObject.name + ": Player sudah keluar dari wilayahku.");
            // Contoh: Sembunyikan teks dialog atau stop mengejar
        }
    }

    void MulaiAksiWilayah()
    {
        // Tempat kamu berkreasi nantinya, misal:
        // - Mengubah warna kotak dummy untuk nandain dia nge-trigger
        GetComponent<SpriteRenderer>().color = Color.green;
    }
}