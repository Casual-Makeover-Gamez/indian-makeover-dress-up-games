using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Links : MonoBehaviour
{

    public void MoreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=8684617111273776670");
    }
    public void RateUS()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.casualmakeovergamez.makeover.dressup.games");
    }
    public void PP()
    {
        Application.OpenURL("https://sites.google.com/view/casual-makeover-gamez");
    }

}
