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

public float push_cooldown = 1.5f;
private float last_used;
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
            if (Input.GetAxisRaw("Vertical") == -1f && Time.time > last_used + push_cooldown)
            {

                if (UnityEngine.Vector3.Distance(transform.position, movePointDown.position) <= .05f)
                {
                    movePointDown.position += new UnityEngine.Vector3(0f, -1f, 0f);
                }

                last_used = Time.time;
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
            if (Input.GetAxisRaw("Vertical") == 1f && Time.time > last_used + push_cooldown)
            {

                if (UnityEngine.Vector3.Distance(transform.position, movePointUp.position) <= .05f)
                {
                    movePointUp.position += new UnityEngine.Vector3(0f, 1f, 0f);
                }

                last_used = Time.time;
            }
        }
    }

    if (righthit.collider != null)
    {
        if (righthit.collider.gameObject.tag == "Player")
        {
            Debug.DrawRay(gameObject.transform.position, UnityEngine.Vector3.right * 2f, Color.green, 1);
            Debug.Log("Hit!");
        }
    }

    if (lefthit.collider != null)
    {
        if (lefthit.collider.gameObject.tag == "Player")
        {
            Debug.DrawRay(gameObject.transform.position, -UnityEngine.Vector3.right * 2f, Color.green, 1);
            Debug.Log("Hit!");
        }
    }

   }


}
