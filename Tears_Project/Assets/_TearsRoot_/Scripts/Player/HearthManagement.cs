using System.Collections;
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
    bool inGame;

    private void OnEnable()
    {
        started = true;
        inGame = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public void InAnim()
    {
        canvas.SetActive(true);
        anim.SetTrigger("In");
    }

    private void Update()
    {
        if (inGame)
        {
            if (hearts <= 0)
            {
                YouLost();
                inGame = false;
            }

            if (hearts >= 100)
            {
                YouWin();
                inGame = false;
            }
        }
    }

    public void OutAnim()
    {
        StartCoroutine(Salir());
    }

    public void YouLost()
    {
        InAnim();
        SceneManager.LoadScene(8);
        OutAnim();
    }

    public void YouWin()
    {
        InAnim();
        SceneManager.LoadScene(9);
        OutAnim();
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
