using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Control : MonoBehaviour
{
    public Animator myAnim;
    public GameObject player, weap1, weap2, weap3;
    Rigidbody2D myRig;
    int playHealth = 5;
    int playLuck = 1;
    int playAtk = 3;
    int playDef = 3;
    public int playGold;
    bool faceLeft, faceRight;
    bool weapDes;
    public GameObject spawn;
    public float playSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myRig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (myRig == null || myAnim == null)
        {
            throw new System.Exception("No Rigid Body/Animator on Game Object");
        }
        faceRight = true;
        DontDestroyOnLoad(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Weapon") && !weapDes)
        {
            Destroy(other.gameObject);
            weapDes = true;
            Debug.Log("Weapon Picked Up");
        }

        if (other.gameObject.CompareTag("Enemy") && faceLeft == true) 
        {
            myAnim.SetTrigger("DirHit(Left)");
        }

        if (other.gameObject.CompareTag("Enemy") && faceRight == true)
        {
            myAnim.SetTrigger("DirHit(Right)");
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            playGold += 1;   
            Destroy(other.gameObject);
            Debug.Log("Gold PickUp");
        }

        /*
        if (other.gameObject.CompareTag("Potion") && (faceLeft == true || faceRight == true))
        {
            Destroy(other.gameObject);
            Debug.Log("Potion PickUp");
        }
        
        if (other.gameObject.CompareTag("Gear") && (faceLeft == true || faceRight == true))
        {
            Destroy(other.gameObject);
            Debug.Log("Gear Pickup");
        }
        */
        if (other.gameObject.CompareTag("Ladder"))
        {
            int curScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(curScene + 1);
            player.gameObject.transform.position = spawn.gameObject.transform.position;
            player.gameObject.transform.position = new Vector3(spawn.gameObject.transform.position.x, spawn.gameObject.transform.position.y);
        }

        if (other.gameObject.CompareTag("DoorRight"))
        {
            player.transform.position = new Vector3(player.transform.position.x + 30, player.transform.position.y);
            Debug.Log("Next Room(Right)");
        }

        if (other.gameObject.CompareTag("DoorDown"))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 24);
            Debug.Log("Next Room(Down)");
        }

        if (other.gameObject.CompareTag("DoorLeft"))
        {
            player.transform.position = new Vector3(player.transform.position.x - 30, player.transform.position.y);
            Debug.Log("Next Room(Left)");
        }

        if (other.gameObject.CompareTag("DoorUp"))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 24);
            Debug.Log("Next Room(Up)");
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        if (weapDes == true)
        {
            Destroy(weap1);
            Destroy(weap2);
            Destroy(weap3);
            //Debug.Log("Weapons Destroyed");
        }


        if (playHealth <= 0 && faceLeft == true)
        {
            myAnim.SetTrigger("DirDeath(Left)");
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }

        else if (playHealth <= 0 && faceRight == true)
        {
            myAnim.SetTrigger("DirDeath(Right)");
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }




        if (Input.GetAxisRaw("Vertical") < 0)
        {
            //myAnim.SetTrigger("DirWalk(Left)");
            myRig.velocity = new Vector2(0, -playSpeed);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            myRig.velocity = new Vector2(0, 0);
        }





        if (Input.GetAxisRaw("Vertical") > 0)
        {
            myAnim.SetTrigger("DirWalk(Right)");
            myRig.velocity = new Vector2(0, playSpeed);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            myRig.velocity = new Vector2(0, 0);
        }





        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //left
            faceRight = false;
            faceLeft = true;
            myAnim.SetTrigger("DirWalk(Left)");
            myRig.velocity = new Vector2(-playSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            myAnim.SetTrigger("Idle(Left)");
            myRig.velocity = new Vector2(0, 0);
        }





        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //right
            faceLeft = false;
            faceRight = true;
            myAnim.SetTrigger("DirWalk(Right)");
            myRig.velocity = new Vector2(playSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //myAnim.SetTrigger("");
            myRig.velocity = new Vector2(0, 0);
        }




        if (Input.GetKeyDown(KeyCode.Space) && faceLeft == true)
        {
            //attack left
            myAnim.SetTrigger("DirAtk(Left)");
            Debug.Log("Attack Left");
        }
 
        if (Input.GetKeyDown(KeyCode.Space) && faceRight == true)
        {
            //attack right
            myAnim.SetTrigger("DirAtk(Right)");
            Debug.Log("Attack Right");
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space) && faceLeft == true && myRig.velocity.x == 0 && myRig.velocity.y == 0)
        {
            //attack left
            myAnim.SetTrigger("DirIdAtk(Left)");
            Debug.Log("Attack Left");
        }

        if (Input.GetKeyDown(KeyCode.Space) && faceRight == true && myRig.velocity.x == 0 && myRig.velocity.y == 0)
        {
            //attack right
            myAnim.SetTrigger("DirIdAtk(Right)");
            Debug.Log("Attack Right");
        }
        */





    }

    public void RoomChange(int p)
    {
        switch (p)
        {
            case 0:

                break;
            case 1:

                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;

            case 5:

                break;

            case 6:

                break;

            case 7:

                break;

            case 8:

                break;

            case 9:

                break;
        }
    }
}