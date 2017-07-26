using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Brightness: MonoBehaviour
{
    public SerialHandler serialHandler;
    public float lastrotation = -45;
    public bool firstcheck = true;
    int firstbrightness2;//仮の初期値

    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\t" }, System.StringSplitOptions.None);
        if (data.Length < 2) return;

        try
        {
            int brightness1= int.Parse(data[0]);
            int brightness2 = int.Parse(data[1]);
            

            if (firstcheck == true)//brightness2の基準値をとる
            {
                  firstbrightness2 = brightness2;
                  firstcheck = false;

            }


            float rotation = -30 * (brightness1 - 200) / 1000;
            if (lastrotation <= rotation && rotation < 0)//直前の明るさを参考に、ステージを明るくだけする。暗くはならない
            {
                this.transform.rotation = Quaternion.Euler(rotation, 90, 0);
                lastrotation = rotation;
            }

            if(brightness2 <= firstbrightness2 - 15 || brightness2 >= firstbrightness2 + 15)//風車を回すことで、基準値から±４以上光量が変化したら画面を暗くする
            {
                this.transform.rotation = Quaternion.Euler(-45, 90, 0);
                firstcheck = true;//基準値更新できるように
                lastrotation = -45;//lastrotationを元に戻さないと明暗が変えられなくなる
            }

        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }
}
