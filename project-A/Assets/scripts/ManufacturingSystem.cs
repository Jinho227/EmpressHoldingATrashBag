using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManufacturingSystem : MonoBehaviour
{
   public void goStoreScene()
    {
        SceneManager.LoadScene("storeScene");
    }
}
