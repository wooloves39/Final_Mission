using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skilcontroller : MonoBehaviour {
    public GameObject boxes;
    private GameObject[] box_point = new GameObject[10];//생성한 박스의 설정 변경하는 변수




    private int true_index = 0;
    private int rec_index;
    private GameObject coll_ob;
	// Use this for initialization
	void Start () {
        Vector3 pos = this.transform.position;
        //첫점
        box_point[0] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        box_point[0].GetComponent<boxcheck>().Set_index(0);
        box_point[0].GetComponent<boxcheck>().turnon();

        //1차선택
        pos.x += 4;
        box_point[1] = Instantiate(boxes, pos, Quaternion.identity, box_point[0].transform);
        box_point[1].GetComponent<boxcheck>().Set_index(1);
        pos.x -= 8;
        box_point[2] = Instantiate(boxes, pos, Quaternion.identity, box_point[0].transform);
        box_point[2].GetComponent<boxcheck>().Set_index(1);
        pos.x += 4;
        pos.y += 4;
        box_point[3] = Instantiate(boxes, pos, Quaternion.identity, box_point[0].transform);
        box_point[3].GetComponent<boxcheck>().Set_index(1);

        //2차선택
        //1-
        pos = box_point[1].transform.position;
        pos.y += 4;
        box_point[4] = Instantiate(boxes, pos, Quaternion.identity, box_point[1].transform);
        box_point[4].GetComponent<boxcheck>().Set_index(2);
        pos.x += 4;
        pos.y -= 4;
        box_point[5] = Instantiate(boxes, pos, Quaternion.identity, box_point[1].transform);
        box_point[5].GetComponent<boxcheck>().Set_index(2);
        //2-
        pos = box_point[2].transform.position;
        pos.x -= 4;
        box_point[6] = Instantiate(boxes, pos, Quaternion.identity, box_point[2].transform);
        box_point[6].GetComponent<boxcheck>().Set_index(2);
        pos.x += 4;
        pos.y += 4;
        box_point[7] = Instantiate(boxes, pos, Quaternion.identity, box_point[2].transform);
        box_point[7].GetComponent<boxcheck>().Set_index(2);
        pos.y -= 8;
        box_point[8] = Instantiate(boxes, pos, Quaternion.identity, box_point[2].transform);
        box_point[8].GetComponent<boxcheck>().Set_index(2);
        //3-
        pos = box_point[3].transform.position;
        pos.x += 4;
        box_point[9] = Instantiate(boxes, pos, Quaternion.identity, box_point[3].transform);
        box_point[9].GetComponent<boxcheck>().Set_index(2);


        //box_point[10] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[11] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[12] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[13] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[14] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[15] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[16] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[17] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[18] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //box_point[19] = Instantiate(boxes, pos, Quaternion.identity, this.transform);
        //3차 선택
    }

    // Update is called once per frame
    void Update () {
	}
    public void rec_in(int index,GameObject coll)
    {
        Debug.Log(index);
        if (true_index == index)
        {
            ++true_index;
            coll.GetComponent<boxcheck>().touchon();
        }
        else
            Destroy(gameObject);
        
    }
}
