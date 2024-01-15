using Ats.Domain.Library.Entities;
using BodyShopAI.Domain.Enumerators;
using BodyShopAI.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace BodyShopAI.Domain.Entities
{
    [Serializable]
    public class Car : BaseEntity
    {
        #region Properties
        public Guid IdCar { get; private set; }
        public string Model { get; private set; }
        public string Brand { get; private set; }
        public Guid IdUser { get; private set; }
        public Guid IdBudget { get; private set; }
        public User User { get; private set; }
        public List<Budget> Budgets { get; private set; }
        public string Plate { get; private set; }
        public DateTime InsertDate { get; private set; }
        public DateTime? ModifyDate { get; private set; }
        public byte IdStatus { get; private set; }
        #endregion

        public static Car CreateCar(string model, string brand, Guid idUser, string plate)
                            => new Car(model, brand, idUser, plate);

        protected Car(string model, string brand, Guid idUser, string plate)
        {
            IdCar = Guid.NewGuid();
            SetModelAndBrand(model, brand);
            Plate = plate.Trim();
            IdStatus = (byte)Status.Active;
            InsertDate = DateTimeBrasil.Now;
        }

        public void Update(string model, string brand, string plate)
        {
            UpdateCar(model, brand, plate);
            ModifyDate = DateTimeBrasil.Now;

        }

        public void Delete()
        {
            IdStatus = (byte)Status.Deleted;
            ModifyDate = DateTimeBrasil.Now;
        }

        #region Private Methods
        private void SetModelAndBrand(string model, string brand)
        {
            if (model.IsNullOrWhiteSpace())
                return;

            if (brand.IsNullOrWhiteSpace())
                return;

            Model = model.Trim();
            Brand = brand.Trim();
        }

        private void UpdateCar(string model, string brand, string plate)
        {
            if (Model == model)
                return;

            if (Brand == brand)
                return;

            if (Plate == plate)
                return;

            Model = model.Trim();
            Brand = brand.Trim();
            Plate = plate.Trim();
        }
        #endregion
    }
}
