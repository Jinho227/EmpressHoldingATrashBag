using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class system : MonoBehaviour
{
    public CustomerInfo[] customer;
    public BagItemInfo[] bag;
    bool customers = true;
    int customersnum = 0;
    public Text ctmDialog;
    public InputField priceInput;
    public Text yourMoneyText;
    public int youMoney = 0;
    int backClickCount = 0;
    private BagItemInfo clickBag;

    void Awake()
    {
        dataLoad();
        customer[0].gameObject.SetActive(true);
        customer[1].gameObject.SetActive(false);
        isBag(bag);
        yourMoneyText.text = youMoney.ToString();
    }

    public void isBag(BagItemInfo[] bag)
    {
        foreach(BagItemInfo b in bag)
        {
            if(b.totalNumber <= 0)
            {
                b.gameObject.SetActive(false);
            }
            else
            {
                b.gameObject.SetActive(true);
            }
        }
    }

    public void bagClick(BagItemInfo bag)
    {
        if (customers)
        {
            if (bag.bagQuality == customer[0].wantbagQuality)
            {
                ctmDialog.text = "좋아 얼마?";
                backClickCount = 0;
                clickBag = bag;
            }
            else
            {   
                if(iscustomerGone(customer[0], backClickCount))
                {
                    ctmDialog.text = "갈게";
                    backClickCount = 0;
                    customers = false;
                }
                else
                {
                    ctmDialog.text = "다른건 없어?";
                    backClickCount++;
                }
            }
        }
        else
        {
            if(bag.bagQuality == customer[1].wantbagQuality)
            {
                ctmDialog.text = "오 이거 괜찮네요. 얼마에요?";
                backClickCount = 0;
                clickBag = bag;
            }
            else
            {
                if (iscustomerGone(customer[1], backClickCount))
                {
                    ctmDialog.text = "원하는게 없네요.그냥 갈게요.";
                    backClickCount = 0;
                    customers = true;
                }
                else
                {
                    ctmDialog.text = "조금더 싼건 없나요?";
                    backClickCount++;
                }
            }
        }
        
    }

    private bool iscustomerGone(CustomerInfo tempCustomer, int count)
    {
        bool istrue = false;
        if (count == 0)
        {
            if (randomProbability(tempCustomer.goneoloOne))
            {
                gone(customer);
                istrue = true;
            }
            else
            {
                istrue = false;
            }
            return istrue;
        }
        else if (count == 1)
        {
            if (randomProbability(tempCustomer.goneolotwo))
            {
                gone(customer);
                istrue = true;
            }
            else
            {
                istrue = false;
            }
            return istrue;
        }
        else if(count >= 2)
        {
            if(randomProbability(tempCustomer.goneolothree))
        {
                gone(customer);
                istrue = true;
            }
            else
            {
                istrue = false;
            }
            return istrue;
        }
        else
        {
            return istrue;
        }
    }    

    private bool randomProbability(int probility)
    {
        int randomValue = Random.Range(0, 100);

        if(randomValue <= probility)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void gone(CustomerInfo[] tempCustomer)
    {
        if (customers)
        {
            customerChange(tempCustomer[0], tempCustomer[1]);
        }
        else
        {
            customerChange(tempCustomer[1], tempCustomer[0]);
        }
    }

    public void customerChange(CustomerInfo goneCustomer, CustomerInfo inCustomer)
    {
        goneCustomer.gameObject.SetActive(false);
        inCustomer.gameObject.SetActive(true);
        customersnum++;
    }

    public void priceOK()
    {
        int price = System.Int32.Parse(priceInput.text);
        if (customers)
        {
            isReasonable(price, customer[0]);
        }
        else
        {
            isReasonable(price, customer[1]);
        }
    }

    public void isReasonable(int price, CustomerInfo tempcustomer)
    {
        if((tempcustomer.maxPrice < price)||(tempcustomer.minPrice > price))
        {
            if(iscustomerGone(tempcustomer, backClickCount))
            {
                ctmDialog.text = "그냥 갈래.";
                customers = false;
            }
            else
            {
                ctmDialog.text = "다른 가격";
                backClickCount++;
            }
        }
        else
        {
            ctmDialog.text = "잘샀어";
            buyBag(price, tempcustomer);
            gone(customer);
            customers = customers ? false : true;
            backClickCount = 0;

            isBag(bag);
            if (customersnum > 2)
            {
                dataSave();
                Debug.Log('A');
                SceneManager.LoadScene("RecyclingScene");
            }
        }
    }
    public void buyBag(int price, CustomerInfo customer)
    {
        youMoney += price;
        yourMoneyText.text = youMoney.ToString();
        clickBag.totalNumber = 0;
    }

    private void dataSave()
    {
        PlayerPrefs.SetInt("youMoney", youMoney);

        for(int i = 0; i < bag.Length; i++)
        {
            PlayerPrefs.SetInt("bagTotalNumber" + i, bag[i].totalNumber);
        }
 
    }

    private void dataLoad()
    {
        youMoney = PlayerPrefs.GetInt("youMoney", 0);

        for (int i = 0; i < bag.Length; i++)
        {
            bag[i].totalNumber = PlayerPrefs.GetInt("bagTotalNumber" + i, 1);
        }
        PlayerItems();
    }

    public void dataDelete()
    {
        PlayerPrefs.DeleteAll();
    }

    private void PlayerItems()
    {
        int index = PlayerPrefs.GetInt("PlayerItemsIndex", 0);
        for(int i = 0; i < index; i++)
        {
            int temp = PlayerPrefs.GetInt("playerItems" + i, -1);
            if(temp == 20)
            {
                bag[1].totalNumber = 1;

            }
            else if(temp == 21)
            {
                bag[2].totalNumber = 1;

            }
        }

    }
}
