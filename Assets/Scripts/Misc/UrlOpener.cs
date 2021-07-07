using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic url opener
public class UrlOpener : MonoBehaviour
{
    public void OpenUrl()   //Open url on button click
    {
        Application.OpenURL("www.sharashino.dev/sis");
    }
}
