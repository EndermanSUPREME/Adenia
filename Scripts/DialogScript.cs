using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogScript : MonoBehaviour
{
    [SerializeField] [TextArea(14, 10)] string[] dialogText;
    [SerializeField] int currentIndex, eventIndex;
    [SerializeField] Text displayText;

    public int UsedIndex;

    [SerializeField] UnityEvent GameEvent = new UnityEvent();

    public bool TestSwitch;

    void Start()
    {
        displayText.text = "";
        StartCoroutine(LoadText());
    }

    void Update()
    {
        UsedIndex = currentIndex;

        // Tests fluidity of dialog transition
        if (TestSwitch == true)
        {
            GetNextText();
            TestSwitch = false;
        }

        // takes the object connected to the script (in this case a UI Text obj. and checks if the text EQUALS the string of the pulled array index values)
        if (transform.GetComponent<Text>().text == dialogText[eventIndex])
        {
            // allows me to hook objects that connect to scripts with public methods that I can execute
            GameEvent.Invoke();
        }
    }

    // this Coroutine is what generates the dialog one character or CHAR at a time per frame
    IEnumerator LoadText()
    {
            if (displayText.text != dialogText[currentIndex])
            {
                foreach (char letter in dialogText[currentIndex].ToCharArray())
                {
                    displayText.text += letter;
                    yield return null;
                }
            }
    }

    // simply increases the index integer thats used to pull a desired index of the string[] (array) as well as resetting the UI_Text.text to blank and Starts the coroutine
    public void GetNextText()
    {
        if (displayText.text == dialogText[currentIndex])
        {
            StopCoroutine(LoadText());
            if (currentIndex < dialogText.Length - 1)
            {
                currentIndex++;
                displayText.text = "";
                StartCoroutine(LoadText());
            }
        }
    }
}//EndScript