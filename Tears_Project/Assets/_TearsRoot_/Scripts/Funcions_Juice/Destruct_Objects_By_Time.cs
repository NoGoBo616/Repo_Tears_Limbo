using System.Collections;
using UnityEngine;

public class Destruct_Objects_By_Time : MonoBehaviour
{
    public float time;

    private void OnEnable()
    {
        StartCoroutine(Destruct());
    }

    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
        yield return null;
    }
}
