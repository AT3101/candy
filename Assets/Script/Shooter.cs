using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs; //CandyPrefabs�̔z��(�����w��\�ɂ���)
    public Transform candyParentTransform; //�e�I�u�W�F�N�g��Candies�����锠
    public float shotForce;  //��(��΂���)�̒l������ꏊ
    public float shotTorque; //��]�͂̒l������ꏊ
    public float baseWidth;  //�y��̕�

    void Start()
    {
        
    }

    void Update()
    {
        //GetButtonDown("Fire1")�Ń}�E�X�N���b�N���ʃ^�b�v�ɔ���(Fire1�͔��˂̈Ӗ�)
        if (Input.GetButtonDown("Fire1")) shot();//shot���\�b�h�Ăяo��
    }

    GameObject SampleCandy()//SnmpleCandy���\�b�h����
    
    {   //CandyOrenge[0],CandyLemon[1],CandyChocoMint[2],CandyChocoStrwberry[3]��4�������Ă�z���index�ɓ����
        //�L�����f�B�̃v���n�u���烉���_����1�I��
        int index = Random.Range(0, candyPrefabs.Length);
        return candyPrefabs[index]; //candyPrefabs�ɕԂ�
    }

    Vector3 GetInstamtiatePosition() //GetInstamtiatePositio���\�b�h����
    {
        //Input.mousePosition:�N���b�N�������̓^�b�v�����ʒu���Wx�̎擾
        //Screen:Screen.width�ŉ�ʉ����̎擾
        //BaseWidth/2��
        //��ʃT�C�Y��Input�̊�������L�����f�B�����̃|�W�V�����̌v�Z
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }
    public void shot()//shot���\�b�h����
    {
        //Instantiate:�I���W�i����GameObject����N���[���𐶐����郁�\�b�h
        //�E��1�����ɃI���W�i����GameObject
        //�E��2�����ɃN���[���������������W
        //�E��3�����ɃN���[���̉�]��
        //�v���n�u����Candy�I�u�W�F�N�g�𐶐�
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),            //�쐬����Candy
            GetInstamtiatePosition(), //���W
            Quaternion.identity       //������Ԃł͉�]���Ȃ��Ƃ����Ӗ�
            );

        //��������Candy�I�u�W�F�N�g�̐e��candyParentTransform�ɐݒ�
        candy.transform.parent = candyParentTransform; 
      
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>(); //Rigidbody�^��candyRigidBody�ϐ���candy�I�u�W�F�N�g��Rigidbody���擾(�R���|�[�l���g���擾�Ƃ�����)
        //AddForce�֐�:RigidBody�ɗ͂�������֐�(���x�E��΂�)
        candyRigidBody.AddForce(transform.forward * shotForce); //transform.forward(�I�u�W�F�N�g�������Ă����(�����Z��))��shotForce�̒l������Ɣ��
        //AddTorque�֐�:RigidBody�ɉ�]��(�g���N)��������֐�
        candyRigidBody.AddTorque(new Vector3(0, shotTorque,0)); //������Vector3�̒l���w�肵�AshotTorque(Y��)���w�肵�����ɉ�]����
    }
}
