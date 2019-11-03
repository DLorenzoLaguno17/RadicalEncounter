using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampImage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        icon.transform.position = namePos;
    }
}
