using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class GUIBowlingPrintAPI : MonoBehaviour, IBowlingPrintAPI
    {
    public GameObject MessageBox;
    public GameObject ScoreTable;
        public void EndMessage(string message)
        {
            MessageBox.GetComponent<Text>().color = Color.blue;
            MessageBox.GetComponent<Text>().text = "<!> " + message;

            GameObject.Find("KnockedPinInput").GetComponent<KnockedPinInputButton>().setAbleBtns(-1);
        }

        public void LeftPins(int count)
        {
            MessageBox.GetComponent<Text>().color = Color.blue;
            MessageBox.GetComponent<Text>().text = $"Please click between 0 and {count}." ;

            GameObject.Find("KnockedPinInput").GetComponent<KnockedPinInputButton>().setAbleBtns(count);
        }

        public void PrintError(string error)
        {
            MessageBox.GetComponent<Text>().color = Color.red;
            MessageBox.GetComponent<Text>().text = "<!>" + error;
        }

        public void PrintMessage(string message)
        {
            MessageBox.GetComponent<Text>().color = Color.black;
            MessageBox.GetComponent<Text>().text = message;
        }

        public void PrintScroeBoard(List<Frame> frames)
        {
            MessageBox.GetComponent<Text>().color = Color.black;
            MessageBox.GetComponent<Text>().text = "Update Scroe board";

            // Frame 별로 채울것
            for(int index = 0; index < 10; index++)
            {
                Text FristTry = ScoreTable.transform.GetChild(index).GetChild(1).GetComponent<Text>();
                Text SecondTry = ScoreTable.transform.GetChild(index).GetChild(2).GetComponent<Text>();
                
                FristTry.text = frames[index].FirstTryStr;
                SecondTry.text = frames[index].SecondTryStr;

                if(index == 9)
                {
                    Text ThridTry = ScoreTable.transform.GetChild(index).GetChild(4).GetComponent<Text>();
                    ThridTry.text = frames[index].ThirdTryStr;
                }

                Text Scroe = ScoreTable.transform.GetChild(index).GetChild(3).GetComponent<Text>();
                Scroe.text = frames[index].ScoreStr;
            }
        }

        public void StartMessage(string message)
        {
            MessageBox.GetComponent<Text>().color = Color.black;
            MessageBox.GetComponent<Text>().text = "++"+message+"++";
        }
        
    }
}
