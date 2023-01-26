using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float scrollingSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Translate가 Vector2를 받는게 없어서 GFunc Obj에 오버로딩한 함수를 만듬
        transform.Translate(Vector2.left * scrollingSpeed * Time.deltaTime);
    } //Update
}
