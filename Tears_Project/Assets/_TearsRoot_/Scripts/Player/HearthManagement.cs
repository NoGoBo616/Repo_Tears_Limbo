using System.Collections;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        DontDestroyOnLoad(this.gameObject);
    }

    public void InAnim()
    {
        canvas.SetActive(true);
        anim.SetTrigger("In");
    }

    private void Update()
    {
        if (hearts <= 0)
        {
            InAnim();
            SceneManager.LoadScene(8);
            Salir();
            Destroy(this.gameObject);
        }

        if (hearts >= 100)
        {
            InAnim();
            SceneManager.LoadScene(9);
            Salir();
            Destroy(this.gameObject);
        }
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
