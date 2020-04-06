using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{

    //these are animators for 2 UI components that contain both images, text, and buttons
    public Animator simplenav;
    public Animator inventoryholder;
    public bool MenuOpen;

    //these are needed to enable the party hat and have it make a change to the player
    public PlayerController pc;

    public int PartyHat;
    public GameObject inventoryHat; //button in inventory
    public bool wearHat; //bool that tells us if we ae wearing the hat
    public GameObject Birthdayhat; //the actual hat object on the birds head

    //this keeps track of the players gold
    public int goldCount;
    public Text goldText;

    //All items in my shop are buttons so that when i click them they can do something
    public Button ShopHat;
    public Button ShopSlime;
    public Button ShopSkelly;
    //if we own something we might not want to purchase it again (COULD USE THIS FOR SKINS)
    public bool ownHat;
    public bool ownSlime;
    public bool ownSkelly;

    // Start is called before the first frame update
    void Start()
    {
        //goldCount = PlayerPrefs.GetInt ("Gold"); //if you want to save gold across play sessions
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.SetInt("Gold", goldCount); //if you want to save gold across play sessions

        goldText.text = "Gold:" + goldCount;
        PartyHat = PlayerPrefs.GetInt("PartyHat");

        if(PartyHat == 1)
        {
            inventoryHat.SetActive(true); //turns on the hat button in our inventory
        }

        if (wearHat == true)
        {
            Birthdayhat.SetActive(true); // lets us see the hat on the bird
        }

        if(wearHat == false) // this turns off the hat 
        {
            Birthdayhat.SetActive(false);
        }

        if(goldCount >= 1 && ownHat == false) // if we have enough gold and didnt buy the hat yet
        {
            ShopHat.interactable = true; //the hat button is now clickable in the shop
        }
    }

    public void OpenNav()
    {
        if(MenuOpen == false)
        {
            simplenav.SetBool("Open", true);
            Time.timeScale = 0;
            MenuOpen = true;
        }

        else if (MenuOpen == true)
        {
            simplenav.SetBool("Open", false);
            Time.timeScale = 1;
            MenuOpen = false;
        }
    }

    public void CloseNav()
    {
        simplenav.SetBool("Open", false);
        Time.timeScale = 1;
        MenuOpen = false;
    }

    public void OpenInv()
    {
        inventoryholder.SetBool("Open", true);
    }

    public void CloseInv()
    {
        inventoryholder.SetBool("Open", true);
    }

    public void BuyHat()
    {
        goldCount -= 1;
        PlayerPrefs.SetInt("PartyHat", 1);
        ShopHat.interactable = false;
        ownHat = true;
    }

    public void PutOnHat()
    {
        wearHat = true;
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("PartyHat", 0);
        inventoryHat.SetActive(false);
        wearHat = false;
    }
}
