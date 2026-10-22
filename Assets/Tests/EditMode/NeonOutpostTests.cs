using NUnit.Framework;

/// <summary>
/// EditMode tests for the core game logic.
/// These run in the CI pipeline before a merge is allowed.
/// </summary>
public class NeonOutpostTests
{
    // ---------- EnemyChase (US-03) ----------

    [Test]
    public void Enemy_StartsChasing_WhenPlayerWithin5Units()
    {
        bool chasing = EnemyChase.UpdateChaseState(false, 4.9f, 5f, 10f);
        Assert.IsTrue(chasing);
    }

    [Test]
    public void Enemy_DoesNotChase_WhenPlayerFarAway()
    {
        bool chasing = EnemyChase.UpdateChaseState(false, 7f, 5f, 10f);
        Assert.IsFalse(chasing);
    }

    [Test]
    public void Enemy_KeepsChasing_Between5And10Units()
    {
        bool chasing = EnemyChase.UpdateChaseState(true, 8f, 5f, 10f);
        Assert.IsTrue(chasing);
    }

    [Test]
    public void Enemy_StopsChasing_Beyond10Units()
    {
        bool chasing = EnemyChase.UpdateChaseState(true, 10.1f, 5f, 10f);
        Assert.IsFalse(chasing);
    }

    // ---------- WaveSpawner (US-02) ----------

    [Test]
    public void Wave1_SpawnsBaseCount()
    {
        Assert.AreEqual(4, WaveSpawner.EnemiesForWave(1, 4, 2));
    }

    [Test]
    public void EachWave_HasMoreEnemiesThanLast()
    {
        int w2 = WaveSpawner.EnemiesForWave(2, 4, 2);
        int w3 = WaveSpawner.EnemiesForWave(3, 4, 2);
        Assert.Greater(w3, w2);
        Assert.AreEqual(8, w3);
    }

    [Test]
    public void InvalidWave_ReturnsZero()
    {
        Assert.AreEqual(0, WaveSpawner.EnemiesForWave(0, 4, 2));
    }
}
