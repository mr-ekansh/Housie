using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using GooglePlayGames;


public class IAPManager : MonoBehaviour, IStoreListener
{
    //public GameObject PurchaseFailedPanel;
    public static IAPManager instance;
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;
    //Step 1 create your products
    private string coin100 = "100coins";
    private string coin250 = "250coins";
    private string coin500 = "500coins";
    private string ruby20 = "20rubies";
    private string ruby60 = "60rubies";
    private string ruby120 = "120rubies";
    private MainMenuManager _mainmanager;
    private NakamaTest _nakama;

    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        ConfigurationBuilder builder;
        builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(coin100, ProductType.Consumable);
        builder.AddProduct(coin250, ProductType.Consumable);
        builder.AddProduct(coin500, ProductType.Consumable);
        builder.AddProduct(ruby20, ProductType.Consumable);
        builder.AddProduct(ruby60, ProductType.Consumable);
        builder.AddProduct(ruby120, ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder);
    }
    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }
    //Step 3 Create methods
    public void Buy100coins()
    {
        BuyProductID(coin100);
    }
    public void Buy250coins()
    {
        BuyProductID(coin250);
    }
    public void Buy500coins()
    {
        BuyProductID(coin500);
    }
    public void Buy20rubies()
    {
        Debug.Log("Buy Rubies");
        BuyProductID(ruby20);
    }
    public void Buy60rubies()
    {
        BuyProductID(ruby60);
    }
    public void Buy120rubies()
    {
        BuyProductID(ruby120);
    }

    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, coin100, StringComparison.Ordinal))
        {
            _mainmanager.coins = _mainmanager.coins + 1000;
            _mainmanager.cointext.text = _mainmanager.coins.ToString();
            StartCoroutine(_mainmanager.UpdateCurrency(_nakama.USERID, _mainmanager.coins));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin250, StringComparison.Ordinal))
        {
            _mainmanager.coins = _mainmanager.coins + 2500;
            _mainmanager.cointext.text = _mainmanager.coins.ToString();
            StartCoroutine(_mainmanager.UpdateCurrency(_nakama.USERID, _mainmanager.coins));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin500, StringComparison.Ordinal))
        {
            _mainmanager.coins = _mainmanager.coins + 6000;
            _mainmanager.cointext.text = _mainmanager.coins.ToString();
            StartCoroutine(_mainmanager.UpdateCurrency(_nakama.USERID, _mainmanager.coins));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, ruby20, StringComparison.Ordinal))
        {
            _mainmanager.rubies = _mainmanager.rubies + 20;
            _mainmanager.rubytext.text = _mainmanager.rubies.ToString();
            StartCoroutine(_mainmanager.UpdateRubyCurrency(_nakama.USERID, _mainmanager.rubies));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, ruby60, StringComparison.Ordinal))
        {
            _mainmanager.rubies = _mainmanager.rubies + 60;
            _mainmanager.rubytext.text = _mainmanager.rubies.ToString();
            StartCoroutine(_mainmanager.UpdateRubyCurrency(_nakama.USERID, _mainmanager.rubies));
        }
        else if (String.Equals(args.purchasedProduct.definition.id, ruby120, StringComparison.Ordinal))
        {
            _mainmanager.rubies = _mainmanager.rubies + 120;
            _mainmanager.rubytext.text = _mainmanager.rubies.ToString();
            StartCoroutine(_mainmanager.UpdateRubyCurrency(_nakama.USERID, _mainmanager.rubies));
        }
        else
        {
            //PurchaseFailedPanel.SetActive(true);
        }
        return PurchaseProcessingResult.Complete;
    }
    public void RestoreGooglePurchase()
    {
    }
    private void Awake()
    {
        TestSingleton();
        _nakama = GameObject.FindWithTag("MainMenuManager").GetComponent<NakamaTest>();
        _mainmanager = GameObject.FindWithTag("MainMenuManager").GetComponent<MainMenuManager>();
    }
    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                m_StoreController.InitiatePurchase(product);
            }
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
            });
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
    }
    public void OkButton()
    {
    }
}