using System.Collections;
using UnityEngine;

public class HearthManagement : MonoBehaviour
{
    public float hearts;
    public Animator anim;
    public GameObject canvas;

    private void OnEnable()
    {
        hearts = 50;
        DontDestroyOnLoad(this.gameObject);
    }

    public void InAnim()
    {
        canvas.SetActive(true);
        anim.SetTrigger("In");
    }

    public void OutAnim()
    {
        StartCoroutine(Salir());
    }

    IEnumerator Salir()
    {
        anim.SetTrigger("Out");
        yield return new WaitForSeconds(0.4f);
        canvas.SetActive(false);
        yield return null;
    }
}
