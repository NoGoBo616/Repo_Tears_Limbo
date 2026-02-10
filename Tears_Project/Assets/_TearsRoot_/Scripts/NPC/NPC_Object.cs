using System.Collections;
using TMPro;
using UnityEngine;

public class NPC_Object : MonoBehaviour
{
    public string[] dialogo;
    public string[] dialogoBueno;
    public int dialogoAct;
    public int objeto;
    public TMP_Text tmp;
    public bool canTalk;
    public bool friend;
    public HearthManagement comprovador;

    [Header("Corazones")]
    public float hearts;
    public int veces;
    public int meCanse;

    private void OnEnable()
    {
        comprovador = FindAnyObjectByType<HearthManagement>();
    }

    private void Update()
    {
        if (comprovador.objects[objeto] == true)
        {
            friend = true;
        }
        else
        {
            friend = false;
        }

        if (friend)
        {
            if (dialogoAct == dialogoBueno.Length)
            {
                if (hearts > 0)
                {
                    comprovador.hearts = comprovador.hearts + hearts;
                    hearts = 0;
                } 
                dialogoAct = 0;
            }
            tmp.text = dialogoBueno[dialogoAct];
        }
        else
        {
            if (dialogoAct == dialogo.Length)
            {
                veces++;
                if (veces >= meCanse)
                {
                    comprovador.hearts = comprovador.hearts - 10;
                    veces = 0;
                }
                dialogoAct = 0;
            }
            tmp.text = dialogo[dialogoAct];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
        dialogoAct = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    public void Interact()
    {
        if (canTalk)
        {
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
