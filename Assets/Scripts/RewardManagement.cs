using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManagement : MonoBehaviour
{
    public Text AxeDisplay;
    public Text CoinsDisplay;
    private int axes = 0;
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        AxeDisplay.text = "Axes: "+axes.ToString();
	  CoinsDisplay.text = "Coins: "+coins.ToString();	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //add in logic to make start button reappear after?
    public void selectAxeReward(){
	axes+=1;
	AxeDisplay.text = "Axes: "+axes.ToString();
    }
    public void selectCoinReward(){
	coins+=10;
	CoinsDisplay.text = "Coins: "+coins.ToString();
    }
    public void chopfriendtree(){
	//implement logic for reduce axes and photon tie in
	Debug.Log("This is working");
    }
}
