using System.Collections;
using UnityEngine;

/// <summary>
/// US-02: Enemies spawn in waves from four directions (N, E, S, W).
/// AC1: Each wave spawns from all four spawn points.
/// AC2: Each new wave has more enemies than the last.
/// AC3: The next wave starts only after all enemies are defeated
///      and a short break has passed (upgrade time).
/// </summary>
public class WaveSpawner : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints = new Transform[4]; // N, E, S, W

    [Header("Wave Settings")]
    [SerializeField] private int baseEnemiesPerWave = 4;
    [SerializeField] private int extraEnemiesPerWave = 2;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float breakBetweenWaves = 10f;

    public int CurrentWave { get; private set; }
    public int EnemiesAlive => GameObject.FindGameObjectsWithTag("Enemy").Length;
    public bool InBreak { get; private set; }

    private void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves()
    {
        while (true)
        {
            CurrentWave++;
            yield return StartCoroutine(SpawnWave(CurrentWave));

            // AC3: wait until every enemy is defeated.
            yield return new WaitUntil(() => EnemiesAlive == 0);

            // Break so the player can spend scrap on upgrades.
            InBreak = true;
            yield return new WaitForSeconds(breakBetweenWaves);
            InBreak = false;
        }
    }

    private IEnumerator SpawnWave(int wave)
    {
        int count = EnemiesForWave(wave, baseEnemiesPerWave, extraEnemiesPerWave);

        for (int i = 0; i < count; i++)
        {
            // AC1: rotate through the four spawn points so every side is used.
            Transform point = spawnPoints[i % spawnPoints.Length];
            if (point != null && enemyPrefab != null)
            {
                GameObject enemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);
                enemy.tag = "Enemy";
            }
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    /// <summary>
    /// AC2: Pure function so it can be unit tested.
    /// Wave 1 = base, each later wave adds 'extra' enemies.
    /// </summary>
    public static int EnemiesForWave(int wave, int baseCount, int extraPerWave)
    {
        if (wave < 1) return 0;
        return baseCount + (wave - 1) * extraPerWave;
    }
}
