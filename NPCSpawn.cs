using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject[] npcPrefabs;     // Isi NPC_A, NPC_B, NPC_C (yang sudah dipasang Collider Trigger & script detector)
    public Transform[] spawnPoints;     // Isi Pos1, Pos2, Pos3 di map kamu

    void Start()
    {
        // Jalankan fungsi spawn sekali saja pas game baru dinyalain
        SpawnNPCsAtPositions();
    }

    void SpawnNPCsAtPositions()
    {
        // Memastikan jumlah pos dan prefab aman
        int jumlahSpawn = Mathf.Min(npcPrefabs.Length, spawnPoints.Length);

        for (int i = 0; i < jumlahSpawn; i++)
        {
            // Munculkan NPC tepat di koordinat titik Pos masing-masing
            Instantiate(npcPrefabs[i], spawnPoints[i].position, Quaternion.identity);
        }
    }
}