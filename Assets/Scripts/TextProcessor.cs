using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextProcessor : MonoBehaviour
{

    private string[] fragments = {"Long ago, this planet was lush and alive. The Ancients harnessed its energy to thrive. But their greed poisoned the land, leaving only a few survivors—tiny creatures like the one in your wheel, carrying the last spark of hope.",
                                  "The Ancients built machines to sustain themselves, but their creations turned on them, consuming the world’s remaining resources. They fled, leaving their technology behind. Somewhere on this planet lies their greatest secret—a way to restore life.",
                                  "Your little companion is no ordinary alien. Its kind was engineered by the Ancients to preserve the planet’s essence. Only by working together can you uncover the key to reversing the damage they caused.",
                                  "Deep beneath the toxic surface lies the Heart of the World, a powerful core hidden by the Ancients. It holds the power to heal the planet—or destroy it forever. Will you find it and make the right choice?"};
    //private char[] chars = {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    private char[] chars = {'0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'};

    [SerializeField] private Toggle[] KeysToggle;
    [SerializeField] private Toggle[] FragsToggle;
    [SerializeField] private TMP_Text[] FragTexts;

    [SerializeField] private bool[] all_keys = {false, false, false, false};
    [SerializeField] private bool[] all_frags = {false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string encryptFragment(int frag, bool[] keys){
        string result = "";
        int cur_key = 0;
        foreach(string word in fragments[frag].Split(' ')){
            if(!keys[cur_key++]){
                string w = "";
                foreach(char c in word) w += chars[Random.Range(0, chars.Length)];
                result += w + " ";
            }
            else result += word + " ";
            if(cur_key >= keys.Length) cur_key = 0;
        }
        return result;
    }

    public void SetUI(){
        for(int i = 0; i < all_keys.Length; ++i) KeysToggle[i].isOn = all_keys[i];
        for(int i = 0; i < all_frags.Length; ++i) {
            FragsToggle[i].isOn = all_frags[i];
            if(all_frags[i]) FragTexts[i].SetText(encryptFragment(i, all_keys));
        }
    }
}
