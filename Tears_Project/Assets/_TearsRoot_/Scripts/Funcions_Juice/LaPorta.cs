using System.Collections;
using TMPro;
using UnityEngine;

public class LaPorta : MonoBehaviour
{
    public TMP_Text tmp;
    public string[] tutorial;
    public string[] dialoge;
    public string[] final;
    public int tutorialWord;
    public bool canTalk;
    public HearthManagement player;

    private void Start()
    {
        player = FindAnyObjectByType<HearthManagement> ();
    }

    private void OnEnable()
    {
        canTalk = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tutorialWord = 0;
            canTalk = false;
        }
    }

    public void HandleTalk()
    {
        if (canTalk)
        {
            StartCoroutine(Cool());
            tutorialWord++;
            if (tutorialWord == tutorial.Length)
            {
                player.started = false;
            }
        }
    }

    void Update()
    {
        if (tutorialWord == tutorial.Length)
        {
            tutorialWord = 0;
        }

        if (player.started)
        {
            tmp.text = tutorial[tutorialWord];
        }
        else
        {
            if (player.hearts <= 95)
            {
                tmp.text = dialoge[tutorialWord];
            }

            if (player.hearts >= 96)
            {
                tmp.text = final[tutorialWord];
            }
        }
    }

    IEnumerator Cool()
    {
        canTalk = false;
        yield return new WaitForSeconds(0.2f);
        canTalk = true;
        yield return null;
    }
}
