using UnityEngine;

public class Portal : Collidable
{
    [SerializeField] private string[] _sceneNames;
    
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GameManager.Instance.SaveState();
            var sceneName = _sceneNames[Random.Range(0, _sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
