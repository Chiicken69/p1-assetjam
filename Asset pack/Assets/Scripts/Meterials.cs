using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Meterials : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI wood;
    [SerializeField] TextMeshProUGUI stone;
    [SerializeField] TextMeshProUGUI gold;

    // Update is called once per frame
    void Update()
    {

        wood.text = resources.display( resources.get_Wood() );
        stone.text = resources.display(resources.get_Stone());
        gold.text = resources.display(resources.get_Gold());
    }
}

public static class resources
{

    static ulong wood = 5000;
    static ulong stone = 50000000;
    static ulong gold = 500000000000;


    public static ulong get_Wood() => wood;
    public static ulong get_Stone() => stone;
    public static ulong get_Gold() => gold;

    public static string display(ulong x)
    {
        
        uint power = (uint)Mathf.Log10(x)/3;
        string number = x.ToString();
        number = number.Substring(0, number.Length - (int)power * 3);

        switch (power)
        {
            case 0:
                return number;

            case 1:
                return number + 'K';

            case 2:
                return number + 'M';

            case 3:
                return number + 'B';

            default:
                return "----";
        }
    }

}