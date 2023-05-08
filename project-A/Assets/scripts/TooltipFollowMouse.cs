using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipFollowMouse : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position = Input.mousePosition + new Vector3(50, 0, 0);
    }
}
