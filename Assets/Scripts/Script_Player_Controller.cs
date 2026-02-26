using UnityEngine;

public class Script_Player_Controller : MonoBehaviour
{
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float xRange = 20.0f;
    [SerializeField] float zRange = 20.0f;
    [SerializeField] GameObject projectilePrefab;

    private bool isBoostActive = false;// флаг для проверки активации буста
    private float boostMultiplier = 2.0f;// множитель скорости при бусте


    // Update is called once per frame
    void Update()
    {
        // Проверка нажатия комбинации клавиш ( LeftShift + B)
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.B))
        {
            isBoostActive = !isBoostActive; // Переключение состояния ускорения
        }

        // Установка скорости с учётом ускорения
        float currentSpeed = isBoostActive ? speed * boostMultiplier : speed;

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * currentSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * currentSpeed);

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xRange, xRange);
        transform.position = pos;
        pos.z = Mathf.Clamp(pos.z, -zRange, zRange);
        transform.position = pos;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBoostActive)
            {
                // Утроенный выстрел при активном ускорении
                Instantiate(projectilePrefab, transform.position + Vector3.right, projectilePrefab.transform.rotation); // Вправо
                Instantiate(projectilePrefab, transform.position + Vector3.left, projectilePrefab.transform.rotation);  // Влево
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);                 // Прямо
            }
            else
            {
                // Обычный выстрел
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            }
        }
    }
}
