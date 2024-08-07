using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelSelection : MonoBehaviour
{
    public GameObject Scroller, LoadingPanel, videoNotAvalible;
    public GameObject Iconpanel,selectionPanel,VsPanel,saveBtn;
    public Image fillBar,PlayericonImage,opponentIconImage;
    public Text IdTextvspanel;
    public Sprite[] Sprites;
    public Sprite[] IconsSprites;
    public Button[] IconsBtn;
    public GameObject[] characters;
    public Button leftBtn,rightBtn,PlayBtn;
    private List<ItemInfo> lighterList = new List<ItemInfo>();
    private List<ItemInfo> playerIconList = new List<ItemInfo>();
    private ItemInfo tempItem;
    int selectedIndex;
    string SelectesScene;

    public enum RewardType
    {
        none, SelectionItem, RewardedCoin
    }
    public RewardType rewardType;
    //void OnEnable()
    //{
    //    if (MyAdsManager.Instance != null)
    //    {
    //        MyAdsManager.Instance.onRewardedVideoAdCompletedEvent += OnRewardedVideoComplete;
    //    }
    //}

    //void OnDisable()
    //{
    //    if (MyAdsManager.Instance != null)
    //    {
    //        MyAdsManager.Instance.onRewardedVideoAdCompletedEvent -= OnRewardedVideoComplete;
    //    }
    //}
    private void Start()
    {
        if (GAManager.Instance) GAManager.Instance.LogDesignEvent("Scene:" + SceneManager.GetActiveScene().name + SceneManager.GetActiveScene().buildIndex);
        if (GameManager.Instance.Initialized == false)
        {
            GameManager.Instance.Initialized = true;
            Rai_SaveLoad.LoadProgress();
        }
        InitialIzeScroller();
        GetItemsInfo();
        if (Iconpanel)
        {
            Iconpanel.SetActive(true);
        }

    }
    public void InitialIzeScroller()
    {
        #region Initialing Vape
        if (Scroller)
        {
            var vapeinfo = Scroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < vapeinfo.Length; i++)
            {
                lighterList.Add(vapeinfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.SelectionProps.LevelLock, lighterList);
        SetItemIcon(lighterList, Sprites);
        #endregion      
        if (Iconpanel)
        {
            var PlayersInfo = Iconpanel.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < PlayersInfo.Length; i++)
            {
                playerIconList.Add(PlayersInfo[i]);
            }
            SetItemIcon(playerIconList, IconsSprites);
        }
    }

    #region SetItemIcon
    private void SetItemIcon(List<ItemInfo> refList, Sprite[] btnIcons)
    {
        if (refList != null)
        {
            for (int i = 0; i < refList.Count; i++)
            {
                if (btnIcons.Length > i)
                {
                    if (btnIcons[i] && refList[i].itemBtn)
                    {
                        refList[i].itemBtn.GetComponent<Image>().sprite = btnIcons[i];
                    }
                }
            }
        }
    }
    #endregion

    #region SetupItemData
    private void SetupItemData(List<bool> unlockItems, List<ItemInfo> _ItemsInfo)
    {
        if (_ItemsInfo.Count > 0)
        {
            if (unlockItems.Count < _ItemsInfo.Count)
            {
                for (int i = 0; i < _ItemsInfo.Count; i++)
                {
                    if (unlockItems.Count <= i)
                    {
                        // Add new data to SaveData file in case the file is empty or new data is available
                        unlockItems.Add(_ItemsInfo[i].isLocked);
                    }
                }
            }
            // Setting up Hairs Properties to actual Properties from SaveData file  
            for (int i = 0; i < _ItemsInfo.Count; i++)
            {
                _ItemsInfo[i].isLocked = unlockItems[i];
            }
            //Adding Click listeners to btns 
            for (int i = 0; i < _ItemsInfo.Count; i++)
            {
                int Index = i;
                if (_ItemsInfo[i].itemBtn)
                {
                    _ItemsInfo[i].itemBtn.onClick.AddListener(() =>
                    {
                        selectedIndex = Index;
                        SelectItem(Index);
                    });
                }
            }
        }
    }
    #endregion

    #region SelectItem
    public void SelectItem(int index)
    {
        CheckSelectedItem(lighterList, Sprites);
        GetItemsInfo();
    }
    #endregion

    #region CheckSelectedItem
    private void CheckSelectedItem(List<ItemInfo> itemInfoList, Sprite[] itemSprites)
    {
        rewardType = RewardType.SelectionItem;
        if (itemInfoList.Count > selectedIndex)
        {
            tempItem = itemInfoList[selectedIndex];
            if (itemInfoList[selectedIndex].isLocked)
            {
                CheckVideoStatus();
            }
            else
            {
                if (itemSprites.Length > selectedIndex)
                {
                    if (itemSprites[selectedIndex])
                    {
                        SaveData.Instance.Selectedvape = selectedIndex;
                        //StartCoroutine(loadScene("GamePlay", 0.5f));
                        Rai_SaveLoad.SaveProgress();
                    }
                }
            }
        }
    }
    #endregion

    #region CheckVideoStatus
    public void CheckVideoStatus()
    {
        //if (MyAdsManager.Instance != null)
        //{
        //    if (MyAdsManager.Instance.IsRewardedAvailable())
        //    {
        //        MyAdsManager.Instance.ShowRewardedVideos();
        //    }
        //    else
        //    {
                videoNotAvalible.SetActive(true);
        //    }
        //}
        //else
        //{
        //    videoNotAvalible.SetActive(true);
        //}
    }
    #endregion

    #region RewardedVideoCompleted
    public void OnRewardedVideoComplete()
    {
        if (rewardType == RewardType.SelectionItem)
        {
            if (tempItem != null) tempItem.isLocked = false;
            UnlockSingleItem();
            SelectItem(selectedIndex);
        }
        Rai_SaveLoad.SaveProgress();
        GetItemsInfo();
        rewardType = RewardType.none;
        //SoundManager.Instance.PurChasePlay();
    }
    #endregion

    #region GetItemsInfo
    private void GetItemsInfo()
    {
        SetItemsInfo(lighterList);
    }

    #endregion

    #region SetItemsInfo
    private void SetItemsInfo(List<ItemInfo> _ItemInfo)
    {
        if (_ItemInfo == null) return;
        for (int i = 0; i < _ItemInfo.Count; i++)
        {
            if (_ItemInfo[i].isLocked)
            {
                if (_ItemInfo[i].VideoSlot)
                {
                    _ItemInfo[i].VideoSlot.SetActive(true);
                }
            }
            else
            {
                if (_ItemInfo[i].VideoSlot) _ItemInfo[i].VideoSlot.SetActive(false);
            }
        }
    }
    #endregion

    #region UnlockSingleItem
    public void UnlockSingleItem()
    {
        SaveData.Instance.SelectionProps.LevelLock[selectedIndex] = false;
        Rai_SaveLoad.SaveProgress();
    }
    #endregion

    IEnumerator loadScene(string str)
    {
        LoadingPanel.SetActive(true);
        fillBar.fillAmount = 0;
        while (fillBar.fillAmount < 1)
        {
            fillBar.fillAmount += Time.deltaTime / 3;
            yield return null;
        }
        SceneManager.LoadScene(str);
    }
    public int modeSelected = 0;
    public void Next()
    {
        if (modeSelected < characters.Length - 1)
        {
            leftBtn.GetComponent<ScalePingPong>().enabled = true;
            leftBtn.interactable = true;
            characters[modeSelected].GetComponent<RectTransform>().DOAnchorPosX(-1250, 1f);
            characters[modeSelected + 1].GetComponent<RectTransform>().DOAnchorPosX(0, 1f);
            modeSelected++;
        }
        if (modeSelected == characters.Length - 1)
        {
            rightBtn.interactable = false;
            rightBtn.GetComponent<ScalePingPong>().enabled = false;
        }
    }

    public void Previous()
    {
        if (modeSelected > 0)
        {
            rightBtn.GetComponent<ScalePingPong>().enabled = true;
            rightBtn.interactable = true;
            characters[modeSelected - 1].GetComponent<RectTransform>().DOAnchorPosX(0, 1f);
            characters[modeSelected].GetComponent<RectTransform>().DOAnchorPosX(1250, 1f);
            modeSelected--;
        }
        if (modeSelected == 0)
        {
            leftBtn.interactable = false;
            leftBtn.GetComponent<ScalePingPong>().enabled = false;
        }
    }

    public void Play(string str)
    {
        SelectesScene = str;
        selectionPanel.SetActive(false);
        VsPanel.SetActive(true);
        StartCoroutine(FindOponent());
    }

    public void PlayerIconsSelection(int index)
    {
        for (int i = 0; i < IconsBtn.Length; i++)
        {
            IconsBtn[i].transform.localScale = new Vector3(1, 1, 1);
        }
        SaveData.Instance.PlayerSelectedAvatar = index;
        IconsBtn[index].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        IconsBtn[index].transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        PlayericonImage.sprite = IconsSprites[index];
        saveBtn.SetActive(true);
        Rai_SaveLoad.SaveProgress();
        #region Animation
        StartCoroutine(ANim());
        #endregion
    }

    IEnumerator ANim()
    {
        yield return new WaitForSeconds(0.1f);

        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].GetComponent<RectTransform>().DOAnchorPos(new Vector2(1200f, 0f), 0.7f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(0.7f);
            yield return null;
        }
        characters[0].GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 0f), 0.35f).SetEase(Ease.Linear);
    }

    IEnumerator FindOponent()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < Random.Range(10, 25); i++)
        {
            opponentIconImage.gameObject.SetActive(false);
            opponentIconImage.gameObject.SetActive(true);
            opponentIconImage.sprite = IconsSprites[Random.Range(0, IconsSprites.Length)];
            IdTextvspanel.gameObject.SetActive(false);
            IdTextvspanel.gameObject.SetActive(true);
            IdTextvspanel.text = Random.Range(100000, 999999).ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        PlayBtn.gameObject.SetActive(true);
        SaveData.Instance.opponentSelectedAvatar = opponentIconImage.sprite;
    }

    public void Play()
    {
        StartCoroutine(loadScene(SelectesScene));
    }

}

