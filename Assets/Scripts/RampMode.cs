﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class RampUiElements
{
    [Header("Scrollers")]
    public GameObject aLLScrollers;
    public GameObject dressScroller, HandItemsScroller, HairBandScroller, hairScrolleer, BangelsScroller, shoeScroller,
                      earRingScroller, EyeShadesScroller, lipstickScroller, necklaceScroller, EyeBrowScroller, BgScroller, 
                      BlushScroller;
    [Header("Images")]
    public Image dressImage;
    public Image HandItemsImage, HairBandImage, hairImage, BangelsImage, shoesImage, earRingsImage, EyeShadesImage, lipstickImage, neckLaceImage,
                 EyeBrowImage, BgImage, BlushImage;
    public Image videoSlotItem, coinslotItem;
}
[System.Serializable]
public class RampOpponent
{
    [Header("Images")]
    public Image oppodressImage;
    public Image oppobangelImage, oppohairImage, oppoeyeShadesImage, oppoHandItemsImage, oppoearRingImage, oppoHairBandImage, opponeckLaceImage, oppoEyeBrowImage, 
                 opposhoesImage, oppolipstickImage, oppoBlushImage;
    [Header("Text")]
    public Text playerTotal;
    public Text oppoTotal, videoScore, CoinScore, requirdCoins;
}
[System.Serializable]
public enum RampSelectedItem
{
     Dress, Hair, EyeShades, EyeBrow, Blush, Lipstick, HairBand, EarRings, NeckLace, Bangels, HandItems, Shoes, BackGround
}
public class RampMode : MonoBehaviour
{
    public RampSelectedItem selectedItem;
    public RampUiElements uIElements;
    public RampOpponent oppElements;
    [Header("Panels")]
    public GameObject AdPenl;
    public GameObject topBar;
    public GameObject GamePanel, JudgementPanel;
    [Header("UI")]
    public GameObject sheIsReady;
    public GameObject needMoreCoins, videoNotAvalible, videoPanel, coinPanel,WinnerPanel ,LevelComplete;
    public Image BotIcon,playerIcon;
    [Header("Loading")]
    public GameObject LoadingPanel;
    public Image fillBar;
    [Header("MixElements")]
    public MRS_Manager CharactorMover;
    public MRS_Manager OpponentMover;
    public CoinsAdder coinsAdder;
    public CoinsAdder FinalcoinsAdder;
    [Header("Text")]
    public Text TotalCoins;
    public Text totalScore;
    [Header("Audio")]
    public AudioSource itemSelectSFX;
    public AudioSource purchaseSFX;
    public AudioSource CategorySFX;
    public AudioSource CoinsSFX;
    public AudioSource winSFX;
    public AudioSource LoseSFX;
    [Header("Particals")]
    public GameObject scorePartical;
    public GameObject Confetti;
    [Header("Sprites")]
    public Sprite selectionSelectedSprite;
    public Sprite selectionDefaultSprite;
    public Sprite CatagoryDefaultSprites;
    public Sprite CatagorySelectedSprites;
    public Sprite[] dressSprites;
    public Sprite[] HandItemSprites;
    public Sprite[] HairBandSprites;
    public Sprite[] hairSprites;
    public Sprite[] BangelsSprites;
    public Sprite[] ShoesSprites;
    public Sprite[] earRingsSprites;
    public Sprite[] EyeShadesSprites;
    public Sprite[] lipsTickSprites;
    public Sprite[] necklaceSprites;
    public Sprite[] EyeBrowSprites;
    public Sprite[] backgroundSprites;
    public Sprite[] BlushSprites;
    public Image[] CatagoryImage;
    public Sprite[] botSprites; 
    private List<ItemInfo> dressList = new List<ItemInfo>();
    private List<ItemInfo> HandItemList = new List<ItemInfo>();
    private List<ItemInfo> HairBandList = new List<ItemInfo>();
    private List<ItemInfo> hairList = new List<ItemInfo>();
    private List<ItemInfo> BangelsList = new List<ItemInfo>();
    private List<ItemInfo> ShoesList = new List<ItemInfo>();
    private List<ItemInfo> earRingsList = new List<ItemInfo>();
    private List<ItemInfo> EyeShadesList = new List<ItemInfo>();
    private List<ItemInfo> lipstickList = new List<ItemInfo>();
    private List<ItemInfo> neckLaceList = new List<ItemInfo>();
    private List<ItemInfo> EyeBrowList = new List<ItemInfo>();
    private List<ItemInfo> BlushList = new List<ItemInfo>();
    private List<ItemInfo> backgroundList = new List<ItemInfo>();
    int Wincoin;
    private ItemInfo tempItem;
    private int selectedIndex;
    [HideInInspector]
    bool ADTime = true;
    bool IsDressTrue ,IsHairTrue,IsBangleTrue,IsNecklacetrue = false;
    private bool canShowInterstitial;
    private int dressValue, hairValue, bangleValue, HairBandValue, earringValue, BlushValue, eyeshadesValue, lipstickValue, necklaceValue, EyeBrowValue, shoeValue,
                bgValue, HandItemValue;
    private int oppodressValue, oppohairValue, oppobangleValue, oppoHairBandValue, oppoearringValue, oppoBlushValue, oppoeyeshadesValue, oppolipstickValue, 
                opponecklaceValue, oppoEyeBrowValue, opposhoeValue, oppoHandItemValue;
    private int[] DressScore = { 9100, 9150, 9200, 9250, 9300, 9350, 9400, 9450, 9500, 9550, 9600, 9650, 9700, 9750, 9900 };
    private int[] HairScore = { 8200, 8250, 8300, 8350, 8400, 8500, 8600, 8650, 8700, 8750, 8800, 8850, 8900, 8950, 9000 };
    private int[] BangelsScore = { 5150, 5200, 5250, 5300, 5350, 5400, 5450, 5600, 5650, 5700, 5750, 5800, 5850, 5900, 8950 };
    private int[] HairBandScore = { 3500, 3550, 3600, 3620, 3640, 3680, 3700, 3750, 3800, 3840, 3880, 3920, 3940, 3960, 3980 };
    private int[] EarRingsScore = { 6050, 6100, 6150, 6200, 6250, 6300, 6350, 6400, 6450, 6500, 6550, 6600, 6700, 6750, 6800 };
    private int[] BlushScore = { 3500, 3550, 3600, 3620, 3640, 3680, 3700, 3750, 3800, 3840, 3880, 3920, 3940, 3960, 3980 };
    private int[] EyeShadesScore = { 4000, 4050, 4100, 4150, 4200, 4250, 4300, 4350, 4400, 4420, 4440, 4460, 4480, 4490, 4495 };
    private int[] LipstickScore = { 3500, 3550, 3600, 3620, 3640, 3680, 3700, 3750, 3800, 3840, 3880, 3920, 3940, 3960, 3980 };
    private int[] NeckLaceScore = { 7000, 7100, 7200, 7300, 7400, 7500, 7600, 7700, 7750, 7800, 7850, 7900, 7940, 7980, 8000 };
    private int[] EyeBrowScore = { 4500, 4550, 4600, 4650, 4700, 4750, 4800, 4850, 4900, 4920, 4940, 4960, 4980, 5000, 5050 };
    private int[] ShoesScore = { 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500, 6000, 6500, 6800, 7000, 7200, 7400, 7600 };
    private int[] HandItemScore = { 3500, 3550, 3600, 3620, 3640, 3680, 3700, 3750, 3800, 3840, 3880, 3920, 3940, 3960, 3980 };
    private int[] BGScore = { 3500, 3550, 3600, 3620, 3640, 3680, 3700, 3750, 3800, 3840, 3880, 3920, 3940, 3960, 3980 };

