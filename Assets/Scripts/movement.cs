using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform movePoint;
    public float walk_speed = 5f;
    private Rigidbody2D rb2d;
    

    public Animator anim;
 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, movePoint.position, walk_speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f )
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f )
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }
        anim.SetBool("walkup", false);
        anim.SetBool("walkdown", false);
        anim.SetBool("walkleft", false);
        anim.SetBool("walkright", false);

        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            anim.SetBool("walkright", true);
        }

        if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            anim.SetBool("walkleft", true);
        }

        if (Input.GetAxisRaw("Vertical") == 1f)
        {
            anim.SetBool("walkup", true);
        }

        if (Input.GetAxisRaw("Vertical") == -1f)
        {
            anim.SetBool("walkdown", true);
        }

    }
}
