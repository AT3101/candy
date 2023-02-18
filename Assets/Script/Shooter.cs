using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs; //CandyPrefabsの配列化(複数指定可能にする)
    public Transform candyParentTransform; //親オブジェクトのCandiesを入れる箱
    public float shotForce;  //力(飛ばす力)の値を入れる場所
    public float shotTorque; //回転力の値を入れる場所
    public float baseWidth;  //土台の幅

    void Start()
    {
        
    }

    void Update()
    {
        //GetButtonDown("Fire1")でマウスクリックや画面タップに反応(Fire1は発射の意味)
        if (Input.GetButtonDown("Fire1")) shot();//shotメソッド呼び出し
    }

    GameObject SampleCandy()//SnmpleCandyメソッド生成
    
    {   //CandyOrenge[0],CandyLemon[1],CandyChocoMint[2],CandyChocoStrwberry[3]の4つが入ってる配列をindexに入れる
        //キャンディのプレハブからランダムに1つ選ぶ
        int index = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[index]; //candyPrefabsに返す
    }

    Vector3 GetInstamtiatePosition() //GetInstamtiatePositioメソッド生成
    {
        //Input.mousePosition:クリックもしくはタップした位置座標xの取得
        //Screen:Screen.widthで画面横幅の取得
        //BaseWidth/2で
        //画面サイズとInputの割合からキャンディ生成のポジションの計算
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }
    public void shot()//shotメソッド生成
    {
        //Instantiate:オリジナルのGameObjectからクローンを生成するメソッド
        //・第1引数にオリジナルのGameObject
        //・第2引数にクローンが生成される座標
        //・第3引数にクローンの回転量
        //プレハブからCandyオブジェクトを生成
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),            //作成したCandy
            GetInstamtiatePosition(), //座標
            Quaternion.identity       //初期状態では回転しないという意味
            );

        //生成したCandyオブジェクトの親をcandyParentTransformに設定
        candy.transform.parent = candyParentTransform; 
      
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>(); //Rigidbody型のcandyRigidBody変数にcandyオブジェクトのRigidbodyを取得(コンポーネントを取得とも言う)
        //AddForce関数:RigidBodyに力を加える関数(速度・飛ばす)
        candyRigidBody.AddForce(transform.forward * shotForce); //transform.forward(オブジェクトが向いてる方向(今回はZ軸))にshotForceの値を入れると飛ぶ
        //AddTorque関数:RigidBodyに回転力(トルク)を加える関数
        candyRigidBody.AddTorque(new Vector3(0, shotTorque,0)); //引数にVector3の値を指定し、shotTorque(Y軸)を指定し水平に回転する
    }
}