    // private int selectedIndex;
    private enum RewardType
    {
        none, Coins, SelectionItem
    }
    private RewardType rewardType;

    //  public Text rewardInfo;

    #region start
    private void Start()
    {
        //if (GAManager.Instance) GAManager.Instance.LogDesignEvent("Scene:" + SceneManager.GetActiveScene().name + SceneManager.GetActiveScene().buildIndex);
        if (GameManager.Instance.Initialized == false)
        {
            GameManager.Instance.Initialized = true;
            Rai_SaveLoad.LoadProgress();
        }
        selectedItem = RampSelectedItem.Dress;
        uIElements.dressScroller.SetActive(true);
        TotalCoins.text = SaveData.Instance.Coins.ToString();
        SetInitialValues();
        GetItemsInfo();
        StartCoroutine(AdDelay(45));
        playerIcon.sprite = botSprites[SaveData.Instance.PlayerSelectedAvatar];
        if (SaveData.Instance.opponentSelectedAvatar != null)
        {
           // BotIcon.sprite = SaveData.Instance.opponentSelectedAvatar;
        }
        CharactorMover.Move(new Vector3(100, -150, 200), 0.5f, true, false);
    }

    IEnumerator ShowInterStitial()
    {
        //if (MyAdsManager.instance)
        //{
        //    if (MyAdsManager.instance.IsInterstitialAvailable())
        //    {
        //        if (uIElements.AdPenl) uIElements.AdPenl.SetActive(true);
                yield return new WaitForSeconds(0.5f);
        //        if (uIElements.AdPenl) uIElements.AdPenl.SetActive(false);
        //        MyAdsManager.instance.ShowInterstitialAds();
        //    }
        //}
    }
    #endregion
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

