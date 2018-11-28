using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    
    public bool haveKey = false;

    public float maxSpeed = 10f;
    public bool facingRight = true;
    public float jumpForce = 700f;
    public float jumpCooldownFactor = 0.5f;
    public float shootCooldownFactor = 0.2f;
    public GameObject bullet;

    private bool grounded = false;
    private bool killed = false;

    private float shootCooldown = 0;
    private float jumpCooldown = 0;
    private Rigidbody2D playerRigitbody;


    // Use this for initialization
    void Start () {
        playerRigitbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (grounded && (Input.GetKey("up") || Input.GetKey("w")) && jumpCooldown <= 0)
        {
            playerRigitbody.AddForce(new Vector2(0, jumpForce));
            jumpCooldown = jumpCooldownFactor;
            grounded = false;
        }
        if (Input.GetKey(KeyCode.Space) && shootCooldown <= 0)
        {
            Fire();
            shootCooldown = shootCooldownFactor;
        }
        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        if (killed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        playerRigitbody.velocity = new Vector2(move * maxSpeed, playerRigitbody.velocity.y);
        if (move > 0 && !facingRight)
        {
            Flip(this.gameObject);
        }
        else if (move < 0 && facingRight)
        {
            Flip(this.gameObject);
        }
    }

    private void Flip(GameObject gameObject)
    {
        if (gameObject.CompareTag("Player"))
        {
            facingRight = !facingRight;
        }        
        Vector3 theScale = gameObject.transform.localScale;
        theScale.x *= -1;
        gameObject.transform.localScale = theScale;
    }

    private void Fire()
    {
        if (facingRight)
        {
            GameObject bulletClone = Instantiate(bullet, transform.GetChild(0).position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 0));
        }
        else
        {
            GameObject bulletClone = Instantiate(bullet, transform.GetChild(0).position, transform.rotation);
            Flip(bulletClone);
            bulletClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f, 0));
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            transform.parent = collision.transform;

        }
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Threat"))
        {
            killed = true;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            haveKey = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.parent = null;
        }
    }
}
