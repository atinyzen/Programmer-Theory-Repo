using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider _energySlider, _funSlider, _healthSlider, _hungerSlider;
    [SerializeField] private PetManager _petManager;
    [SerializeField] private GameObject _inventory;
    public GameObject descriptionPrefab;

    // maybe just take the NeedsController from the PetManager ?? it works :)
    private NeedsController _needsController;

    public void Sleep()
    {
        _petManager.Sleep();
        _needsController.ChangeTickRate("energy");
    }

    public void ToggleInventory()
    {
        if (_inventory.activeInHierarchy) _inventory.SetActive(false);
        else _inventory.SetActive(true);
    }

    private void Awake()
    {
        _needsController = _petManager.GetComponent<NeedsController>();
    }

    // Update is called once per frame
    void Update()
    {
        _energySlider.value = _needsController.Energy;
        _funSlider.value = _needsController.Fun;
        _healthSlider.value = _needsController.Health;
        _hungerSlider.value = _needsController.Hunger;
    }
}