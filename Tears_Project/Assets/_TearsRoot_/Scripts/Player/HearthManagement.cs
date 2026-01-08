using System.Collections;
using UnityEngine;

public class HearthManagement : MonoBehaviour
{
    public float hearts;
    public bool started;
    public Animator anim;
    public GameObject canvas;
    public Player_Controller player;
    public float pos;
    public bool[] objects;

    private void OnEnable()
    {
        started = true;
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
        player = FindAnyObjectByType<Player_Controller>();
        player.gameObject.transform.position = new Vector2(pos, player.gameObject.transform.position.y);
        anim.SetTrigger("Out");
        yield return new WaitForSeconds(0.4f);
        canvas.SetActive(false);
        yield return null;
    }
}
