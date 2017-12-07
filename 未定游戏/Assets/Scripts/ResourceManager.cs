using UnityEngine;
using System.Collections;

public class ResourceManager : MonoBehaviour {

	private static ResourceManager m_instance;
	private ResourceManager()
	{}
	public static ResourceManager Instance()
	{
		if(m_instance == null)
		{
			m_instance = GameObject.FindObjectOfType<ResourceManager>();
			if(m_instance == null)
			{
				GameObject go = new GameObject();
				go.name = "ResourceManager";
				m_instance = go.AddComponent<ResourceManager>();
			}
		}
		return m_instance;
	}

	void Awake()
	{
        playerCtr = GameObject.FindObjectOfType<PlayerController>();
        gameMenuCtr = GameObject.FindObjectOfType<ameMenu>();
		//characterCtr = GameObject.FindObjectOfType<CharacterControl>();
		//gameMenuCtr = GameObject.FindObjectOfType<GameMenuUI>();

	}

    //public CharacterControl characterCtr;
    public PlayerController playerCtr;
    //public GameMenuUI gameMenuCtr;
    public ameMenu gameMenuCtr;
}
