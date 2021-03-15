using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Spawners
{
    [RequireComponent(typeof(BoxCollider))]
    public class SpawnerVolumes : MonoBehaviour
    {
        private BoxCollider Collider;
        // Start is called before the first frame update
        private void Awake()
        {
            Collider = GetComponent<BoxCollider>();
        }

        public Vector3 GetPositionInBounds()
        {
            Bounds bound = Collider.bounds;
            return new Vector3(
                Random.Range(bound.min.x, bound.max.x),
                transform.position.y,
                Random.Range(bound.min.z, bound.max.z)
            );
        }
    }
}
