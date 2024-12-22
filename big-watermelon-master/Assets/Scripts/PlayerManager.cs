using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //���õ���ģʽ
    public static PlayerManager Instance;
    //ˮ��Ԥ��������
    public GameObject[] fruitPrefabs;
    //׼��ˮ����λ��
    public Transform createFruitPoint;
    //׼���е�ˮ��
    public GameObject readyFruit;

    //��Ϸʱ��
    public  float time;
    public float PlayTimeTotal=60;

    //��Ϸ��������
    public GameObject GameOverPanel;

    public bool isGameOver = false;
    

    private void Awake()
    {
        time = PlayTimeTotal;
        Instance = this;
    }
    void Start()
    {
        CreateFruit();
    }

    void Update()
    {
        if(isGameOver==false)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                isGameOver = true;
                GameOverPanel.SetActive(true);
            }
            if (readyFruit == null)
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newPos = new Vector3(mousePos.x, readyFruit.transform.position.y, readyFruit.transform.position.z);

                float maxX = 2.8f - readyFruit.GetComponent<CircleCollider2D>().radius;
                float minX = -2.8f + readyFruit.GetComponent<CircleCollider2D>().radius;
                if (newPos.x > maxX)
                {
                    newPos.x = maxX;
                }
                else if (newPos.x < minX)
                {
                    newPos.x = minX;
                }
                readyFruit.transform.position = newPos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                readyFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
                Invoke("CreateFruit", 0.8f);
                readyFruit = null;
            }
        }
        

    }

    /// <summary>
    /// ����ˮ��
    /// </summary>
    public void CreateFruit()
    {
        //���һ������
        int index = Random.Range(0, 4);
        GameObject prefab = fruitPrefabs[index];
        readyFruit = Instantiate(prefab);
        readyFruit.transform.position = createFruitPoint.position;
        readyFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
