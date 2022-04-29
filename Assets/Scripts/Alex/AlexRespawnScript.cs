using UnityEngine;
using UnityEngine.SceneManagement;

public class AlexRespawnScript : MonoBehaviour
{
    private Rigidbody2D _objectRigidBody;
    private Vector2 _respawnPoint = new Vector2(0, 0);

    // Start is called before the first frame update
    private void Start()
    {
        _objectRigidBody = GetComponent<Rigidbody2D>();
        _respawnPoint = _objectRigidBody.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Respawn()
    {
        _objectRigidBody.transform.position = _respawnPoint;
        _objectRigidBody.velocity = new Vector2();
        _objectRigidBody.angularVelocity = 0;
        _objectRigidBody.rotation = 0;
    }

    public void Reset()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    public void SetRespawnPoint(Vector2 newRespawnPoint)
    {
        _respawnPoint = newRespawnPoint;
    }
}