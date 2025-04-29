using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Скорость движения персонажа
    [SerializeField]
    private float speed = 5f;

    // Update вызывается один раз за кадр
    void Update()
    {
        // Двигаем персонажа по оси Z
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
