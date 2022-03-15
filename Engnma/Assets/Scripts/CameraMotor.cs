using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    //Indica a direção do player a ser focado. Lembrar de adicionar o objeto Player manualmente no campo "look at" na interface do Unity
    [SerializeField]
    private Transform lookAt;

    //Indica até onde o player pode se mover no eixo x antes de a câmera começar a segui-lo
    [SerializeField]
    private float boundX = 2f;
    
    //Indica até onde o player pode se mover no eixo y antes de a câmera começar a segui-lo
    [SerializeField]
    private float boundY = 1.5f;

    void Start()
    {
        
    }

    //LateUpdate é atualizado após o Update e FixedUpdate. Para câmera o LateUpdate é recomendado para que não haja um delay visual no jogo
    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        //Diferença entre este frame e o próximo frame
        Vector3 delta = Vector3.zero;

        //--------------------------------------------------------
        //TESTANDO SE O PLAYER SE MOVE ALÉM DOS LIMITES DO EIXO X:
        //--------------------------------------------------------

        //Diferença entre as distancias atuais no eixo x do lookAt, isto é, do player, e a deste objeto (CameraMotor)
        float deltaX = lookAt.position.x - transform.position.x;

        //Condição em que o player se move além dos limites para a direita ou para a esquerda
        if (deltaX > boundX || deltaX < -boundX)
        {
            //Checa se o centro da câmera no eixo x é menor do que a posição do player no eixo x
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            //Checa se o centro da câmera no eixo x é maior do que a posição do player no eixo x. Observe que a condição de "igual" aqui não se aplica, pois já foi desconsiderada no if externo a este
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        //--------------------------------------------------------
        //TESTANDO SE O PLAYER SE MOVE ALÉM DOS LIMITES DO EIXO Y:
        //--------------------------------------------------------

        //Diferença entre as distancias atuais no eixo y do lookAt, isto é, do player, e a deste objeto (CameraMotor)
        float deltaY = lookAt.position.y - transform.position.y;

        //Condição em que o player se move além dos limites para cima ou para baixo
        if (deltaY > boundY || deltaY < -boundY)
        {
            //Checa se o centro da câmera no eixo y é menor do que a posição do player no eixo y
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            //Checa se o centro da câmera no eixo y é maior do que a posição do player no eixo y. Observe que a condição de "igual" aqui não se aplica, pois já foi desconsiderada no if externo a este
            else
            {
                delta.y = deltaY + boundY;
            }
        }
        
        //Adiciona os valores de x e de y ao vetor de posição da câmera. Caso o player não tenha se movido além dos limites, o valor somado será 0 para ambos os eixos
        transform.position += new Vector3(delta.x, delta.y, 0);
        Vector3 posi = transform.position;

        //seta a posição da camera com precisão de apenas 1 casa decimal. Ex: 0.0, 0.5, 2.7. Isso previne alguns bugs visuais gerados por espaços vazios do tilemap
        transform.position = new Vector3((float)(Mathf.Round(posi.x * 10) * 0.1), (float)(Mathf.Round(posi.y * 10) * 0.1), -10);
    }
}
