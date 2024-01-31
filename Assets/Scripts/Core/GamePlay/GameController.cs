using System.Collections;
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


    public Camera mainCamera;  // A c�mera principal
    public Camera uiCamera;  // A c�mera UI
    public Transform player1CameraPosition;  // A posi��o da c�mera para o jogador 1
    public Transform player2CameraPosition;  // A posi��o da c�mera para o jogador 2

    [SerializeField]
    private bool cardPlayedThisTurn; // verifica se foi jogado carta no turno         

    [SerializeField]
    private float camSpeed = 1.0f; // Velocidade da anima��o da camera

    void Start()
    {
        instance = this;
        currentPlayer = player1;

        cardPlayedThisTurn = false;
    }

    void Update()
    {
        
    }

    public IEnumerator MoveCamera(Transform fromPosition, Transform toPosition) //anima��o da camera na troca de turno
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
            yield return new WaitForFixedUpdate(); // espera pelo pr�ximo FixedUpdate 
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
    }

    public bool CanPlayCard()  // Adicione este m�todo
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
        cardPlayedThisTurn = true;  // Quando uma carta � jogada, defina a vari�vel como true
    }


    public PlayerController GetCurrentPlayer()
    {
        // Retorne o jogador atual
        return currentPlayer;
    }

}
