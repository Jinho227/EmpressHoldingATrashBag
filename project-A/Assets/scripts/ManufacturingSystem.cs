using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManufacturingSystem : MonoBehaviour
{
    private int bagnum = 1;
    public void bagchange(int i)
    {
        bagnum = i;
    }
    public void addbag()
    {
        PlayerPrefs.SetInt("bagTotalNumber" + bagnum, 1);
    }
    public void goStoreScene()
    {
        SceneManager.LoadScene("storeScene");
    }
}
