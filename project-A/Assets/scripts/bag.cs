using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class bag : MonoBehaviour
{
    public Text chatText;

    void Start()
    {

        // Add a listener to the button's onClick event, which will call the ChangeText() method
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeText);
    }

    public abstract void ChangeText();
}
