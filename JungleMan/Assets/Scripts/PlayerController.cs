using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
    public float maxspeed;
	public Text countText;
	public Text winText;
    public float scrollSpeed = -1.5f;
	private int count;
    public static PlayerController instance;
    public float jumpForce;
    public bool feetContact;
    public bool bodyContact;
    public bool canJumpVar;
    int FloorLayer;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
	{
        rb2d = GetComponent<Rigidbody2D>();
		count = 0;
		winText.text = "";
		SetCountText ();
	}

    void Update()
    {
        float MoveHor = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(MoveHor * speed, 0);
        movement = movement * Time.deltaTime;

        if (canJump())
        {
            rb2d.AddForce(movement);
            if (rb2d.velocity.x > maxspeed)
            {
                rb2d.velocity = new Vector2(maxspeed, rb2d.velocity.y);
            }
            if (rb2d.velocity.x < -maxspeed)
            {
                rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
            }
            if (Input.GetKeyDown(KeyCode.Space) && canJump())
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Gold: " +  count.ToString ();
		if (count >= 7)
        {
            winText.text = "You win!";
        }	
	}

    bool canJump()
    {
        if (feetContact)
        {
            canJumpVar = true;
            return true;
        }
        canJumpVar = false;
        return false; 
    }
}
