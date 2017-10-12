using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour {
    public GameObject box;
    private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        //마우스 클릭시
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            GameObject boxes;
            boxes=Instantiate(box, pos, Quaternion.identity,this.gameObject.transform);
            boxes.gameObject.GetComponent<boxcheck>().Set_index(1);
            pos.x += 4;
            Instantiate(box, pos, Quaternion.identity, this.gameObject.transform);
            boxes.gameObject.GetComponent<boxcheck>().Set_index(1);
            pos.x -= 8;
            Instantiate(box, pos, Quaternion.identity, this.gameObject.transform);
            boxes.gameObject.GetComponent<boxcheck>().Set_index(1);
            pos.x +=4;
            pos.y += 4;
            Instantiate(box, pos, Quaternion.identity, this.gameObject.transform);
            boxes.gameObject.GetComponent<boxcheck>().Set_index(1);
        }
        if (Input.GetMouseButtonUp(0))
        {
            for(int i = 0; i < this.gameObject.transform.childCount; ++i)
            {
                Destroy(this.gameObject.transform.GetChild(i).gameObject);
            }
        }
        if (Input.GetMouseButton(0) && timer > 0.2f)
        {
            timer = 0;
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = Physics.SphereCastAll(ray, 1.0f);
            for (int i = 0; i < hit.Length; ++i)
            {
            
                {
                    Debug.Log("터치터치팡팡");
                    hit[i].collider.gameObject.GetComponent<boxcheck>().touchon();
                }
            }
        }
    }
}
