using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;

    private Vector3 moveDelta;

    //Útil para chamar a caixa de colisão quando não quisermos que um personagem atravesse um objeto
    private RaycastHit2D hit;

    //Velocidade do player, usada no calculo de movimento. [SerializeField] permite que o atributo privado speedMove possa se tornar visível na interface gráfica da Unity
    [SerializeField]
    private float speedMove;

    public void Start()
    {
        //Assim que o game inicia, uma caixa de colisão é criada
        boxCollider = GetComponent<BoxCollider2D>();
        //Assim que o game inicia, o Unity associa o rigidbody com o componente RigidBody2D no Editor do mesmo objeto 
        //onde esse script estará anexado
        rigidbody = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate() funciona bem com o uso de physics
    public void FixedUpdate()
    {
        if(Scr_PlayerSettings.CanPlayerMove)
            Mover();
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
        //Colisao();
    }

    //Função que implementa o movimento do personagem principal
    public void Mover()
    {
        //A função retorna -1, 0 ou 1, dependendo se o personagem se move, respectivamente, para a esquerda, para lugar nenhum ou para a direita
        float x = Input.GetAxisRaw("Horizontal");

        //A função retorna -1, 0 ou 1, dependendo se o personagem se move, respectivamente, para baixo, para lugar nenhum ou para cima
        float y = Input.GetAxisRaw("Vertical");

        //Reset move delta
        moveDelta = new Vector3(x,y,0);

        //Muda a direção do sprite dependendo se está indo para a esquerda ou para a direita
        if (moveDelta.x > 0)
        {
            //Isso é o mesmo que: "transform.localScale = new Vector3(1,1,1);". Cuidado para não colocar como Vector3(1,0,0), pois assim irá encolher o sprite horizontalmente, fazendo-o desaparecer do mapa
            transform.localScale = Vector3.one;
        }else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Seta a velocidade do player diretamente no RigidBody, realizando calculos de colisão e movimento
        rigidbody.velocity = (moveDelta * speedMove);
    }

    //Quando o jogador entra em um collider setado como trigger, é chamado essa função com o collider do objeto adentrado passado como parametro
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Confirma a tag do objeto do collider. 
        if(collision.tag == "Keyboard_Collider")
        {
            Scr_KeyboardInteractable keyInt = collision.transform.parent.GetComponent<Scr_KeyboardInteractable>();
            //Adiciona o scrKeyboardInteractable do parent do objeto do collider para a lista de colliders em que o player invadiu.
            //Após isso, é printado o nome do collider assim como o nome do parent
            Scr_KeyboardInteractableRepository.AddCollider(keyInt);

            //Printa o nome do objeto adentrado, assim como as funções que ele contem
            keyInt.PrintFunctions();
        }

        //Caso em que o objeto colidido seja interagivel
        if(collision.tag == "interactible")
        {
            print("Saudações. Bem vindo a Eng'nma.");
            //GameEvents.instance.ShowText("Saudações. Bem vindo a Eng'nma.",20,Color.red,transform.position,Vector3.up*1,3.0f);
        }
    }

    //Quando o jogador sai de um collider setado como trigger, é chamado essa função com o collider do objeto em que o player estava dentro passado como parametro
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Confirma a tag do objeto do collider. 
        if (collision.tag == "Keyboard_Collider")
        {
            //Remove o scrKeyboardInteractable do parent do objeto do collider da lista de colliders em que o player entrou.
            //Após isso, é printado o nome do parent, e a quantidade de triggers que o player entrou

            Scr_KeyboardInteractable obj = Scr_KeyboardInteractableRepository.RemoveColllider(collision.transform.parent.GetComponent<Scr_KeyboardInteractable>());
            obj.PrintExit();
        }
    }

}
