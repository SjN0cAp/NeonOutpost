using UnityEngine;

/// <summary>
/// US-03: Enemy chases the player when close.
/// AC1: Detects player within 5 units.
/// AC2: Moves toward player at speed 3.
/// AC3: Stops chasing beyond 10 units.
/// </summary>
public class EnemyChase : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform player;

    [Header("Chase Settings")]
    [SerializeField] private float detectRange = 5f;   // AC1
    [SerializeField] private float moveSpeed = 3f;     // AC2
    [SerializeField] private float loseRange = 10f;    // AC3

    public bool IsChasing { get; private set; }

    private void Start()
    {
        // Find the player automatically if it was not set in the Inspector.
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found != null) player = found.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        IsChasing = UpdateChaseState(IsChasing, distance, detectRange, loseRange);

        if (IsChasing)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Pure logic kept separate so it can be unit tested.
    /// Start chasing inside detectRange, keep chasing until beyond loseRange.
    /// </summary>
    public static bool UpdateChaseState(bool currentlyChasing, float distance,
                                        float detectRange, float loseRange)
    {
        if (!currentlyChasing && distance <= detectRange) return true;
        if (currentlyChasing && distance > loseRange) return false;
        return currentlyChasing;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, loseRange);
    }
}
