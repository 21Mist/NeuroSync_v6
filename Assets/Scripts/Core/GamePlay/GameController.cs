using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public DeckController deck1;
    public DeckController deck2;
    public static GameController instance;
    public PlayerController player1;
    public PlayerController player2;

    private PlayerController currentPlayer;  // O jogador atual


    public Camera mainCamera;  // A câmera principal
    public Camera uiCamera;  // A câmera UI
    public Transform player1CameraPosition;  // A posição da câmera para o jogador 1
    public Transform player2CameraPosition;  // A posição da câmera para o jogador 2

    [SerializeField]
    private bool cardPlayedThisTurn; // verifica se foi jogado carta no turno         

    [SerializeField]
    private float camSpeed = 1.0f; // Velocidade da animação da camera

    public GameObject backgroundCanva; 
    public GameObject CardViewP1;
    public GameObject CardViewP2;

    void Start()
    {
        instance = this;
        currentPlayer = player1;

        cardPlayedThisTurn = false;

        CloseCardView();
    }

    void Update()
    {
        
    }

    public IEnumerator MoveCamera(Transform fromPosition, Transform toPosition) //animação da camera na troca de turno
    {
        float step = (camSpeed / (fromPosition.position - toPosition.position).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // vai de 0 a 1, incrementando 'step' a cada vez
            mainCamera.transform.position = Vector3.Lerp(fromPosition.position, toPosition.position, t);
            uiCamera.transform.position = Vector3.Lerp(fromPosition.position, toPosition.position, t);
            mainCamera.transform.rotation = Quaternion.Lerp(fromPosition.rotation, toPosition.rotation, t);
            uiCamera.transform.rotation = Quaternion.Lerp(fromPosition.rotation, toPosition.rotation, t);
            yield return new WaitForFixedUpdate(); // espera pelo próximo FixedUpdate 
        }
    }


    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EndTurn()
    {
        //muda para player2
        if (currentPlayer == player1)
        {
            deck1.GetCard();
            currentPlayer = player2;
            StartCoroutine(MoveCamera(player1CameraPosition, player2CameraPosition));
        }
        //muda para player1
        else
        {
            deck2.GetCard();
            currentPlayer = player1;
            StartCoroutine(MoveCamera(player2CameraPosition, player1CameraPosition));
        }
        
        cardPlayedThisTurn = false;
        CloseCardView();
    }

    public bool CanPlayCard() 
    {
        if (!cardPlayedThisTurn)
        {
            cardPlayedThisTurn = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CardPlayed() 
    {
        cardPlayedThisTurn = true;  // Quando uma carta é jogada, variável fica true
    }


    public PlayerController GetCurrentPlayer()
    {
        // Retorna quem é o jogador atual
        return currentPlayer;
    }

    public void OpenCardView() //abre a interface quando clica com o mouse esquerdo
    {
        backgroundCanva.SetActive(true);
    }

    public void CloseCardView() //fecha a interface quando clica com o mouse esquerdo
    {
        backgroundCanva.SetActive(false);

        //apaga as cartas grandes que estão abertas
        foreach (Transform child in CardViewP1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in CardViewP2.transform)
        {
            Destroy(child.gameObject);
        }
    }


}
