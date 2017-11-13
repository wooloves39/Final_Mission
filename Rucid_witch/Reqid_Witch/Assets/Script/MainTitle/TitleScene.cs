using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScene : MonoBehaviour
{
    public GameObject Title;
    Color object_Color;
    float opening_time = 0.0f;
    float opening_color = 0.0f;
    float Screen_width;
    float Screen_height;
    // Use this for initialization
    private void Awake()
    {
        // 스크린 해상도 맞추기
        //실제 플레이에선 3번째 인자 true
        Screen.SetResolution(Screen.width, Screen.width *( 9 / 5), false);
        Screen_width = Screen.width;
        Screen_height = Screen_width*(9/5);

    }
    void Start()
    {
        object_Color = Title.transform.GetComponent<MeshRenderer>().material.color;

        Vector3 scale=Title.transform.localScale;
        Title.gameObject.transform.localScale=new Vector3(scale.x*Screen_width*25/48*0.005f, scale.y*Screen_height * 25/48*0.005f,1);
        Title.transform.GetComponent<MeshRenderer>().material.color = new Color(object_Color.r, object_Color.g, object_Color.b, opening_color);
    }

    // Update is called once per frame
    void Update()
    {
        opening_time += Time.deltaTime;
        if (opening_time < 3.0f)
        {

            opening_color = (opening_time / 3);
        }
        else
            opening_color = 1;
        if (Title.gameObject)
            Title.transform.GetComponent<MeshRenderer>().material.color = new Color(object_Color.r, object_Color.g, object_Color.b, opening_color);
        if (opening_time > 5.0f)
        {
            Destroy(Title.gameObject);
            //SceneManager.LoadScene("next Scene");
        }
    }
}
