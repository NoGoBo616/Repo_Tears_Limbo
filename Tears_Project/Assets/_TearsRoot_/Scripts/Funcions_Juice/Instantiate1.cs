using Unity.VisualScripting;
using UnityEngine;

public class Instantiate1 : MonoBehaviour
{
    bool select;
    public GameObject prefab;
    public HearthManagement corazones;

    private void OnEnable()
    {
        corazones = FindAnyObjectByType<HearthManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        select = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        select = false;
    }

    public void Collect()
    {
        if (select)
        {
            corazones.hearts = corazones.hearts + 0.5f;
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
