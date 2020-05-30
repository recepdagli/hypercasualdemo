using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    public Texture btnTexture;
    // Start is called before the first frame update
    public float hiz;
	public Rigidbody rb;
    public GameObject duvar;
    public Collider duvar_rb;

    public float olcek;
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        hiz = 5;
        rb = GetComponent<Rigidbody>();
        olcek = Screen.width/20f;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ExampleCoroutine(int scene_number)//başka bölüme geçmeden (veya yeniden başlamadan) önce 3 sn bekle
    {
        Debug.Log("" + Time.time);

        yield return new WaitForSeconds(3);

        Debug.Log("" + Time.time);
        SceneManager.LoadScene("scene"+scene_number);
    }
    void gameover(bool istrap)
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        foreach(GameObject go in allObjects)
        {
            if(go.name.IndexOf("form") > 0)
            {
                go.GetComponent<Rigidbody>().useGravity = false;
                go.GetComponent<Rigidbody>().isKinematic = false;
                go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
        if(istrap)//tuzaksa seviyeyi yeniden başlat
        {
            StartCoroutine(ExampleCoroutine(int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1))));
        }
        else//oyunun bittiği yer
        {
            //bu sahne hariç başka bir sahne aç
            int scene_number = int.Parse(SceneManager.GetActiveScene().name.Substring(SceneManager.GetActiveScene().name.Length - 1));
            int rnd = scene_number;
            while(scene_number == rnd)
            {
                rnd = Random.Range(1,5);
            }
            StartCoroutine(ExampleCoroutine(rnd));
        }  
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "black_hole")
        {
            Debug.Log(col.gameObject.name);
            gameover(false);
        }
        if(col.gameObject.name == "trap")
        {
            Debug.Log(col.gameObject.name);
            gameover(true);
        }
        if(col.gameObject.name.IndexOf("cesme")>0)
        {
            Debug.Log(col.gameObject.name);
            //mavi ve sarı renklerinin karışması sonucu topu yeşil yap(son sahnede)
            if((transform.GetComponent<Renderer>().material.color.ToString() == "RGBA(0.962, 1.000, 0.000, 1.000)" && col.transform.GetComponent<Renderer>().material.color.ToString() == "RGBA(0.033, 0.896, 1.000, 1.000)") || (col.transform.GetComponent<Renderer>().material.color.ToString() == "RGBA(0.962, 1.000, 0.000, 1.000)" && transform.GetComponent<Renderer>().material.color.ToString() == "RGBA(0.033, 0.896, 1.000, 1.000)"))//eğer sarıysa
            {
                transform.GetComponent<Renderer>().material.color = new Color(0.010f, 1.000f, 0.000f, 1.000f);
            }
            else
            {
                transform.GetComponent<Renderer>().material.color = col.transform.GetComponent<Renderer>().material.color;
            }

        }
    }
    private void OnGUI() {
        if (GUI.Button(new Rect(olcek*2f, Screen.height-(olcek*2) , olcek, olcek), btnTexture))//s
            rb.velocity = Vector3.back*hiz;
        if (GUI.Button(new Rect(olcek*2f, Screen.height-(olcek*4) , olcek, olcek), btnTexture))//w
            rb.velocity = Vector3.forward *hiz;
        if (GUI.Button(new Rect(olcek*3f, Screen.height-(olcek*3) , olcek, olcek), btnTexture))//d
            rb.velocity = Vector3.right*hiz;
        if (GUI.Button(new Rect(olcek, Screen.height-(olcek*3) , olcek, olcek), btnTexture))//a
            rb.velocity = Vector3.left*hiz;
    }
}
