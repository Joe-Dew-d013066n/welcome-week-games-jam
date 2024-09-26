using System;
using System.Numerics;
using Mono.Cecil.Cil;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class pushing : MonoBehaviour
{
    public GameObject player;
    public float walk_speed = 5f;
    public Transform movePointDown;
    public Transform movePointUp;
    public Transform movePointRight;
    public Transform movePointLeft;

    public float up_push_cooldown = 1.5f;
    public float down_push_cooldown = 1.5f;
    public float left_push_cooldown = 1.5f;
    public float right_push_cooldown = 1.5f;
    private float up_last_used;
    private float down_last_used;
    private float right_last_used;
    private float left_last_used;
    void Start()
   {
    movePointDown.parent = null;
   }

   void Update(){
    RaycastHit2D uphit = Physics2D.Raycast(gameObject.transform.position, UnityEngine.Vector2.up * 2f, 1, LayerMask.GetMask("Player"));
    RaycastHit2D downhit = Physics2D.Raycast(gameObject.transform.position, -UnityEngine.Vector2.up * 2f, 1, LayerMask.GetMask("Player"));
    RaycastHit2D righthit = Physics2D.Raycast(gameObject.transform.position, UnityEngine.Vector2.right * 2f, 1, LayerMask.GetMask("Player"));
    RaycastHit2D lefthit = Physics2D.Raycast(gameObject.transform.position, -UnityEngine.Vector2.right * 2f, 1, LayerMask.GetMask("Player"));
    Debug.DrawRay(gameObject.transform.position, UnityEngine.Vector3.up * 2f, Color.white, 1);
    Debug.DrawRay(gameObject.transform.position, -UnityEngine.Vector3.up * 2f, Color.white, 1);
    Debug.DrawRay(gameObject.transform.position, UnityEngine.Vector3.right * 2f, Color.white, 1);
    Debug.DrawRay(gameObject.transform.position, -UnityEngine.Vector3.right * 2f, Color.white, 1);

    if (uphit.collider != null)
    {
        if (uphit.collider.gameObject.tag == "Player")
        {
            Debug.DrawRay(gameObject.transform.position, UnityEngine.Vector3.up * 2f, Color.green, 1);
            Debug.Log("Hit!");

            UnityEngine.Vector3 original_pos = transform.position;
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, movePointDown.position, walk_speed * Time.deltaTime);
            if (Input.GetAxisRaw("Vertical") == -1f && Time.time > down_last_used + down_push_cooldown)
            {

                if (UnityEngine.Vector3.Distance(transform.position, movePointDown.position) <= .05f)
                {
                    movePointDown.position += new UnityEngine.Vector3(0f, -1f, 0f);
                }

                down_last_used = Time.time;
            }   
        }
    }

    if (downhit.collider != null)
    {
        if (downhit.collider.gameObject.tag == "Player")
        {
            Debug.DrawRay(gameObject.transform.position, -UnityEngine.Vector3.up * 2f, Color.green, 1);
            Debug.Log("Hit!");

            UnityEngine.Vector3 original_pos = transform.position;
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, movePointUp.position, walk_speed * Time.deltaTime);
            if (Input.GetAxisRaw("Vertical") == 1f && Time.time > up_last_used + up_push_cooldown)
            {

                if (UnityEngine.Vector3.Distance(transform.position, movePointUp.position) <= .05f)
                {
                    movePointUp.position += new UnityEngine.Vector3(0f, 1f, 0f);
                }

                up_last_used = Time.time;
            }
        }
    }

    if (righthit.collider != null)
    {
        if (righthit.collider.gameObject.tag == "Player")
        {
            Debug.DrawRay(gameObject.transform.position, UnityEngine.Vector3.right * 2f, Color.green, 1);
            Debug.Log("Hit!");

            UnityEngine.Vector3 original_pos = transform.position;
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, movePointLeft.position, walk_speed * Time.deltaTime);
            if (Input.GetAxisRaw("Horizontal") == -1f && Time.time > left_last_used + left_push_cooldown)
            {

                if (UnityEngine.Vector3.Distance(transform.position, movePointLeft.position) <= .05f)
                {
                    movePointLeft.position += new UnityEngine.Vector3(-1f, 0f, 0f);
                }

                left_last_used = Time.time;
            }
        }
    }

    if (lefthit.collider != null)
    {
        if (lefthit.collider.gameObject.tag == "Player")
        {
            Debug.DrawRay(gameObject.transform.position, -UnityEngine.Vector3.right * 2f, Color.green, 1);
            Debug.Log("Hit!");

            UnityEngine.Vector3 original_pos = transform.position;
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, movePointRight.position, walk_speed * Time.deltaTime);
            if (Input.GetAxisRaw("Horizontal") == 1f && Time.time > right_last_used + right_push_cooldown)
            {

                if (UnityEngine.Vector3.Distance(transform.position, movePointRight.position) <= .05f)
                {
                    movePointRight.position += new UnityEngine.Vector3(1f, 0f, 0f);
                }

                right_last_used = Time.time;
            }
        }
    }

    if (uphit.collider == null && Time.time > down_last_used + down_push_cooldown)
        {
            movePointDown.position = transform.position;
        }
    if (downhit.collider == null && Time.time > up_last_used + up_push_cooldown)
        {
            movePointUp.position = transform.position;
        }
    if (righthit.collider == null && Time.time > left_last_used + left_push_cooldown)
        {
            movePointLeft.position = transform.position;
        }
    if (lefthit.collider == null && Time.time > right_last_used + right_push_cooldown)
        {
            movePointRight.position = transform.position;
        }

   }


}
