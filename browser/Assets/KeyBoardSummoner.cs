using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.UI.Keyboard;
public class KeyBoardSummoner : MonoBehaviour, IInputClickHandler
{
    UnityEngine.TouchScreenKeyboard keyboard;
    public static string keyboardText = "";

    public void OnInputClicked(InputClickedEventData eventData)
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
