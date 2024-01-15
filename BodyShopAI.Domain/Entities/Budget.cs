using Ats.Domain.Library.Entities;
using BodyShopAI.Domain.Enumerators;
using BodyShopAI.Domain.Helpers;
using System;

namespace BodyShopAI.Domain.Entities
{
    public class Budget : BaseEntity
    {
        public Guid IdBudget { get; private set; }
        public Guid IdCar { get;private set; }
        public Guid? IdUser { get; private set; }
        public User User { get; private set; }
        public Car CarTarget { get; private set; }
        public decimal BudgetValue { get; private set; }
        public string Description { get; private set; }
        public byte IdStatus { get; private set; }
        public DateTime InsertDate { get; private set; }
        public DateTime? ModifyDate { get; private set; }

        public static Budget CreateBudget(Guid idCar, Guid? idUser, decimal budgetValue, string description) => new Budget(idCar, idUser, budgetValue, description);

        protected Budget(Guid idCar, Guid? idUser, decimal budgetValue, string description)
        {
            IdBudget = Guid.NewGuid();
            IdCar = idCar;
            IdUser = idUser;
            BudgetValue = budgetValue;
            Description = description.Trim();
            IdStatus = (byte)Status.Active;
            InsertDate = DateTimeBrasil.Now;
        }

        public void Update(decimal budgetValue, string description)
        {
            BudgetValue = budgetValue;
            Description = description;
            ModifyDate = DateTimeBrasil.Now;
        }

        public void Delete()
        {
            IdStatus = (byte)Status.Deleted;
            ModifyDate = DateTimeBrasil.Now;
        }
    }
}

