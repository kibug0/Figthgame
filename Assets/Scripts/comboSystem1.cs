using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboSystem1 : MonoBehaviour
{
    //Uma lista de strings para criar os enuns que iram se referir as direcoes para serem usadas nos combos
    [Header("Directions")]
    public List<string> ActionTypes;

    //Aki vc cria uma lista das propriedades de cada um dos botoes criados como o tipo do ataque e qual botao ele vai usar para ser ativado
    [Header("Input properties")]
    public List<actionInput> Inputs;

    //Nessa lista vc ira fazer os combos e suas sequencia podendo fazer mais de um combo
    [Header("combo properties")]
    public List<Combu> combos;

    //Esse vai ser um delay que ira ser usado para definir o tempo entre os ataques quando o ComboLeeway for igual ao Leeway o combo acaba
    [Header("Time to next attack")]
    public float ComboLeeway = 0.25f;

    //O timer para ir contando o tempo entre combos quando ele acaba e vc nao apertou o proximo botao do combo o combo reinicia
    float timer = 0;

    //O contador do delaay dos ataques que ira mudando ate o tempo certo
    float leeway = 0;


    [Header("Components")]
    //O animator que sera usado para ativar as animacoes
    public Animator anim;

    void Start()
    {
        //Seta o anim com o animator desse gameobject
        anim=GetComponent<Animator>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class actionInput
{
    //Nome da acao
    public string name;

    //O botao ou tecla que ira ativar esse GameInput
    [Header("KeyInput")]
    public KeyCode KeyInput;

    //Enum criado para caso esse for um GameInput de ataque qual tipo de ataque ele seria
    [Header("this attack type")]
    public ActionTypesEnum Attacktype;


}

[System.Serializable]
public class action
{
    //Nome da acao
    public string name;

    //Definir se esse acao vai ser de ataque ou movimento
    [Header("Choose if this Input is for moviment or Attack")]
    public movatt MOorAT;

    //Tempo do ataque
    public float length = 0.5f;

    //A string que vai ter o nome da animacao dessa acao que sera ativada se for um ataque
    public string AnimationName;

    //Enum criado para caso esse for um GameInput de ataque qual tipo de ataque ele seria
    [Header("this attack type")]
    public AttackEnum Attacktype;


    //Funcao para quando receber um AttackEnum chamado t que ira subistituir o Attacktype desse ComboInput
    public action(AttackEnum t)
    {
        Attacktype = t;
    }

    //Uma funca que retorna um bool baseado num ComboInput para saber se o ComboInput e esse ComboInput sao iguais
    public bool isSameAs(ComboInput test)
    {
        return(Attacktype == test.Attacktype);//retorna um bool se forem iguais
    }

}

[System.Serializable]
public class Combu
{
    //Nome do combo
    public string name;

    //Nesta lista vai fazer a sequencia de
    public List<action> actions;

}
