using UnityEngine;
using UnityEngine.UI;

public class EnlargedCardController : MonoBehaviour
{
    public Image cardImage;
    public Button closeButton;

    void Start()
    {
        closeButton.onClick.AddListener(CloseEnlargedCard);
    }

    public void Setup(Sprite cardSprite) // Recebe a sprite da carta como parâmetro
    {
        cardImage.sprite = cardSprite;
    }

    private void CloseEnlargedCard()
    {
        Destroy(gameObject);
    }
}
