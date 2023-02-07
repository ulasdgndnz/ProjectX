using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject floor;

    private void Start()
    {
        float y = -.50f;
        for (float x = transform.position.x; x < transform.position.x + 21; x++)
        {
            for (float z = transform.position.z; z < transform.position.z + 21; z++)
            {
                var pos = new Vector3(x, y, z);
                Instantiate(floor, pos, Quaternion.identity, transform);
            }
        }
    }
}
