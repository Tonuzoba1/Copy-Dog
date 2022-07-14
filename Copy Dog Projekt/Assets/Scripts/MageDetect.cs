using UnityEngine;

public class MageDetect : MonoBehaviour
{
    [SerializeField] private AllyMovement allyMovementScript;
    [SerializeField] private BoxCollider2D detector;
    [SerializeField] private LayerMask enemyLayer;

    void Start()
    {
        allyMovementScript = GetComponent<AllyMovement>();
    }

    void Update()
    {
        if (detector.IsTouchingLayers(enemyLayer))
        {
            allyMovementScript.EnemyInRange();
        }
    }
}
