using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sequence : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject sequencePanel;
    public GameObject playPanel;
    public Text sequenceText;

    public void PlaySequence()
    {
        startPanel.SetActive(false);
        sequencePanel.SetActive(true);
        StartCoroutine(Sequencing());
    }

    private IEnumerator Sequencing() 
    {
        sequenceText.text = "Initilization du programme";
        yield return new WaitForSeconds(1f);
        sequenceText.text = "Mangeons des chips";
        yield return new WaitForSeconds(1f);
        sequenceText.text = "Coule un bonze";
        yield return new WaitForSeconds(1f);
        sequenceText.text = "Phrase numero 4";
        yield return new WaitForSeconds(1f);

        sequencePanel.SetActive(false);
        playPanel.SetActive(true);        
    }
}
