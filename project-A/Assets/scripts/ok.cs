using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ok : MonoBehaviour
{
    public InputField priceInput;
    public bool isReasonablePrice = false;
    public Text chatText;

    public void priceOK()
    {
        int price = Int32.Parse(priceInput.text);
        isReasonable(price);
    }

    public void isReasonable(int price)
    {
        if(6000 > price)
        {
            chatText.text = "너무 싸구련데";
        }
        else if(price > 10000)
        {
            chatText.text = "나를 너무 호구로 아는데?";
        }
        else
        {
            chatText.text = "좋네 사지";
        }
    }

}
