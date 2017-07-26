using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public bool isEnable = false;//プレイヤーを見つけたか
    public Transform target;//追いかける対象。Inspecter からPlayerを代入
    public float speed = 0.01f;
    public Transform Sunlight;
    public GameObject Alert;

    

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        //円に入ったのがPlayerのタグがついているオブジェクトなら
        if (hit.CompareTag("Player"))
        {
            //isEnableをtrueにしてやる
            if (isEnable == false)
            {
                isEnable = true;
            }

        }
            RenderSettings.ambientIntensity = 0;
    }


    //索敵範囲にプレイヤーが入ったから追いかける
    void Update()
    {
        if (Sunlight.transform.localEulerAngles.x  <= 325)
        {
            isEnable = false;//暗くして逃げれば見失う
        }
        if (Sunlight.transform.localEulerAngles.x  >= 345)
        {
            isEnable = true;//明るすぎると敵に見つかる
        }

        if (isEnable == true)
        {
            //targetの方に少しずつ向きが変わる
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.6f);

            //targetに向かって進む
            transform.position += transform.forward * speed;

            //見つかってる時だけ「you are found!]と表示してやる。
             Alert.SetActive(true);

        }
        else if (isEnable == false)
        {
            Alert.SetActive(false);
        }

        // Enemyと触れたら
        if (Vector3.Distance(transform.position, target.transform.position) <= 1)
        {
            // ゲームオーバーにする
            // 現在のシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            // 現在のシーンを再読込する
            SceneManager.LoadScene(sceneIndex);

        }


    }
}

