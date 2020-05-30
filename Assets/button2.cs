using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2 : MonoBehaviour
{
    // Start is called before the first frame update
    private bool moved_red = false;
    private bool moved_blue = false;
    private bool moved_yellow = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision col)
    {
        if(transform.GetComponent<Renderer>().material.color == col.transform.GetComponent<Renderer>().material.color)
        {
            Debug.Log(this.name);
            if(this.name == "cube_btn_red" && moved_red == false)
            {
                move.moveobject_up("wall_red");
                moved_red = true;
            }
            if(this.name == "cube_btn_blue" && moved_blue == false)
            {
                move.moveobject_down("wall_blue");
                moved_blue = true;
            }
            if(this.name == "cube_btn_yellow" && moved_yellow == false)
            {
                move.moveobject_up("wall_yellow");
                moved_blue = true;
            }
        }
    }
}
