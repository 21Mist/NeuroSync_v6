using UnityEngine;

public class musicBackground : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject); // N�o destroi o GameObj (com a m�sica) na troca de scene
    }

}
