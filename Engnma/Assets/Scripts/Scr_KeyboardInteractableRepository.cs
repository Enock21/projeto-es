using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_KeyboardInteractableRepository:MonoBehaviour
{

    //Lista de gameobjects que o player entrou no collider trigger. 
    private static List<Scr_KeyboardInteractable> colliders = new();

    private void Start()
    {
    }


    //Se o objeto n�o existe dentro da lista de colliders, ent�o ele � adicionado
    public static void AddCollider(Scr_KeyboardInteractable obj)
    {
        print(colliders.Count);
        if (!Contains(obj.ClassName))
            colliders.Add(obj);
        print(colliders.Count);
    }

    //Remove o collider que possui o mesmo className do Scr_KeyboardInteractable passado como parametro
    public static Scr_KeyboardInteractable RemoveColllider(Scr_KeyboardInteractable obj)
    {
        bool found = false;
        int i = 0;
        string className = obj.ClassName;
        Scr_KeyboardInteractable retorno = null;
        while (!found && i < colliders.Count)
        {
            if(colliders[i].ClassName == className)
            {
                colliders.Remove(obj);
                retorno = obj;
                found = true;
            }
            i++;
        }
        return retorno;
    }

    //Conta quantos elementos existem dentro da lista
    public static int Count()
    {
        
        return colliders.Count;
    }

    //Verifica se existe algum elemento com a instanceId passada como parametro. Se sim, retorna true, caso contr�rio, retorna falso
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