    #region SetInitialValues
    private void SetInitialValues()
    {

        #region Initialing Dress
        if (uIElements.dressScroller)
        {
            var dressinfo = uIElements.dressScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < dressinfo.Length; i++)
            {
                dressList.Add(dressinfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.dressLocked, dressList);
        SetItemIcon(dressList, dressSprites);
        #endregion      
  
        #region Initialing HandItems
        if (uIElements.HandItemsScroller)
        {
            var topinfo = uIElements.HandItemsScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < topinfo.Length; i++)
            {
                HandItemList.Add(topinfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.bagLocked, HandItemList);
        SetItemIcon(HandItemList, HandItemSprites);
        #endregion      
        
        #region Initialing HairBand

        if (uIElements.HairBandScroller)
        {
            var shortsinfo = uIElements.HairBandScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < shortsinfo.Length; i++)
            {
                HairBandList.Add(shortsinfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.hairbandLocked, HairBandList);
        SetItemIcon(HairBandList, HairBandSprites);
        #endregion

        #region Initialing hair
        if (uIElements.hairScrolleer)
        {
            var hairInfo = uIElements.hairScrolleer.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < hairInfo.Length; i++)
            {
                hairList.Add(hairInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.hairLocked, hairList);
        SetItemIcon(hairList, hairSprites);
        #endregion
   
        #region Initialing Bangels
        if (uIElements.BangelsScroller)
        {
            var handThingsInfo = uIElements.BangelsScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < handThingsInfo.Length; i++)
            {
                BangelsList.Add(handThingsInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.bangelsLocked, BangelsList);
        SetItemIcon(BangelsList, BangelsSprites);
        #endregion

        #region Initialing Shoes
        if (uIElements.shoeScroller)
        {
            var ShoesInfo = uIElements.shoeScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < ShoesInfo.Length; i++)
            {
                ShoesList.Add(ShoesInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.shoesLocked, ShoesList);
        SetItemIcon(ShoesList, ShoesSprites);
        #endregion

        #region Initialing EarRings
        if (uIElements.earRingScroller)
        {
            var earRingInfo = uIElements.earRingScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < earRingInfo.Length; i++)
            {
                earRingsList.Add(earRingInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.earRingLocked, earRingsList);
        SetItemIcon(earRingsList, earRingsSprites);
        #endregion

        #region Initialing eyesShades
        if (uIElements.EyeShadesScroller)
        {
            var eyesBrowInfo = uIElements.EyeShadesScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < eyesBrowInfo.Length; i++)
            {
                EyeShadesList.Add(eyesBrowInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.eyeShadesLocked, EyeShadesList);
        SetItemIcon(EyeShadesList, EyeShadesSprites);
        #endregion

        #region Initialing LipsTick
        if (uIElements.lipstickScroller)
        {
            var lipsTickInfo = uIElements.lipstickScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < lipsTickInfo.Length; i++)
            {
                lipstickList.Add(lipsTickInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.lipsTickLocked, lipstickList);
        SetItemIcon(lipstickList, lipsTickSprites);
        #endregion
     
        #region Initialing NeckLace
        if (uIElements.necklaceScroller)
        {
            var neckLaceInfo = uIElements.necklaceScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < neckLaceInfo.Length; i++)
            {
                neckLaceList.Add(neckLaceInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.necklaceLocked, neckLaceList);
        SetItemIcon(neckLaceList, necklaceSprites);
        #endregion 

        #region Initialing EyeBrow
        if (uIElements.EyeBrowScroller)
        {
            var noseRingInfo = uIElements.EyeBrowScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < noseRingInfo.Length; i++)
            {
                EyeBrowList.Add(noseRingInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.noseRingLocked, EyeBrowList);
        SetItemIcon(EyeBrowList, EyeBrowSprites);
        #endregion

        #region Initialing BINDI
        if (uIElements.BlushScroller)
        {
            var MehndiInfo = uIElements.BlushScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < MehndiInfo.Length; i++)
            {
                BlushList.Add(MehndiInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.BlushLocked, BlushList);
        SetItemIcon(BlushList, BlushSprites);
        #endregion
  
        #region Initialing BG
        if (uIElements.BgScroller)
        {
            var BGInfo = uIElements.BgScroller.GetComponentsInChildren<ItemInfo>();
            for (int i = 0; i < BGInfo.Length; i++)
            {
                backgroundList.Add(BGInfo[i]);
            }
        }
        SetupItemData(SaveData.Instance.indianProps.BGLocked, backgroundList);
        SetItemIcon(backgroundList, backgroundSprites);
        #endregion

        
        Rai_SaveLoad.SaveProgress();
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

    #region SetItemIcon
    private void SetItemIcon(List<ItemInfo> refList, Sprite[] btnIcons)
    {
        if (refList != null)
        {
            for (int i = 0; i < refList.Count; i++)
            {
                if (btnIcons.Length > i)
                {
                    if (btnIcons[i] && refList[i].itemIcon)
                    {
                        refList[i].itemIcon.sprite = btnIcons[i];
                    }
                }
            }
        }
    }
    #endregion

    #region SelectedCatagory
    private void DisableScrollers()
    {
        for (int i = 0; i < CatagoryImage.Length; i++)
        {
            CatagoryImage[i].sprite = CatagoryDefaultSprites;
        }
        uIElements.dressScroller.SetActive(false);
        uIElements.HandItemsScroller.SetActive(false);
        uIElements.HairBandScroller.SetActive(false);
        uIElements.hairScrolleer.SetActive(false);
        uIElements.BangelsScroller.SetActive(false);
        uIElements.shoeScroller.SetActive(false);
        uIElements.earRingScroller.SetActive(false);
        uIElements.EyeShadesScroller.SetActive(false);
        uIElements.lipstickScroller.SetActive(false);
        uIElements.necklaceScroller.SetActive(false);
        uIElements.EyeBrowScroller.SetActive(false);
        uIElements.BgScroller.SetActive(false);
        uIElements.BlushScroller.SetActive(false);
    }
    public void SelectedCatagory(int index)
    {

        DisableScrollers();
        if (CategorySFX) CategorySFX.Play();
        CatagoryImage[index].sprite = CatagorySelectedSprites;
        if (index == (int)RampSelectedItem.Dress)
        {
            selectedItem = RampSelectedItem.Dress;
            uIElements.dressScroller.SetActive(true);
            CharactorMover.Move(new Vector3(100, -150, 200), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.Hair)
        {
            selectedItem = RampSelectedItem.Hair;
            uIElements.hairScrolleer.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.Bangels)
        {
            selectedItem = RampSelectedItem.Bangels;
            uIElements.BangelsScroller.SetActive(true);
            CharactorMover.Move(new Vector3(100, -150, 200), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.HairBand)
        {
            selectedItem = RampSelectedItem.HairBand;
            uIElements.HairBandScroller.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.EarRings)
        {
            selectedItem = RampSelectedItem.EarRings;
            uIElements.earRingScroller.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.Blush)
        {
            selectedItem = RampSelectedItem.Blush;
            uIElements.BlushScroller.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.HandItems)
        {
            selectedItem = RampSelectedItem.HandItems;
            uIElements.HandItemsScroller.SetActive(true);
            CharactorMover.Move(new Vector3(100, -150, 200), 0.5f, true, false);

        }
        else if (index == (int)RampSelectedItem.EyeShades)
        {
            selectedItem = RampSelectedItem.EyeShades;
            uIElements.EyeShadesScroller.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.Lipstick)
        {
            selectedItem = RampSelectedItem.Lipstick;
            uIElements.lipstickScroller.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);

        }
        else if (index == (int)RampSelectedItem.NeckLace)
        {
            selectedItem = RampSelectedItem.NeckLace;
            uIElements.necklaceScroller.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);

        }
        else if (index == (int)RampSelectedItem.EyeBrow)
        {
            selectedItem = RampSelectedItem.EyeBrow;
            uIElements.EyeBrowScroller.SetActive(true);
            CharactorMover.Move(new Vector3(50, -450, -900), 0.5f, true, false);

        }
        else if (index == (int)RampSelectedItem.Shoes)
        {
            selectedItem = RampSelectedItem.Shoes;
            uIElements.shoeScroller.SetActive(true);
            CharactorMover.Move(new Vector3(100, -150, 200), 0.5f, true, false);
        }
        else if (index == (int)RampSelectedItem.BackGround)
        {
            selectedItem = RampSelectedItem.BackGround;
            uIElements.BgScroller.SetActive(true);
            CharactorMover.Move(new Vector3(100, -150, 200), 0.5f, true, false);

        }
        GetItemsInfo();
    }
    #endregion

    #region GetItemsInfo
    private void GetItemsInfo()
    {
        if (selectedItem == RampSelectedItem.Dress)
        {
            SetItemsInfo(dressList, DressScore);
        }
        else if (selectedItem == RampSelectedItem.HandItems)
        {
            SetItemsInfo(HandItemList, HandItemScore);
        }
        else if (selectedItem == RampSelectedItem.HairBand)
        {
            SetItemsInfo(HairBandList, HairBandScore);
        }
        else if (selectedItem == RampSelectedItem.Hair)
        {
            SetItemsInfo(hairList, HairScore);
        }
        else if (selectedItem == RampSelectedItem.Bangels)
        {
            SetItemsInfo(BangelsList, BangelsScore);
        }
        else if (selectedItem == RampSelectedItem.Shoes)
        {
            SetItemsInfo(ShoesList, ShoesScore);
        }
        else if (selectedItem == RampSelectedItem.EarRings)
        {
            SetItemsInfo(earRingsList, EarRingsScore);
        }
        else if (selectedItem == RampSelectedItem.EyeShades)
        {
            SetItemsInfo(EyeShadesList, EyeShadesScore);
        }     
        else if (selectedItem == RampSelectedItem.Lipstick)
        {
            SetItemsInfo(lipstickList, LipstickScore);
        }
        else if (selectedItem == RampSelectedItem.NeckLace)
        {
            SetItemsInfo(neckLaceList, NeckLaceScore);
        }
        else if (selectedItem == RampSelectedItem.BackGround)
        {
            SetItemsInfo(backgroundList, BGScore);
        }
        else if (selectedItem == RampSelectedItem.EyeBrow)
        {
            SetItemsInfo(EyeBrowList, EyeBrowScore);
        }
        else if (selectedItem == RampSelectedItem.Blush)
        {
            SetItemsInfo(BlushList, BlushScore);
        }

    }

    #endregion

    #region SetItemsInfo
    private void SetItemsInfo(List<ItemInfo> _ItemInfo, int[] ScoureArray)
    {
        if (_ItemInfo == null) return;
        for (int i = 0; i < _ItemInfo.Count; i++)
        {
            if (_ItemInfo[i].scoreText)
            {
                _ItemInfo[i].scoreText.text = ScoureArray[i].ToString();
            }
            if (_ItemInfo[i].isLocked)
            {
                _ItemInfo[i].LockIcon.SetActive(true);
                if (_ItemInfo[i].videoUnlock)
                {
                    if (_ItemInfo[i].VideoSlot)
                    {
                        _ItemInfo[i].VideoSlot.SetActive(true);
                    }
                    if (_ItemInfo[i].coinSlot)
                    {
                        _ItemInfo[i].coinSlot.SetActive(false);
                    }
                }
                else if (_ItemInfo[i].coinsUnlock)
                {
                    if (_ItemInfo[i].VideoSlot)
                    {
                        _ItemInfo[i].VideoSlot.SetActive(false);
                    }
                    if (_ItemInfo[i].coinSlot)
                    {
                        _ItemInfo[i].coinSlot.SetActive(true);
                        //if (_ItemInfo[i].unlockCoins)
                        //{
                        //    _ItemInfo[i].unlockCoins.text = _ItemInfo[i].requiredCoins.ToString();
                        //}
                    }
                }
            }
            else
            {
                _ItemInfo[i].LockIcon.SetActive(false);
                if (_ItemInfo[i].VideoSlot) _ItemInfo[i].VideoSlot.SetActive(false);
                if (_ItemInfo[i].coinSlot) _ItemInfo[i].coinSlot.SetActive(false);
            }
        }
    }
    #endregion

    #region SelectItem
    public void SelectItem(int index)
    {
        if (selectedItem == RampSelectedItem.Dress)
        {
            CheckSelectedItem(dressList, dressSprites, uIElements.dressImage);
        }
        else if (selectedItem == RampSelectedItem.HandItems)
        {
            CheckSelectedItem(HandItemList, HandItemSprites, uIElements.HandItemsImage);
        }
        else if (selectedItem == RampSelectedItem.HairBand)
        {
            CheckSelectedItem(HairBandList, HairBandSprites, uIElements.HairBandImage);
        }
        else if (selectedItem == RampSelectedItem.Hair)
        {
            CheckSelectedItem(hairList, hairSprites, uIElements.hairImage);
        }
        else if (selectedItem == RampSelectedItem.Bangels)
        {
            CheckSelectedItem(BangelsList, BangelsSprites, uIElements.BangelsImage);
        }
        else if (selectedItem == RampSelectedItem.Shoes)
        {
            CheckSelectedItem(ShoesList, ShoesSprites, uIElements.shoesImage);
        }
        else if (selectedItem == RampSelectedItem.EarRings)
        {
            CheckSelectedItem(earRingsList, earRingsSprites, uIElements.earRingsImage);
        }
        else if (selectedItem == RampSelectedItem.EyeShades)
        {
            CheckSelectedItem(EyeShadesList, EyeShadesSprites, uIElements.EyeShadesImage);
        }
        else if (selectedItem == RampSelectedItem.Lipstick)
        {
            CheckSelectedItem(lipstickList, lipsTickSprites, uIElements.lipstickImage);
        }
        else if (selectedItem == RampSelectedItem.NeckLace)
        {
            CheckSelectedItem(neckLaceList, necklaceSprites, uIElements.neckLaceImage);
        }
        else if (selectedItem == RampSelectedItem.EyeBrow)
        {
            CheckSelectedItem(EyeBrowList, EyeBrowSprites, uIElements.EyeBrowImage);
        }
        else if (selectedItem == RampSelectedItem.BackGround)
        {
            CheckSelectedItem(backgroundList, backgroundSprites, uIElements.BgImage);
        }
        else if (selectedItem == RampSelectedItem.Blush)
        {
            CheckSelectedItem(BlushList, BlushSprites, uIElements.BlushImage);
        }
        GetItemsInfo();
        TotalCoins.text = SaveData.Instance.Coins.ToString();


    }
    #endregion

    #region CheckSelectedItem
    private void CheckSelectedItem(List<ItemInfo> itemInfoList, Sprite[] itemSprites, Image itemImage)
    {
        rewardType = RewardType.SelectionItem;
        if (itemInfoList.Count > selectedIndex)
        {
            tempItem = itemInfoList[selectedIndex];
            if (itemInfoList[selectedIndex].isLocked)
            {
                oppElements.videoScore.text = oppElements.CoinScore.text = itemInfoList[selectedIndex].scoreText.text;
                oppElements.requirdCoins.text = itemInfoList[selectedIndex].requiredCoins.ToString();
                uIElements.videoSlotItem.sprite = uIElements.coinslotItem.sprite = itemInfoList[selectedIndex].itemIcon.sprite;
                if (itemInfoList[selectedIndex].videoUnlock)
                {
                    videoPanel.SetActive(true);
                }
                else if (itemInfoList[selectedIndex].coinsUnlock)
                {
                    coinPanel.SetActive(true);
                }
            }
            else
            {
                if (itemSprites.Length > selectedIndex)
                {
                    if (itemSprites[selectedIndex])
                    {
                        if (itemImage)
                        {
                            if (selectedItem == RampSelectedItem.Dress)
                            {
                                IsDressTrue = true;
                                dressValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.Hair)
                            {
                                hairValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                                IsHairTrue = true;
                            }
                            else if (selectedItem == RampSelectedItem.Bangels)
                            {
                                bangleValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                                IsBangleTrue = true;
                            }
                            else if (selectedItem == RampSelectedItem.NeckLace)
                            {
                                necklaceValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                                IsNecklacetrue = true;
                            }
                            else if (selectedItem == RampSelectedItem.HairBand)
                            {
                                BlushValue = 0;
                                HairBandValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.EarRings)
                            {
                                earringValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.HandItems)
                            {
                                HandItemValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.EyeShades)
                            {
                                eyeshadesValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.Lipstick)
                            {
                                lipstickValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.EyeBrow)
                            {
                                EyeBrowValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.Shoes)
                            {
                                shoeValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.BackGround)
                            {
                                bgValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            else if (selectedItem == RampSelectedItem.Blush)
                            {
                                HairBandValue = 0;
                                BlushValue = int.Parse(itemInfoList[selectedIndex].scoreText.text);
                            }
                            if(IsDressTrue == true && IsNecklacetrue == true && IsHairTrue == true && IsBangleTrue == true)
                            {
                                if (sheIsReady) sheIsReady.gameObject.SetActive(true);
                            }
                            if (itemSelectSFX) itemSelectSFX.Play();
                            for (int i = 0; i < itemInfoList.Count; i++)
                            {
                                itemInfoList[i].itemBtn.interactable = true;
                                if (itemInfoList[i].itemBtn)
                                {
                                    if (i == selectedIndex)
                                    {
                                        itemInfoList[i].itemBtn.GetComponent<Image>().sprite = selectionSelectedSprite;
                                    }
                                    else
                                    {
                                        itemInfoList[i].itemBtn.GetComponent<Image>().sprite = selectionDefaultSprite;
                                    }
                                }
                            }
                            itemInfoList[selectedIndex].itemBtn.interactable = false;
                            StartCoroutine(SoureParticalPlay(itemInfoList));
                            itemImage.gameObject.SetActive(false);
                            itemImage.gameObject.SetActive(true);
                            itemImage.sprite = itemSprites[selectedIndex];
                        }
                    }
                }
                CheckInterstitialAD();
            }
        }
    }
    #endregion

    IEnumerator SoureParticalPlay(List<ItemInfo> itemInfo)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject partical = Instantiate(scorePartical, itemInfo[selectedIndex].transform);
        partical.transform.parent = totalScore.transform;
        partical.SetActive(true);
        yield return new WaitForSeconds(1);
        totalScore.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        totalScore.transform.GetChild(0).GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        totalScore.text = (dressValue + hairValue + bangleValue + HairBandValue + earringValue + BlushValue + eyeshadesValue + lipstickValue + necklaceValue +
                            EyeBrowValue + shoeValue + bgValue + HandItemValue ).ToString();
    }
    #region Btnfunctions
    public void Play(string str)
    {
        StartCoroutine(ShowInterStitial());
        StartCoroutine(LoadingScene(str));
    } 

    public void Submit()
    {
        StartCoroutine(ShowInterStitial());
        topBar.SetActive(false);
        uIElements.aLLScrollers.SetActive(false);
        sheIsReady.SetActive(false);
        JudgementPanel.SetActive(true);
        OpponentMover.gameObject.SetActive(true);
        CharactorMover.Move(new Vector3(-250, -150, 0), 0.5f, true, false);
        OpponentMover.Move(new Vector3(250, -150, 0), 0.5f, true, false);
        CharactorMover.transform.localScale = new Vector3(1, 1, 1);
        CharactorMover.transform.localScale = new Vector3(-1, 1, 1);
        DressUpOpponent();
        SaveData.instance.LevelsUnlocked++;
        StartCoroutine(StartComparing());

    }
    #endregion

    #region GetRewardedCoins
    public void NeedMoreCoins()
    {
        rewardType = RewardType.Coins;
        needMoreCoins.SetActive(true);
    }
    public void GetRewardedCoins()
    {
        rewardType = RewardType.Coins;
        CheckVideoStatus();
    }
    #endregion

    #region IEnumerator
    IEnumerator AddCoins(float delay , int Coins)
    {
        yield return new WaitForSeconds(delay);
        if (coinsAdder)
        {
            coinsAdder.addCoins = Coins;
            coinsAdder.addNow = true;
        }
    }
    IEnumerator FinalAddCoins(float delay , int Coins)
    {
        yield return new WaitForSeconds(delay);
        if (FinalcoinsAdder)
        {
            FinalcoinsAdder.addCoins = Coins;
            FinalcoinsAdder.addNow = true;
        }
    }

    IEnumerator LoadingScene(string str)
    {
        LoadingPanel.SetActive(true);
        fillBar.fillAmount = 0;
        while (fillBar.fillAmount < 1)
        {
            fillBar.fillAmount += Time.deltaTime / 4;
            yield return null;
        }
        SceneManager.LoadScene(str);
    }
    #endregion

    #region UnlockSingleItem
    public void UnlockSingleItem()
    {
        if (selectedItem == RampSelectedItem.Dress)
        {
            SaveData.Instance.indianProps.dressLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.HandItems)
        {
            SaveData.Instance.indianProps.bagLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.HairBand)
        {
            SaveData.Instance.indianProps.hairbandLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.Hair)
        {
            SaveData.Instance.indianProps.hairLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.Bangels)
        {
            SaveData.Instance.indianProps.bangelsLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.Shoes)
        {
            SaveData.Instance.indianProps.shoesLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.EarRings)
        {
            SaveData.Instance.indianProps.earRingLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.EyeShades)
        {
            SaveData.Instance.indianProps.eyeShadesLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.Lipstick)
        {
            SaveData.Instance.indianProps.lipsTickLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.NeckLace)
        {
            SaveData.Instance.indianProps.necklaceLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.EyeBrow)
        {
            SaveData.Instance.indianProps.noseRingLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.BackGround)
        {
            SaveData.Instance.indianProps.BGLocked[selectedIndex] = false;
        }
        else if (selectedItem == RampSelectedItem.Blush)
        {
            SaveData.Instance.indianProps.BlushLocked[selectedIndex] = false;
        }
        Rai_SaveLoad.SaveProgress();
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
                Invoke("videoPanelOf", 1.3f);
        //    }
        //}
        //else
        //{
        //    uIElements.videoNotAvalible.SetActive(true);
        //    Invoke("videoPanelOf", 1.3f);
        //}
    }
    #endregion

    #region RewardedVideoCompleted
    public void OnRewardedVideoComplete()
    {

        if (canShowInterstitial)
        {
            canShowInterstitial = !canShowInterstitial;
            StartCoroutine(AdDelay(10));
        }
        if (rewardType == RewardType.SelectionItem)
        {
            if (tempItem != null) tempItem.isLocked = false;
            UnlockSingleItem();
            SelectItem(selectedIndex);
        }
        else if (rewardType == RewardType.Coins)
        {
            SaveData.Instance.Coins += 2000;
            TotalCoins.text = SaveData.Instance.Coins.ToString();
            Rai_SaveLoad.SaveProgress();
        }
        GetItemsInfo();
        videoPanel.SetActive(false);
        needMoreCoins.SetActive(false);
        rewardType = RewardType.none;
        if (purchaseSFX) purchaseSFX.Play();
    }
    #endregion
    public void videoPanelOf()
    {
        videoNotAvalible.SetActive(false);
    }
    #region CoinUnlocks
    public void CoinUnlock()
    {
        if (selectedItem == RampSelectedItem.Dress)
        {
            CheckCoinUnlock(dressList);
        }
        else if (selectedItem == RampSelectedItem.HandItems)
        {
            CheckCoinUnlock(HandItemList);
        }
        else if (selectedItem == RampSelectedItem.HairBand)
        {
            CheckCoinUnlock(HairBandList);
        }
        else if (selectedItem == RampSelectedItem.Hair)
        {
            CheckCoinUnlock(hairList);
        }
        else if (selectedItem == RampSelectedItem.Bangels)
        {
            CheckCoinUnlock(BangelsList);
        }
        else if (selectedItem == RampSelectedItem.Shoes)
        {
            CheckCoinUnlock(ShoesList);
        }
        else if (selectedItem == RampSelectedItem.EarRings)
        {
            CheckCoinUnlock(earRingsList);
        }
        else if (selectedItem == RampSelectedItem.EyeShades)
        {
            CheckCoinUnlock(EyeShadesList);
        }
        else if (selectedItem == RampSelectedItem.Lipstick)
        {
            CheckCoinUnlock(lipstickList);
        }
        else if (selectedItem == RampSelectedItem.NeckLace)
        {
            CheckCoinUnlock(neckLaceList);
        }
        else if (selectedItem == RampSelectedItem.EyeBrow)
        {
            CheckCoinUnlock(EyeBrowList);
        }
        else if (selectedItem == RampSelectedItem.BackGround)
        {
            CheckCoinUnlock(backgroundList);
        }
        else if (selectedItem == RampSelectedItem.Blush)
        {
            CheckCoinUnlock(BlushList);
        }
    }
    public void CheckCoinUnlock(List<ItemInfo> itemInfoList)
    {
        if (itemInfoList[selectedIndex].coinsUnlock)
        {
            if (SaveData.Instance.Coins >= itemInfoList[selectedIndex].requiredCoins)
            {
                itemInfoList[selectedIndex].isLocked = false;
                SaveData.Instance.Coins -= itemInfoList[selectedIndex].requiredCoins;
                Rai_SaveLoad.SaveProgress();
                UnlockSingleItem();
                if (purchaseSFX) purchaseSFX.Play();
                coinPanel.SetActive(false);
                SelectItem(selectedIndex);
            }
            else
            {
                if (needMoreCoins)
                    needMoreCoins.SetActive(true);
            }
        }
    }
#endregion

    //public void //ShowAd()
    //{
    //    if (ADTime)
    //    {
    //        StartCoroutine(AdDelay());
    //        ADTime = false;
    //        StartCoroutine(ADTimeCounter());
    //    }
    //}
    IEnumerator ADTimeCounter()
    {
        yield return new WaitForSeconds(45);
        ADTime = true;
    }

    #region ShowInterstitialAD
    private void CheckInterstitialAD()
    {
        //if (MyAdsManager.Instance != null)
        //{
        //    Debug.Log("ffff");
        //    if (MyAdsManager.Instance.IsInterstitialAvailable() && canShowInterstitial)
        //    {
        //        canShowInterstitial = !canShowInterstitial;
        //        StartCoroutine(AdDelay(45));
        //        StartCoroutine(ShowInterstitialAD());
        //    }
        //}
    }
    IEnumerator ShowInterstitialAD()
    {
        if (AdPenl)
        {
            AdPenl.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            AdPenl.SetActive(false);
        }
     //   MyAdsManager.Instance.ShowInterstitialAds();
    }
    IEnumerator AdDelay(float _Delay)
    {
        yield return new WaitForSeconds(_Delay);
        canShowInterstitial = !canShowInterstitial;
    }
    #endregion

    //IEnumerator AdDelay()
    //{
    //    if (MyAdsManager.instance)
    //    {
    //        if (MyAdsManager.instance.IsInterstitalLoaded())
    //        {
    //            uIElements.AdPenl.gameObject.SetActive(true);
    //            yield return new WaitForSecondsRealtime(1);
    //            uIElements.AdPenl.gameObject.SetActive(false);
    //            ShowInterStitial();
    //        }
    //    }
    //}

    #region DressOpponent
    private void DressUpOpponent()
    {
        int randomIndex = 0;
        if (dressValue > 1)
        {
            randomIndex = Random.Range(0, dressList.Count);
            if (dressList[randomIndex] && oppElements.oppodressImage)
            {
                oppElements.oppodressImage.gameObject.SetActive(true);
                oppElements.oppodressImage.sprite = dressSprites[randomIndex];
                oppodressValue = int.Parse(dressList[randomIndex].scoreText.text);
            }
        }
        if (hairValue > 1)
        {
            randomIndex = Random.Range(0, hairList.Count);
            if (hairList[randomIndex] && oppElements.oppohairImage)
            {
                oppElements.oppohairImage.gameObject.SetActive(true);
                oppElements.oppohairImage.sprite = hairSprites[randomIndex];
                oppohairValue = int.Parse(hairList[randomIndex].scoreText.text);
            }
        }
        if (bangleValue > 1)
        {
            randomIndex = Random.Range(0, BangelsList.Count);
            if (BangelsList[randomIndex] && oppElements.oppobangelImage)
            {
                oppElements.oppobangelImage.gameObject.SetActive(true);
                oppElements.oppobangelImage.sprite = BangelsSprites[randomIndex];
                oppobangleValue = int.Parse(BangelsList[randomIndex].scoreText.text);
            }
        }
        if (HairBandValue > 1)
        {
            randomIndex = Random.Range(0, HairBandList.Count);
            if (HairBandList[randomIndex] && oppElements.oppoHairBandImage)
            {
                oppElements.oppoHairBandImage.gameObject.SetActive(true);
                oppElements.oppoHairBandImage.sprite = HairBandSprites[randomIndex];
                HairBandValue = int.Parse(HairBandList[randomIndex].scoreText.text);
            }
        }
        if (earringValue > 1)
        {
            randomIndex = Random.Range(0, earRingsList.Count);
            if (earRingsList[randomIndex] && oppElements.oppoearRingImage)
            {
                oppElements.oppoearRingImage.gameObject.SetActive(true);
                oppElements.oppoearRingImage.sprite = earRingsSprites[randomIndex];
                oppoearringValue = int.Parse(earRingsList[randomIndex].scoreText.text);
            }
        }
        if (BlushValue > 1)
        {
            randomIndex = Random.Range(0, BlushList.Count);
            if (BlushList[randomIndex] && oppElements.oppoBlushImage)
            {
                oppElements.oppoBlushImage.gameObject.SetActive(true);
                oppElements.oppoBlushImage.sprite = BlushSprites[randomIndex];
                oppoBlushValue = int.Parse(BlushList[randomIndex].scoreText.text);
            }
            }
        if (eyeshadesValue > 1)
        {
            randomIndex = Random.Range(0, EyeShadesList.Count);
            if (EyeShadesList[randomIndex] && oppElements.oppoeyeShadesImage)
            {
                oppElements.oppoeyeShadesImage.gameObject.SetActive(true);
                oppElements.oppoeyeShadesImage.sprite = EyeShadesSprites[randomIndex];
                oppoeyeshadesValue = int.Parse(EyeShadesList[randomIndex].scoreText.text);
            }
        }
        if (lipstickValue > 1)
        {
            randomIndex = Random.Range(0, lipstickList.Count);
            if (lipstickList[randomIndex] && oppElements.oppolipstickImage)
            {
                oppElements.oppolipstickImage.gameObject.SetActive(true);
                oppElements.oppolipstickImage.sprite = lipsTickSprites[randomIndex];
                oppolipstickValue = int.Parse(lipstickList[randomIndex].scoreText.text);
            }
        }
        if (necklaceValue > 1)
        {
            randomIndex = Random.Range(0, neckLaceList.Count);
            if (neckLaceList[randomIndex] && oppElements.opponeckLaceImage)
            {
                oppElements.opponeckLaceImage.gameObject.SetActive(true);
                oppElements.opponeckLaceImage.sprite = necklaceSprites[randomIndex];
                opponecklaceValue = int.Parse(neckLaceList[randomIndex].scoreText.text);
            }
        }
        if (EyeBrowValue > 1)
        {
            randomIndex = Random.Range(0, EyeBrowList.Count);
            if (EyeBrowList[randomIndex] && oppElements.oppoEyeBrowImage)
            {
                oppElements.oppoEyeBrowImage.gameObject.SetActive(true);
                oppElements.oppoEyeBrowImage.sprite = EyeBrowSprites[randomIndex];
                oppoEyeBrowValue = int.Parse(EyeBrowList[randomIndex].scoreText.text);
            }
        }
        if (shoeValue > 1)
        {
            randomIndex = Random.Range(0, ShoesList.Count);
            if (ShoesList[randomIndex] && oppElements.opposhoesImage)
            {
                oppElements.opposhoesImage.gameObject.SetActive(true);
                oppElements.opposhoesImage.sprite = ShoesSprites[randomIndex];
                opposhoeValue = int.Parse(ShoesList[randomIndex].scoreText.text);
            }
        }
        if (HandItemValue > 1)
        {
            randomIndex = Random.Range(0, HandItemList.Count);
            if (HandItemList[randomIndex] && oppElements.oppoHandItemsImage)
            {
                oppElements.oppoHandItemsImage.gameObject.SetActive(true);
                oppElements.oppoHandItemsImage.sprite = HandItemSprites[randomIndex];
                oppoHandItemValue = int.Parse(HandItemList[randomIndex].scoreText.text);
            }
        }
    }
    #endregion

    IEnumerator scoreImage(Image img)
    {
        img.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        img.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        img.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
        yield return new WaitForSeconds(0.5f);
        img.transform.GetChild(0).gameObject.SetActive(false);
    }
    IEnumerator StartComparing()
    {
        int playerRank = 0;
        int oppoRank = 0;
        int playerTotal = 0, opTotal = 0;
        yield return new WaitForSeconds(0.5f);
        if (dressValue > 1) StartCoroutine(scoreImage(uIElements.dressImage));
        yield return new WaitForSeconds(0.5f);
        if (shoeValue > 1) StartCoroutine(scoreImage(uIElements.shoesImage));
        yield return new WaitForSeconds(0.5f);
        if (hairValue > 1) StartCoroutine(scoreImage(uIElements.hairImage));
        yield return new WaitForSeconds(0.5f);
        playerRank = dressValue + shoeValue + bgValue  + hairValue ;
        playerTotal += playerRank;
        oppElements.playerTotal.text = playerTotal.ToString();
        yield return new WaitForSeconds(0.5f);
        if (oppodressValue > 1) StartCoroutine(scoreImage(oppElements.oppodressImage));
        yield return new WaitForSeconds(0.5f);
        if (opposhoeValue > 1) StartCoroutine(scoreImage(oppElements.opposhoesImage));
        yield return new WaitForSeconds(0.5f);
        if (oppohairValue > 1) StartCoroutine(scoreImage(oppElements.oppohairImage));
        yield return new WaitForSeconds(0.5f);
        oppoRank = oppodressValue + opposhoeValue + oppohairValue;
        opTotal += oppoRank;
        oppElements.oppoTotal.text = opTotal.ToString();
        yield return new WaitForSeconds(0.5f);
        if (BlushValue > 1) StartCoroutine(scoreImage(uIElements.BlushImage));
        if (EyeBrowValue > 1) StartCoroutine(scoreImage(uIElements.EyeBrowImage));
        if (eyeshadesValue > 1) StartCoroutine(scoreImage(uIElements.EyeShadesImage));
        if (lipstickValue > 1) StartCoroutine(scoreImage(uIElements.lipstickImage));
        yield return new WaitForSeconds(0.5f);
        playerRank = eyeshadesValue + lipstickValue + EyeBrowValue + BlushValue;
        playerTotal += playerRank;
        oppElements.playerTotal.text = playerTotal.ToString();
        yield return new WaitForSeconds(0.5f);
        if (oppoBlushValue > 1) StartCoroutine(scoreImage(oppElements.oppoBlushImage));
        if (oppoEyeBrowValue > 1) StartCoroutine(scoreImage(oppElements.oppoEyeBrowImage));
        if (oppoeyeshadesValue > 1) StartCoroutine(scoreImage(oppElements.oppoeyeShadesImage));
        if (oppolipstickValue > 1) StartCoroutine(scoreImage(oppElements.oppolipstickImage));
        yield return new WaitForSeconds(0.5f);
        oppoRank = oppoeyeshadesValue + oppolipstickValue + oppoEyeBrowValue + oppoBlushValue;
        opTotal += oppoRank;
        oppElements.oppoTotal.text = opTotal.ToString();
        yield return new WaitForSeconds(0.5f);
        if (HairBandValue > 1) StartCoroutine(scoreImage(uIElements.HairBandImage));
        if (HandItemValue > 1) StartCoroutine(scoreImage(uIElements.HandItemsImage));
        if (bangleValue > 1) StartCoroutine(scoreImage(uIElements.BangelsImage));
        if (earringValue > 1) StartCoroutine(scoreImage(uIElements.earRingsImage));
        if (necklaceValue > 1) StartCoroutine(scoreImage(uIElements.neckLaceImage));
        yield return new WaitForSeconds(0.5f);
        playerRank = bangleValue + earringValue + necklaceValue + HandItemValue + HairBandValue ;
        playerTotal += playerRank;
        oppElements.playerTotal.text = playerTotal.ToString();
        yield return new WaitForSeconds(0.5f);
        if (oppoHandItemValue > 1) StartCoroutine(scoreImage(oppElements.oppoHandItemsImage));
        if (oppoHairBandValue > 1) StartCoroutine(scoreImage(oppElements.oppoHairBandImage));
        if (oppobangleValue > 1) StartCoroutine(scoreImage(oppElements.oppobangelImage));
        if (oppoearringValue > 1) StartCoroutine(scoreImage(oppElements.oppoearRingImage));
        if (opponecklaceValue > 1) StartCoroutine(scoreImage(oppElements.opponeckLaceImage));
        yield return new WaitForSeconds(0.5f);
        oppoRank = oppobangleValue + oppoearringValue + opponecklaceValue + oppoHairBandValue + oppoHandItemValue;
        opTotal += oppoRank;
        oppElements.oppoTotal.text = opTotal.ToString();
        yield return new WaitForSeconds(3);
        if (playerTotal >= opTotal)
        {
            //player win
            Wincoin = playerTotal / 100;
            if (winSFX) winSFX.Play();
            yield return new WaitForSeconds(1f);
            CharactorMover.transform.SetSiblingIndex(-1);
            JudgementPanel.SetActive(false);
            yield return new WaitForSeconds(1f);
            OpponentMover.Move(new Vector3(1500, -150, 0), 0.5f, true, false);
            yield return new WaitForSeconds(0.3f);
            CharactorMover.Move(new Vector3(0, -150, 0), 0.5f, true, false);
            yield return new WaitForSeconds(1f);
            Confetti.gameObject.SetActive(true);
            WinnerPanel.SetActive(true);
            StartCoroutine(FinalAddCoins(0.5f,2000));
            yield return new WaitForSeconds(2);
            LevelComplete.SetActive(true);
            yield return new WaitForSeconds(1);
            WinnerPanel.transform.GetChild(0).gameObject.SetActive(false);
            Rai_SaveLoad.SaveProgress();
        }
        else
        {
            //oppoWin
            if (LoseSFX) LoseSFX.Play();
            Wincoin = opTotal / 200;
            yield return new WaitForSeconds(1f);
            OpponentMover.transform.SetSiblingIndex(-1);
            JudgementPanel.SetActive(false);
            yield return new WaitForSeconds(1f);
            CharactorMover.Move(new Vector3(-1500, -150, 0), 0.5f, true, false);
            yield return new WaitForSeconds(0.3f);
            OpponentMover.Move(new Vector3(0, -150, 0), 0.5f, true, false);
            yield return new WaitForSeconds(1f);
            LevelComplete.SetActive(true);
            WinnerPanel.transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
        }
    }

}

