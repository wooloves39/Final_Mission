using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//박스에 맞았을 경우 다음 문양을 생성시킨다.
//박스에 맞았을 경우 박스의 색을 변경시킨다.
//
public class boxcheck : MonoBehaviour {
   private bool check;
   private int index;
	// Use this for initialization
	void Start () {
        check = false;
  }
	
	// Update is called once per frame
	void Update () {
        if (check == true)
        {
            this.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0);
        }
	}
    public void touchon()
    {
        check = true;
    }
    public void Set_index(int num)
    {
        index = num;
    }
}
