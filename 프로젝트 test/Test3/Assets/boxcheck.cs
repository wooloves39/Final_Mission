using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//박스에 맞았을 경우 다음 문양을 생성시킨다.
//박스에 맞았을 경우 박스의 색을 변경시킨다.
//
enum Direction{left,right,top,bottom};
public class boxcheck : MonoBehaviour {
   private bool check;
   private int index;
    private int[] haven_point;
	// Use this for initialization
	void Start () {
        check = false;
       // gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	}
    public void touchon()
    {
        check = true;
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
        for (int i = 0; i < this.gameObject.transform.childCount; ++i)
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<boxcheck>().turnon();
        //GameObject boxes;
        //Vector3 pos = this.transform.position;
        //for (int i = 0; i < haven_point.Length; ++i)
        //{
        //    switch ((Direction)haven_point[i])
        //    {
        //        case Direction.left:
        //            pos.x -= 4;
        //            break;
        //        case Direction.right:
        //            pos.x += 4;
        //            break;
        //        case Direction.top:
        //            pos.y += 4;
        //            break;
        //        case Direction.bottom:
        //            pos.y -= 4;
        //            break;
        //    }
        //    boxes = Instantiate(this.gameObject, pos, Quaternion.identity, this.gameObject.transform.parent);
        //}
    }
    public void touchdown()
    {
        check = true;
        this.transform.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
    }
    public void Set_index(int num)
    {
        index = num;
    }
    public bool Getcheck()
    {
        return check;
    }
    public int Get_index()
    {
        return index;
    }
    public void Sethaven(int[] value)
    { haven_point = new int[value.Length];
        for (int i = 0; i < value.Length; ++i)
        {
            haven_point[i] = value[i];
        }

    }
    public void turnon()
    {
       gameObject.SetActive(true);
    }
    public void turnoff()
    {
        gameObject.SetActive(false);
    }
}
