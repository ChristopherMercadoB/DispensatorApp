using DispensatorApp.Database.Enums;
using DispensatorApp.Database.Repositories;
using DispensatorApp.Database.ViewModel;
using System;
using System.Collections.Generic;


namespace DispensatorApp.Application.Services
{
    public class DispensationQuantitiesService
    {
        private readonly DispensationQuantitiesRepository _repository;
        public DispensationQuantitiesService(DispensationQuantitiesRepository repository)
        {
            _repository = repository;
        }

        public void Add(DispensationQuantitiesViewModel vm)
        {
            _repository.Add(vm);
        }

        public DispensationQuantitiesViewModel GetEntityFromJson()
        {
            var entity = _repository.GetEntity();
            return entity;
        }

    }
}
