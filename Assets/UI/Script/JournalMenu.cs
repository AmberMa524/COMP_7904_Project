using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalMenu : MonoBehaviour
{

    private List<JournalEntry> current_journal;

    public TMP_Text title;

    public TMP_Text description;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        current_journal = new List<JournalEntry>();
        updateJournal();
        index = 0;
        setUpPage();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("index: " + index);
    }

    public void updateJournal() {
        current_journal = PlayerData.getJournalList();
        index = 0;
        setUpPage();
    }

    public void setUpPage() {
        if (current_journal.Count == 0)
        {
            title.text = "Journal is Currently Empty";
            description.text = "";
        }
        else {
            title.text = current_journal[index].name;
            description.text = current_journal[index].description;

        }
    }

    public void changePage(bool forwards) {
        if (current_journal.Count != 0) {

            if (forwards)
            {
                index += 1;
            }
            else
            {
                index += -1;
            }

            if (index > current_journal.Count)
            {
                index = 0;
            }
            else if (index < 0)
            {
                index = current_journal.Count - 1;
            }
            else
            {
                Debug.Log("Index within range");
            }

        } else {
            Debug.Log("Cannot Change Page, as there are no entries.");
        }
        setUpPage();
    }
}
