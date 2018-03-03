using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

    private GameObject bgm;
    
	void Awake() {
       
        DontDestroyOnLoad(gameObject);
    }
   
}
