using UnityEngine;

public class prefab : MonoBehaviour
{
    public GameObject Prefab;

    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);

    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));

    }
    private void Spawn()
    {
        GameObject pipes = Instantiate(Prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }
}
  