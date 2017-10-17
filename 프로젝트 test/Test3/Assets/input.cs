using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public GameObject skillcontroller;
    private float timer = 0;
    private GameObject skill;
  
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //마우스 클릭시
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            skill= Instantiate(skillcontroller, pos, Quaternion.identity, this.transform);
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            skill.GetComponent<skilcontroller>().skillon();
            Destroy(skill.gameObject);
        }
        
        if (Input.GetMouseButton(0) && timer > 0.2f)
        {
            timer = 0;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = Physics.SphereCastAll(ray, 1.0f);
            for (int i = 0; i < hit.Length; ++i)
            {
                if (!hit[i].collider.gameObject.GetComponent<boxcheck>().Getcheck())
                {
                   Debug.Log("터치터치팡팡");
                    skill.GetComponent<skilcontroller>().rec_in(hit[i].collider.GetComponent<boxcheck>().Get_index(), hit[i].collider.gameObject);
                    //hit[i].collider.gameObject.GetComponent<boxcheck>().touchon();
                    //for (int j = 0; j < this.gameObject.transform.childCount; ++j)
                    //{
                    //    if (hit[i].collider.gameObject.GetComponent<boxcheck>().Get_index() == this.gameObject.transform.GetChild(j).gameObject.GetComponent<boxcheck>().Get_index())
                    //    {
                    //        if (!this.gameObject.transform.GetChild(j).gameObject.GetComponent<boxcheck>().Getcheck())
                    //        {
                    //            this.gameObject.transform.GetChild(j).gameObject.GetComponent<boxcheck>().touchdown();
                    //        }
                    //    }
                    //}
                }
            }
        }
    }
}
