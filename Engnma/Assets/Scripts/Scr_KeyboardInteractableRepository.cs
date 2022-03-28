using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_KeyboardInteractableRepository:MonoBehaviour
{

    //Lista de gameobjects que o player entrou no collider trigger. 
    private static List<Scr_KeyboardInteractable> colliders = new();

    private void Awake()
    {
        
    }
    //Se o objeto não existe dentro da lista de colliders, então ele é adicionado
    public static void AddCollider(Scr_KeyboardInteractable obj)
    {

        if (!Contains(obj.ClassName))
            colliders.Add(obj);

    }

    //Remove o collider que possui o mesmo className do Scr_KeyboardInteractable passado como parametro
    public static void RemoveColllider(Scr_KeyboardInteractable obj)
    {
        bool found = false;
        int i = 0;
        string className = obj.ClassName;
        while(!found && i < colliders.Count)
        {
            if(colliders[i].ClassName == className)
            {
                colliders.Remove(obj);
                found = true;
            }
            i++;
        }
    }

    //Conta quantos elementos existem dentro da lista
    public static int Count()
    {
        return colliders.Count;
    }

    //Verifica se existe algum elemento com a instanceId passada como parametro. Se sim, retorna true, caso contrário, retorna falso
    public static bool Contains(string className)
    {
        bool retorno = false;
        int i = 0;
        while(!retorno && i < colliders.Count)
        {
            if(colliders[i].ClassName.ToUpper() == className.ToUpper())
            {
                retorno = true;
            }
            i++;
        }
        return retorno;
    }

    //Retorna o keyboarde que possui o mesmo className do que o passado como parametro
    public static Scr_KeyboardInteractable Get(string className)
    {
        Scr_KeyboardInteractable retorno = null;
        if (!Contains(className))
            return retorno;

        int i = 0;
        while (!retorno && i < colliders.Count)
        {
            if (colliders[i].ClassName.ToUpper() == className.ToUpper())
            {
                retorno = colliders[i];
            }
            i++;
        }
        return retorno;


    }


}

