using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void moveobject_left(string objname)
    {
        GameObject obj = GameObject.Find(objname);
        var obj_rb = obj.GetComponent<Rigidbody>();
        obj.transform.DOMoveZ(obj.transform.position.z-obj.transform.localScale.x,0.7f);
    }
    public static void moveobject_right(string objname)
    {
        
        GameObject obj = GameObject.Find(objname);
        var obj_rb = obj.GetComponent<Rigidbody>();
        obj.transform.DOMoveZ(obj.transform.position.z+obj.transform.localScale.x,0.7f);
    }
    public static void moveobject_up(string objname)
    {
        GameObject obj = GameObject.Find(objname);
        var obj_rb = obj.GetComponent<Rigidbody>();
        obj.transform.DOMoveX(obj.transform.position.x-obj.transform.localScale.x,0.7f);
    }
    public static void moveobject_down(string objname)
    {
        GameObject obj = GameObject.Find(objname);
        var obj_rb = obj.GetComponent<Rigidbody>();
        obj.transform.DOMoveX(obj.transform.position.x+obj.transform.localScale.x,0.7f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
