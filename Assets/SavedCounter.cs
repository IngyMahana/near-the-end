using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SavedCounter : MonoBehaviour
{
    public TMP_Text savedCountText;

    // Start is called before the first frame update
    void Start(){
        savedCountText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update(){
        savedCountText.text = "Recover the bodies of the fallen soldiers" + " (" + Main.numSaved.ToString() + "/8)";
    }
}
