using UnityEngine;
using System.Collections;


public class InterfaceControl : MonoBehaviour {
    private int dsize = 40;
    //database
    private Database db;
    //array of cards 
    private Card[] cards;

    public GameObject prefab;
    private GameObject[] go;
    private Renderer[] rend_cards;

	// Use this for initialization
	void Start () {
        db = new Database("cards.db", "SELECT * FROM cards WHERE id < 42    ");
        cards = db.getCards();
        CreatePrefab();
    }
	
    //Gera um prefab para cada carta, e muda sua textura para cada id
    void CreatePrefab(){
        go = new GameObject[dsize];
        rend_cards = new Renderer[dsize];
        for (int i = 0; i < dsize; i++)
        {
            go[i] = (GameObject)Instantiate(prefab, new Vector3(69,5.01f + i * 0.05f, -15.5f), new Quaternion(0,180,0,0));
            Renderer rend = go[i].GetComponent<Renderer>();
            int id = cards[i].getID();
            rend.material.mainTexture = (Texture)Resources.Load("Cards/" + id.ToString());
        }
    }
    

}
