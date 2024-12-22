using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{

    //�ȼ�
    public int level;
    //�Ƿ��һ�δ���
    private bool isFirstTrigger = true;

    private void Start()
    {
        Debug.Log(gameObject.GetInstanceID());
    }

    //�����ײִ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor" && Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0.2f)
        {
            AudioManager.Instace.PlayAudio(AudioManager.Instace.audioClips[1]);
        }
        if (PlayerManager.Instance.readyFruit != this.gameObject && collision.gameObject.tag == "Fruit")
        {
            if (this.level == collision.gameObject.GetComponent<Fruit>().level)
            {
                //����ҵ�ʾ��ID���ڶԷ���
                if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                {
                    //�ϳ�
                    //��ȡ���Ҹ�һ�����ˮ��
                    GameObject prefab = PlayerManager.Instance.fruitPrefabs[level];
                    GameObject fruit = Instantiate(prefab);
                    fruit.transform.position = this.gameObject.transform.position;
                    UIManager.Instance.Score += this.level * 2;
                    AudioManager.Instace.PlayAudio(AudioManager.Instace.audioClips[0]);
                    Destroy(this.gameObject);
                    Destroy(collision.gameObject);
                }
            }
            else
            {
                if (Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y) > 0.2f)
                {
                    AudioManager.Instace.PlayAudio(AudioManager.Instace.audioClips[1]);
                }
            }
        }
    }

    //�������ִ��
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (isFirstTrigger == false && PlayerManager.Instance.readyFruit != this.gameObject && collision.gameObject.name == "DeadLine")
    //    {
    //        SceneManager.LoadSceneAsync("SampleScene");
    //    }
    //    else if (isFirstTrigger == true && collision.gameObject.name == "DeadLine")
    //    {
    //        isFirstTrigger = false;
    //    }
    //}
}
