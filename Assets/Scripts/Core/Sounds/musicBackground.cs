using UnityEngine;

public class musicBackground : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject); // Não destroi o GameObj (com a música) na troca de scene
    }

}
