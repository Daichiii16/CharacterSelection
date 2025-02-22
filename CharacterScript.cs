using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterScript : MonoBehaviour
{

    public List<Agents> AgentsData = new List<Agents>();

    public Transform buttonHolder;
    public GameObject buttonPrefab;

    [Header("Info")]
    public TextMeshProUGUI agentName;
    public TextMeshProUGUI agentGender;
    public TextMeshProUGUI agentIGN;
    public TextMeshProUGUI agentRank;
    public TextMeshProUGUI agentRole;
    public GameObject INFO;
    public GameObject Buttons;
    public Sprite[] sprites;



    void Start()
    {
        Agents agent01 = new Agents("Reyna", "Female", "Daikiii", "Gold", Role.Duelist,0);
        Agents agent02 = new Agents("Jett", "Female", "Nero", "Gold", Role.Duelist, 1);
        Agents agent03 = new Agents("Gekko", "Male", "Akatsuki","Gold", Role.Initiator, 2);
        Agents agent04 = new Agents("KillJoy", "Female", "Marc", "Gold", Role.Sentinel, 3);
        Agents agent05 = new Agents("Astra", "Female", "William", "Ascendant", Role.Controller, 4);

        AgentsData.Add(agent01);
        AgentsData.Add(agent02);
        AgentsData.Add(agent03);
        AgentsData.Add(agent04);
        AgentsData.Add(agent05);

        foreach(Agents a in AgentsData)
        {
            CreatAgentsButton(a);
        }
    }

    public void CreatAgentsButton(Agents agent)
    {
        GameObject newAgent = Instantiate(buttonPrefab, buttonHolder);

        ScriptButton agentButton = newAgent.GetComponent<ScriptButton>();

        Button button = agentButton.GetComponent<Button>();

        Image image = newAgent.GetComponent<Image>();

        image.sprite = sprites[agent.imageValue];

        agentButton.SetData(agent);

        button.onClick.AddListener(()=> OnAgentButtonClick(agent));


    }

    public void OnAgentButtonClick(Agents agent)
    {
        INFO.SetActive(true);
        Buttons.SetActive (false);
        agentName.text = "Name: " + agent.name;
        agentGender.text = "Gender: " + agent.gender;
        agentIGN.text = "IGN: " + agent.IGN;
        agentRank.text = "Rank: " + agent.rank;
        agentRole.text = "Role: " + agent.role.ToString();
        
    }
}

[System.Serializable]

public class Agents
{
    public string name;
    public string gender;
    public string IGN;
    public string rank;

    public Role role;
    public int imageValue;

    public Agents(string name, string gender, string iGN, string rank, Role role, int image)
    {
        this.name = name;
        this.gender = gender;
        this.IGN = iGN;
        this.rank = rank;
        this.role = role;
        this.imageValue = image;
    }
}

public enum Role { Duelist, Controller, Sentinel, Initiator};