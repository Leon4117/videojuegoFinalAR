using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { TimeExtra, DoublePoints }
    public PowerUpType powerUpType;
    public float timeToAdd = 10f; // Tiempo extra en segundos
    public float duration = 5f; // Duración para efectos temporales
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUp(GameObject player)
    {
        switch (powerUpType)
        {
            case PowerUpType.TimeExtra:
                Cronometer cronometer = FindObjectOfType<Cronometer>();
                if (cronometer != null)
                {
                    cronometer.AddTime(timeToAdd);
                }
                break;
                
            case PowerUpType.DoublePoints:
                Puntaje puntaje = FindObjectOfType<Puntaje>();
                if (puntaje != null)
                {
                    puntaje.ActivateDoublePoints(duration);
                }
                break;
        }
    }
}