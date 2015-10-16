using System.Collections;
using UnityEngine;

public class Bananas : MonoBehaviour
{
    public static int bananas
    {
        get
        {
            if (PlayerPrefs.HasKey("Bananas"))
            {
                return PlayerPrefs.GetInt("Bananas");
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetInt("Bananas", value);
            PlayerPrefs.Save();
        }
    }
}