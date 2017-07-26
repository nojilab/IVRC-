namespace {
  int sensorPin1 = A1;
  int sensorValue1 = 0;
  int sensorPin2 = A2;
  int sensorValue2 = 0;
  int led = 13;
}
  
void setup()
{
  Serial.begin(9600);//シリアル通信準備
 // pinMode(led, OUTPUT);
  //pinMode(13, OUTPUT); ここは使わなくなった
}

void readBrightness()
{
  // put your main code here, to run repeatedly:
  sensorValue1 = analogRead(1);//1番ピンの値を取得
  int brightness1 = sensorValue1;//まぶしさをゲット
  sensorValue2 = analogRead(2);//2番ピンの値を取得
  int brightness2 = sensorValue2;//まぶしさをゲット
  //Serial.println(brightness2);//シリアルモニタに表示
  delay(50);
  
 /* if(brightness1 <= 530){//画面が明るすぎるとledが光る
    digitalWrite(led,HIGH);
  }else {
    digitalWrite(led,LOW);
  }*/
  //ledで光センサーがとる値に影響が出てしまうことがあるので、使用しなくなった

  
  Serial.print(brightness1);//シリアル通信でパソコンに送る
  Serial.print("\t");//区切り文字
  Serial.print(brightness2);
  Serial.println("");

  
}


void loop()
{
  readBrightness();
  
}

