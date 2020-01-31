using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioClip invalidClip;
    public AudioClip validClip;

    public GameObject startPanel;
    public GameObject playPanel;
    public GameObject winPanel;
    public GameObject loosePanel;

    public InputField[] inputFields;
    public Button[] buttons;
    public Text[] buttonsText;

    public float timeLeft = 3600;

    public List<string> room = new List<string>();
    public List<string> building = new List<string>();
    public List<string> street = new List<string>();
    public List<string> town = new List<string>();
    public List<string> date = new List<string>();
    public bool[] winCondition;

    private AudioSource audioSource;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
        Initialization();
    }

    void Update() 
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            playPanel.SetActive(false);
            loosePanel.SetActive(true);
        }
    }

    public void Initialization() {
        for (int i = 0; i < 5; i++)
        {
            inputFields[i].enabled = true;
            inputFields[i].text = "";
            buttons[i].interactable = true;
            buttonsText[i].color = Color.black;
            winCondition[i] = false;
        }
        startPanel.SetActive(true);
        playPanel.SetActive(false);
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
    }

    private void AnswerValidation(int index) 
    {
        inputFields[index].enabled = false;
        buttons[index].interactable = false;
        buttonsText[index].color = Color.green;
        winCondition[index] = true;
    }

    public void CheckAnswer(int index) 
    {
        string answer = inputFields[index].text.ToLower();

        switch (index) 
        {
            case 0:
                if (room.Find(x => x == answer) != null)
                {
                    AnswerValidation(index);
                    audioSource.PlayOneShot(validClip, 0.8f);
                }
                else
                    audioSource.PlayOneShot(invalidClip, 0.8f);
                break;
            case 1:
                if (building.Find(x => x == answer) != null)
                {
                    AnswerValidation(index);        
                    audioSource.PlayOneShot(validClip, 0.8f);
                }
                else
                    audioSource.PlayOneShot(invalidClip, 0.8f);
                break;
            case 2:
                if (street.Find(x => x == answer) != null)
                {
                    AnswerValidation(index);
                    audioSource.PlayOneShot(validClip, 0.8f);
                }
                else
                    audioSource.PlayOneShot(invalidClip, 0.8f);
                break;
            case 3:
                if (town.Find(x => x == answer) != null)
                {
                    AnswerValidation(index);
                    audioSource.PlayOneShot(validClip, 0.8f);
                }
                else
                    audioSource.PlayOneShot(invalidClip, 0.8f);
                break;
            case 4:
                if (date.Find(x => x == answer) != null)
                {
                    AnswerValidation(index);
                    audioSource.PlayOneShot(validClip, 0.8f);
                }
                else
                    audioSource.PlayOneShot(invalidClip, 0.8f);
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    public void CheckRebootCondition() 
    {
        foreach(bool condition in winCondition)
        {
            if (condition == false)
            {
                audioSource.PlayOneShot(invalidClip, 0.8f);
                return;
            }
        }
        playPanel.SetActive(false);
        winPanel.SetActive(true);
    }
}
