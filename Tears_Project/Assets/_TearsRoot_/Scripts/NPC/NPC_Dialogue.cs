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
    public HearthManagement hM;
    public Player_Controller player;

    [Header("Preguntas")]
    public bool hasQuest;
    public bool hasQuest2;
    public bool respondio;
    public int question;
    public int question2;
    public GameObject anksweres;
    public GameObject anksweres2;
    public string yep;
    public string yep2;
    public string nop;
    public string nop2;

    private void OnEnable()
    {
        hM = FindAnyObjectByType<HearthManagement>();
        player = FindAnyObjectByType<Player_Controller>();
    }

    private void Start()
    {
        minigame.SetActive(false);
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
            if (dialogoAct == question2 && hasQuest2)
            {
                anksweres2.SetActive(true);
            }

            dialogoAct++;
            StartCoroutine(Cool());
            if (dialogoAct == dialogo.Length)
            {
                hM.hearts = hM.hearts + hearts;
                hearts = 0;
            }
        }
    }

    public void Response(bool correct)
    {
        respondio = true;
        if (!correct)
        {
            dialogoAct = dialogo.Length-1;
            tmp.text = nop;
        }
        else
        {
            tmp.text = yep;
        }
        anksweres.SetActive(false);
    }

    public void Response2(bool correct)
    {
        respondio = true;
        if (!correct)
        {
            dialogoAct = dialogo.Length-1;
            tmp.text = nop2;
        }
        else
        {
            tmp.text = yep2;
        }
        anksweres2.SetActive(false);
    }

    IEnumerator Cool()
    {
        canTalk = false;
        yield return new WaitForSeconds(0.2f);
        canTalk = true;
        yield return null;
    }
}
