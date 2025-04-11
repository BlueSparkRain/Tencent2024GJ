using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public class LayerMouseOffset : MonoBehaviour
{
    public float offsetMultiplyer = 1;
    public float smoothTime = 0.5f;
    Vector2 startPos;
    Vector3 velocity;
 

    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {

        // ��ȡ�����Ļλ��
        Vector3 mousePos = Input.mousePosition;

        // �����λ�ô���Ļ�ռ�ת��Ϊ�ӿ�����
       Vector2 offset = Camera.main.ScreenToViewportPoint(mousePos) *100;

        // ʹ�����嵱ǰ�� z ���꣬������������
        Vector3 targetPosition = startPos + (offset * offsetMultiplyer);
        targetPosition.z = transform.position.z; // ������ǰ�� z ����

        // ƽ���ƶ�
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void SetPosition(Vector3 position)
    {
        startPos = position;
    }
}
