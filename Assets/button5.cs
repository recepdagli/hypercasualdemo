using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button5 : MonoBehaviour
{
    private bool moved_red = false;
    private bool moved_blue = false;
    private bool moved_yellow = false;
    private bool moved_green = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision col)
    {
        if(transform.GetComponent<Renderer>().material.color.ToString() == col.transform.GetComponent<Renderer>().material.color.ToString())
        {
            Debug.Log(this.name);
            if(this.name == "cube_btn_red" && moved_red == false)
            {
                move.moveobject_down("wall_red");
                moved_red = true;
            }
            if(this.name == "cube_btn_blue" && moved_blue == false)
            {
                move.moveobject_right("wall_blue");
                moved_blue = true;
            }
            if(this.name == "cube_btn_yellow" && moved_yellow == false)
            {
                move.moveobject_down("wall_yellow");
                moved_yellow = true;
            }
            if(this.name == "cube_btn_green" && moved_green == false)
            {
                move.moveobject_down("wall_green");
                moved_green = true;
            }
        }
    }
}


