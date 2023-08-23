using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        createClue();
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialog();
    }

    public void searchDialog()
    {
        dialog = "Hi! Can you help me find my " + collectibles[clue] + "?";
        switch (clue)
        {
            case 0:
                dialog = "Oh no, I've lost my movie " + collectibles[clue] + ". Can you help me find it?";
                break;
            case 1:
                dialog = "Oh no, I've lost my colourful " + collectibles[clue] + ". Can you help me find it??";
                break;
            case 2:
                dialog = "Oh no, I've lost my dreadful " + collectibles[clue] + ". Can you help me find it???";
                break;
            case 3:
                dialog = "Oh no, I've lost my worn out " + collectibles[clue] + ". Can you help me find it????";
                break;
            case 4:
                dialog = "Oh no, I've lost my smoking " + collectibles[clue] + ". Can you help me find it?????";
                break;
            case 5:
                dialog = "Oh no, I've lost my house keys " + collectibles[clue] + ". Can you help me find it??????";
                break;
            case 6:
                dialog = "Oh no, I've lost my tank of " + collectibles[clue] + ". Can you help me find it???????";
                break;
            case 7:
                dialog = "Oh no, I've lost my definetly small " + collectibles[clue] + ". Can you help me find it????????";
                break;
            case 8:
                dialog = "Oh no, I've lost my loud " + collectibles[clue] + ". Can you help me find it?????????";
                break;
            case 9:
                dialog = "Oh no, I've lost my magic " + collectibles[clue] + ". Can you help me find it??????????";
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialog, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialog = "You found my " + collectibles[clue] + " Hooray!";
            end = true;
        }
        else
        {
            dialog = "Thats not my " + collectibles[clue] + " dummy ￣へ￣";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

}
