using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_Dialogue : MonoBehaviour
{
    public string[] dialogo;
    public int dialogoAct;
    public TMP_Text tmp;
    public bool canTalk;
    public float hearts;

    [Header("Minijuegos")]
    public int frasePrevia;
    public GameObject minigame;
    public bool hasMinigame;
    public Player_Controller player;

    [Header("Preguntas")]
    public bool hasQuest;
    public bool respondio;
    public int question;
    public GameObject anksweres;
    public string yep;
    public string nop;

    private void Start()
    {
        minigame.SetActive(false);
        player = FindAnyObjectByType<Player_Controller>();
        anksweres.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
        dialogoAct = 0;
        anksweres.SetActive(false);
    }

    void Update()
    {
        if (dialogoAct == dialogo.Length) dialogoAct = 0;
        if (!respondio) tmp.text = dialogo[dialogoAct];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    public void HandleTalk()
    {
        if (canTalk && !player.pause)
        {
            anksweres.SetActive(false);
            respondio = false;
            if (dialogoAct == frasePrevia && hasMinigame)
            {
                minigame.gameObject.SetActive(true);
            }
            if (dialogoAct == question && hasQuest)
            {
                anksweres.SetActive(true);
            }
            dialogoAct++;
            StartCoroutine(Cool());
            if (dialogoAct == dialogo.Length - 1)
            {
                player.corason = player.corason + hearts;
            }
        }
    }

    public void Response(bool correct)
    {
        respondio = true;
        if (!correct)
        {
            tmp.text = nop;
            hearts = hearts - 5;
        }
        else
        {
            tmp.text = yep;
            if (hearts == -5)
            {
                hearts = hearts + 5;
            }
            hearts = hearts + 5;
        }
        anksweres.SetActive(false);
    }

    IEnumerator Cool()
    {
        canTalk = false;
        yield return new WaitForSeconds(0.2f);
        canTalk = true;
        yield return null;
    }
}
