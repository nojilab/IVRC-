using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tresure : MonoBehaviour {

    public Object goal;
    public GameObject Open;
    // 宝物にプレイヤーが触れたら起動する
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            // このコンポーネントを持つGameObjectを破棄する
            Destroy(gameObject);//宝物消滅
            Destroy(goal);//ゴール出現
            Open.SetActive(true);//ゴールが開いたことを表示

        }
    }

}
