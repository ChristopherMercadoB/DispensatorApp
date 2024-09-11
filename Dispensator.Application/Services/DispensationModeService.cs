using DispensatorApp.Database.Enums;
using DispensatorApp.Database.Repositories;
using DispensatorApp.Database.ViewModel;
using System;
using System.Collections.Generic;


namespace DispensatorApp.Application.Services
{
    public class DispensationModeService
    {
        public DispensationQuantitiesViewModel viewModel { get; set; } = new();
        private readonly DispensationModeRepository _repository;
        public DispensationModeService(DispensationModeRepository repository) 
        { 
            _repository = repository;
        }

        public void Add(DispensationModeViewModel vm)
        {
            _repository.Add(vm);
        }

        public DispensationModeViewModel GetEntityFromJson()
        {
            var entity = _repository.GetEntity();
            return entity;
        }

        public DispensationQuantitiesViewModel Dispensate(DispensationModeViewModel vm)
        {
            int? MoneyQuantity = vm.MoneyQuantity;
            switch (vm.DispensationMode)
            {
                case (int)DispensationMode.From200To1000:
                    int? QuantityOf1000 = MoneyQuantity / 1000;
                    int? QuatityOf200 = MoneyQuantity < 1000 ? MoneyQuantity/200 : (MoneyQuantity % 1000) / 200;
                    DispensationQuantitiesViewModel newVmFrom200 = new DispensationQuantitiesViewModel
                    {
                        DispensationMode = vm.DispensationMode,
                        Amount = vm.MoneyQuantity,
                        QuantityOf1000 = QuantityOf1000,
                        QuatityOf200 = QuatityOf200,
                    };

                    return newVmFrom200;

                case (int)DispensationMode.From100To500:
                    DispensationQuantitiesViewModel newVmFrom100 = new DispensationQuantitiesViewModel
                    {
                        DispensationMode = vm.DispensationMode,
                        Amount = vm.MoneyQuantity,
                        QuatityOf500 = vm.MoneyQuantity / 500,
                        QuatityOf100 = vm.MoneyQuantity < 500 ? vm.MoneyQuantity / 100 : (vm.MoneyQuantity % 500) / 100,
                    };
                    return newVmFrom100;

                case (int)DispensationMode.EfficientMode:
                    int? quantityOf1000 = vm.MoneyQuantity / 1000;
                    int? RestOf1000 = vm.MoneyQuantity - (quantityOf1000 * 1000);
                    int? quantityOf500 = RestOf1000 / 500;
                    int? restOf500 = RestOf1000 - (quantityOf500 * 500);
                    int? quantityOf200 = (RestOf1000 % 500) / 200;
                    int? quantityOf100 = vm.MoneyQuantity < 500 ? restOf500 / 100 :  (restOf500 % 200) / 100;
                    DispensationQuantitiesViewModel newVmEfficient = new DispensationQuantitiesViewModel
                    {
                        DispensationMode = vm.DispensationMode,
                        Amount = vm.MoneyQuantity,
                        QuantityOf1000 = quantityOf1000,
                        QuatityOf500 = quantityOf500,
                        QuatityOf200 = quantityOf200,
                        QuatityOf100 = quantityOf100,
                    };

                    return newVmEfficient;

                default:
                    return null;
            }
        }

        }
    }

