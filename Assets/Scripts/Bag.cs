using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {
	List<string> items;
	// Use this for initialization
	void Start () {
		items = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addItem(string a){
		items.Add(a);
	}

	public bool hasItem(string a){
		return items.Contains (a);
	}

	public string removeItem(string a){
		string retVal = null;
		if (hasItem (a)) {
			retVal = a;

			items.Remove (a);
		}
		return retVal;
	}
}
