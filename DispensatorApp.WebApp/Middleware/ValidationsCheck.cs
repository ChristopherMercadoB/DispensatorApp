using DispensatorApp.Database.Enums;
using DispensatorApp.Database.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DispensatorApp.WebApp.Middleware
{
    public class ValidationsCheck
    {
        private readonly ModelStateDictionary _modelStateDictionary;
        public ValidationsCheck(ModelStateDictionary state)
        {
            _modelStateDictionary = state;
        }

        public void checkValidation(DispensationModeViewModel vm)
        {
            switch (vm.DispensationMode)
            {
                case (int)DispensationMode.From200To1000:
                    if (vm.MoneyQuantity % 200 != 0)
                    {
                        _modelStateDictionary.AddModelError("dispensationValidation", "Este modo solo retira billetes de 200 y 1000");
                    }
                    break;
                case (int)DispensationMode.From100To500:
                    if (vm.MoneyQuantity % 100 != 0)
                    {
                        _modelStateDictionary.AddModelError("dispensationValidation", "Este modo solo retira billetes de 100 y 500");
                    }
                    else
                    {
                    }
                    break;
                case (int)DispensationMode.EfficientMode:
                    if (vm.MoneyQuantity % 100 != 0)
                    {
                        _modelStateDictionary.AddModelError("dispensationValidation", "Este modo solo retira billetes de 100, 200, 500 y 1000");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
