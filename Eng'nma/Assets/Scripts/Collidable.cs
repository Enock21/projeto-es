using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Adiciona automaticamente uma caixa de colisão ao objeto portador deste script:
[RequireComponent(typeof(BoxCollider2D))]
/*
Obs: Adicionar um componente automaticamente pode ser perigoso, pois a engine
cria o componente com valores automáticos que podem causar um erro difícil de
detectar. Pode ser melhor receber uma mensagem de erro que avise o desenvolvedor
sobre a falta de componente do que ter um erro furtivo.
*/
public class Collidable : MonoBehaviour
{
    //Indica com o que se deve colidir
    public ContactFilter2D filter;
    
    private BoxCollider2D boxCollider;
    
    //Armazena dados sobre objetos que colidiram com este durante um frame
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        //Indica que o objeto portador deste script precisa de um componente do tipo BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //A função detecta qualquer objeto que esteja colidindo com filter neste frame e armazena uma referência a ele no array hits
        boxCollider.OverlapCollider(filter, hits);

        //Itera sobre o array hits, buscando um objeto que seja diferente de null para exibir seu nome no console
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            
            Debug.Log(hits[i].name);

            //O array não limpa automaticamente após um frame, portanto o processo é feito manualmente a seguir
            hits[i] = null;
        }
    }
}
