using UnityEngine;
using Assets.Scripts;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private BowlingGame bowlingGame;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }
 
    void Start()
    {
        GUIBowlingPrintAPI gUIBowlingPrintAPI = GameObject.Find("ScoreBoard").GetComponent<GUIBowlingPrintAPI>();
        bowlingGame = new BowlingGame(gUIBowlingPrintAPI);
    }

    public void InputPins(int count)
    {
        bowlingGame.KnockedDownPins(count);
    }
}
