using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject fpschar;
    public float range = 500;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            shoot();
            // gun RECOIL 
            anim.SetTrigger("recoil");


        }
        else
        {

        }
    }

    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpschar.transform.position, fpschar.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "enemy")
            {
                characterScript enemy = hit.transform.GetComponent<characterScript>();
                enemy.die();
            }
        }

    }
}
