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
    public int frasePrevia;
    public int minigame;
    public bool hasMinigame;

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
        dialogoAct = 0;
    }

    void Update()
    {
        if (dialogoAct == dialogo.Length) dialogoAct = 0;
        tmp.text = dialogo[dialogoAct];
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
        if (canTalk)
        {
            if (dialogoAct == frasePrevia && hasMinigame)
            {
                SceneManager.LoadScene(minigame);
            }
            dialogoAct++;
            StartCoroutine(Cool());
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
