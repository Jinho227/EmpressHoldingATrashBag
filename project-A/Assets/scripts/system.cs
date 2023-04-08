using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    int youMoney = 0;

    void Start()
    {
        customer[0].gameObject.SetActive(true);
        customer[1].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isBag(bag);
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
        int count = 0;
        if (customers)
        {
            if (bag.bagQuality == customer[0].wantbagQuality)
            {
                ctmDialog.text = "좋아 얼마?";
            }
            else
            {   
                if(iscustomerGone(customer[0], count))
                {
                    ctmDialog.text = "갈게";
                }
                else
                {
                    ctmDialog.text = "다른건 없어?";
                }
            }
        }
        else
        {
            if(bag.bagQuality == customer[1].wantbagQuality)
            {
                ctmDialog.text = "좋아요 얼마?";
            }
            else
            {
                if (iscustomerGone(customer[0], count))
                {
                    ctmDialog.text = "갈게요";
                }
                else
                {
                    ctmDialog.text = "다른건 없어요?";
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
        else if(count == 2)
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

        if(randomValue >= probility)
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
        if(customersnum < 3)
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
    }

    IEnumerable customerChange(CustomerInfo goneCustomer, CustomerInfo inCustomer)
    {
        yield return new WaitForSeconds(2);
        goneCustomer.gameObject.SetActive(false);
        inCustomer.gameObject.SetActive(true);
        customersnum++;
        yield return null;
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

    public void isReasonable(int price, CustomerInfo customer)
    {
        if(customer.maxPrice < price)
        {

        }
    }
}
