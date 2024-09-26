using System.IO.Compression;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    void Start()
    {
    }

    void Update()
    {
        float speedx = Input.GetAxisRaw("Horizontal");
        float speedy = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Horizontal") != 0f && Input.GetAxisRaw("Vertical") != 0f)
        {
            
        
            if (Input.GetAxisRaw("Vertical") == 1f)
            {
                anim.SetBool("idle", false);
                anim.SetBool("walkup", true);
            }
            if (Input.GetAxisRaw("Vertical") == -1f)
            {
                anim.SetBool("idle", false);
                anim.SetBool("walkdown", true);
            }
            if (Input.GetAxisRaw("Horizontal") == 1f)
            {
                anim.SetBool("idle", false);
                anim.SetBool("walkright", true);
            }
            if (Input.GetAxisRaw("Horizontal") == -1f)
            {
                anim.SetBool("idle", false);
                anim.SetBool("walkleft", true);
            }
        }
        else
        {
            anim.SetBool("walkup", false);
            anim.SetBool("walkdown", false);
            anim.SetBool("walkright", false);
            anim.SetBool("walkleft", false);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("walkup") || anim.GetCurrentAnimatorStateInfo(0).IsName("walkdown") || anim.GetCurrentAnimatorStateInfo(0).IsName("walkleft") || anim.GetCurrentAnimatorStateInfo(0).IsName("walkright"))
            {
                anim.SetBool("idle", true);
            }
        }
    }  
}
