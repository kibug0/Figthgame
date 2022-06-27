using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentPlayerScript : MonoBehaviour
{
    private Rigidbody2D PlayerRB;//Rigidbody2d do player para fazer a movimentação por base da fisica no player
    PlayerInputActions PlayerInpAct;//Cria uma classe feita do inputsystem que eu criei

    private void Awake()//ao começar o jogo
    {
        PlayerRB = GetComponent<Rigidbody2D>();//Ele pega o rigibody presente no player e seta na variavel

        PlayerInpAct = new PlayerInputActions();//Cria uma classe feita do inputsystem que eu criei
        PlayerInpAct.Player.Enable();//Eu ativo o mapa especifico do player
        PlayerInpAct.Player.Jump.performed += jump;//eu coloco na ação de jump a função que eu crie no momento de performed para assim nesse momento ativar a função
        PlayerInpAct.Player.Moviment.performed += Moviment_performed;// coloco na ação de moviment a função que movimenta o player
    }

    private void FixedUpdate()
    {
        float inputVector = PlayerInpAct.Player.Moviment.ReadValue<float>();
        float speed = 6f;
        PlayerRB.AddForce(new Vector2(inputVector,0) * speed,  ForceMode2D.Force);

    }

    public void Moviment_performed(InputAction.CallbackContext context)//Função criada para mover o player pelo plano 2D
    {
        Debug.Log(context);//para mostrar tudo que ocorre ao apertar o botão
        float inputVector = context.ReadValue<float>();//Ele le o valor em float e o coloca na variavel float inputVector
        float speed = 6f;//Valor da velocidade que o player ira se mover
        PlayerRB.AddForce(new Vector2(inputVector,0) * speed,  ForceMode2D.Force); // acrecenta força ao rigidbody2d do player para jogalo para cima dando a impressão de um pulo


    }


    public void jump(InputAction.CallbackContext context/*Ele vai me falar o que esta aontecendo quando eu aperto o botão*/)//Função criada parapular
    {
        Debug.Log(context);//para mostrar tudo que ocorre ao apertar o botão
        if(context.performed)//Caso ao apertar o botão ele entre na fase de performed ele ira pular
        {
            Debug.Log("Jump " + context.phase);//Um debug para ter certeza se esta rodando tudo certo e para eu ver em quais partes estão sendo ativadas ao apertar o botão
            PlayerRB.AddForce(Vector2.up * 2f,  ForceMode2D.Impulse); // acrecenta força ao rigidbody2d do player para jogalo para cima dando a impressão de um pulo
        }
    }
}
