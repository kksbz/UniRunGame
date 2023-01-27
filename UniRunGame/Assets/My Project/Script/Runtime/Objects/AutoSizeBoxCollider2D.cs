using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    public bool isUseParentSize = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 objSize_ = default;
        //BoxCollider2D가져오기
        BoxCollider2D boxCollider_ = gameObject.GetComponentMust<BoxCollider2D>();
        //부모 오브젝트의 RectTransform 가져오기
        RectTransform parentRectTransform = transform.parent.gameObject.GetComponentMust<RectTransform>();
        //자신의 RectTransform 가져오기
        RectTransform rectTransform_ = gameObject.GetComponentMust<RectTransform>();
        //x축은 부모 오브젝트 값으로 y는 자신의 값으로 설정
        if(isUseParentSize == true)
        {
            objSize_.x = parentRectTransform.sizeDelta.x;
            objSize_.y = rectTransform_.sizeDelta.y;
        }
        else
        {
            objSize_.x = rectTransform_.sizeDelta.x;
            objSize_.y = rectTransform_.sizeDelta.y;
        }
        //자신의 boxCollider_에 위에서 설정한 값 저장
        boxCollider_.size = objSize_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
