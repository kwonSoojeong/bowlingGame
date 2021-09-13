using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KnockedPinInputButton : MonoBehaviour
{
    public void OnClickBtn(int num)
    {
        GameManager.Instance.InputPins(num);
        
    }
    public void setAbleBtns(int lastNum)
    {
        Debug.Log("lastNum " + lastNum);
        for (int i = 0; i<=10; i++)
        {
            if (i > lastNum)
            {
                transform.GetChild(0).GetChild(i).GetComponent<Button>().interactable = false;
                string name1 = transform.GetChild(0).GetChild(i).name;
                Debug.Log(">> " + name1);
            }
            else
            {
                transform.GetChild(0).GetChild(i).GetComponent<Button>().interactable = true;
                string name1 = transform.GetChild(0).GetChild(i).name;
                Debug.Log("lastNum ���� ���� >> " + name1);
            }
        }
    }

}