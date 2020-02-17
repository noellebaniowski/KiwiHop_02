using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    //Noelle Baniowski
    //Two forwards slashes allow you to write notes which Unity does not read as code
    //The top of the script is generally where we place variables which we manipulate later
    //Variables have 3 parts, 
    //Public vs Private
    //The type of variable
    //The name we give for the variable

    //NUMBER VARIABLES
    //The two most common types are floats and ints
    public float number; //floats are floating point numbers or decimal numbers 1.25 is a float
    public int wholenumber; //ints are whole numbers 1, 2, 3, etc. no decimals allowed
    private float myhiddennumber; //private variables are not shown in the Unity inspector

    //BOOLS
    public bool yesorno; //A bool is a true or false statement, a binary, think of it like a
    //light switch, its either on or off, no in between

    //OTHER COMMON VARIABLES
    public GameObject myGameObject; //We can reference any object in our scene. every item
    //in the hierarchy is considered a gameobject
    public Notes mynotescript; //We can reference scripts as well as long as they are public
    public Rigidbody2D myRB2D; //We use rigidbodies to make gameobjects affected by unity's
    //physics engine 2D and 3D are independent
    public BoxCollider2D myboxcollider; //We can reference colliders of all types as swell
    public CircleCollider2D mycirclecollider; //If you make a 3D game just drop the 2D
    //pretty much any component that we can add to a gameobject can be referenced as a variable
    
    // Start is called before the first frame update
    void Start()
    {
        //ENABLED VS SET ACTIVE
        //components in the inispector can be enabled and disabled
        myboxcollider.enabled = true; //small check boxoes inside the gameobject
        myGameObject.SetActive(true); //the whole game object
        //Anything that we want to happen when the game starts goes here. it is only called once
        //when the game first starts up
        //if we don't want to drag and drop all variables into the inspector there are a few
        //commands that will do this for us automatically but they do take processing power
        //generally we only do this when we have to such as when we spawn the player
        myRB2D = GetComponent<Rigidbody2D>(); //This will get the rigidbody but only if its
        //on the same object as our script
        myRB2D = myGameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //This allows us to get our rigid body from another gameobject with the tag player
        myRB2D = myGameObject.FindObjectofType<Rigidbody2D>();
        //The above will only work for one rigidbody 2D and will grab the first one it can find
        //Generally we only use FindObjectofType when there is only a singular object of that type

        //Another thing we look at in START is a gameobjects Transform
        //A Transform is position, rotation, and scale of a gameobject

        transform.position = new Vector2(0, 0); //This is our location on the x and y axis
        transform.position = new Vector3(0, 0, 0); //This is x, y, z in 3D space
        //X is horizontal axis (walking)
        //Y is vertical axis (Jumping)
        //Z is dpeth (also walking if in a 3D space)
        transform.position = new Vector2(24, 128); //This line would teleport the game object
        //24 units horizontally and 128 units vertically

        transform.localScale = new Vector2(1, 1); //This is standard scale (0, 0) would be invisible
        //Rotation is a bit different, we have to use Quaternion and EULER (oiler)
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.identity; //This is the current rotation of the object

    }

    // Update is called once per frame
    void Update()
    {
        //Inside update, we call things that we want to change in real time as the player is playing
        //Player controls, enemy controls, points, health, etc all happen inside the update loop

        //IF STATEMENTS
        // if (something)
        // {
        //      then we do this
        // }

        if(yesorno == true)
        {
            //We say yes
            //The player lives
        }

        if(yesorno == false)
        {
            //We say no
            //The player dies
        }
        //This is basically how  bool works. We check the value and execute different commands
        //Depending on the value of the bool (true or false) (check or unchecked)
        //The double equal sign is needed for this to work as it checks to see IF the statement
        //is true or false "yesorno = true" automatically sets the bool to be true
        if( number >= 10)
        {
            //We do something
            if (Input.GetAxis("Horizontal") > 0)
            {
                //Move the player
                myRB2D.velocity = new Vector2(2, myRB2D.velocity.y); //We dont alter the y here
                //so that the jump doesnt get affected
            }
        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            //stop the player
            myRB2D.velocity = new Vector2(0, myRB2D.velocity.y);
        }

        //RIGID BODY PROPERTIES
        myRB2D.gravityScale = 0; //This turns off gravity
        myRB2D.simulated = false; //This makes you invincible (Thimgs can pass through you)
        myRB2D.isKinematic = true; //When this is true, the rigidbody only moves when the code
        //tells it to
        myRB2D.isKinematic = false; //Gravity will affect me when this is false

        //if ELSE STATEMENTS
        //Normally if statements are read one after the other which can cause weird behavior
        //we can use if else statements to stop the if statements

        if (yesorno == true)
        {
            //we say yes
            //the player lives
        }

        else if (yesorno == false)
        {
            //this only happens if the above if sttement is not true
            //we say no
            //the player dies
        }
    }
    private void FixedUpdate()
    {
        //regular update is dependent of the frame of the game. This means newer devices
        //will play the game faster and older devices will play the game slower which is not
        //ideal. FIXED UPDATE updates at a set interval which meansa all machines run the code 
        //at the same speed. we put physics code inside fixed update
    }

    //TRIGGER STATEMENTS

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this statement is used generally when we want the player to trigger something
        //it could be an enemy, an animation, music really anything we want
        //an event is triggered when the player passes through a collider marked as trigger
        if(collision.tag == "Player")
        {
            //we execute the event
        }

        //normally we check to see the tag of the collision so only the player can trigger
        //the event
        //for the event to trigger one object needs to have a rigidbody (either the player or
        //the object that has the trigger collider on it
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //same as trigger except we dont pass through the collider and the collider is not
        //marked as a trigger. This will trigger events when we bump into a collider
    }
}
