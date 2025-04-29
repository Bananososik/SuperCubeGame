using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject[] roadPrefabs; // Массив префабов дороги
    public int numberOfRoadSegments = 10; // Количество сегментов дороги
    public Vector3 startPosition = Vector3.zero; // Начальная позиция дороги
    public float segmentLength = 10f; // Длина одного сегмента дороги

    private GameObject roadParent; // Пустой объект для хранения сегментов дороги

    void Start()
    {
        GenerateRoad();
    }

    void GenerateRoad()
    {
        if (roadPrefabs == null || roadPrefabs.Length == 0)
        {
            Debug.LogError("Массив префабов дороги пуст. Добавьте префабы в инспекторе.");
            return;
        }

        // Создаем пустой объект внутри RoadGenerator
        roadParent = new GameObject("RoadSegments");
        roadParent.transform.SetParent(this.transform); // Устанавливаем родителем RoadGenerator

        Vector3 currentPosition = startPosition;

        for (int i = 0; i < numberOfRoadSegments; i++)
        {
            // Выбираем случайный префаб из массива
            GameObject randomRoadPrefab = roadPrefabs[Random.Range(0, roadPrefabs.Length)];

            // Создаем экземпляр префаба
            GameObject roadSegment = Instantiate(randomRoadPrefab, currentPosition, Quaternion.identity);

            // Устанавливаем родителем сегмента пустой объект
            roadSegment.transform.SetParent(roadParent.transform);

            // Обновляем позицию для следующего сегмента
            currentPosition += Vector3.forward * segmentLength;
        }
    }
}
