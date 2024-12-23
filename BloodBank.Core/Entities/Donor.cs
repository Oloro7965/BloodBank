﻿using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BloodBank.Core.Entities
{
    public class Donor:BaseEntity
    {
        public Donor(string fullName, string email, DateTime birthDate, EGender gender, double weight, EBloodType bloodType, ERhFactor rhFactor)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Age = CalculateAge(birthDate);
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Donations=new List<Donation>();
            IsDeleted = false;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public DateTime BirthDate { get; private set; }
        public EGender Gender { get;private set; }
        public double Weight { get; private set; }
        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
        public List<Donation> Donations { get; private set; }
        public Address? address { get; private set; }
        public Guid AddressId { get;private set; }
        public bool IsDeleted { get; private set; }
        public int CalculateAge(DateTime birthdate)
        {
            var today = DateTime.Now;
            var idade = today.Year - birthdate.Year;

            // Verifica se o aniversário já passou este ano
            if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
            {
                idade--;
            }

            return idade;
        }
        public bool ValidateIntervalDays(DateTime? date)
        {
            if (date is null)
            {
                return true;
            }
            else
            {
                TimeSpan Interval = DateTime.Now - date.Value;
                if (this.Gender == EGender.M)
                {
                    if (Interval.Days >= 60)
                    {
                        return true;
                    }
                    else
                    {
                        //throw new InvalidOperationException
                         //   ("intervalo de tempo de doações para o gênero masculino não pode ser inferior a 60 dias");
                         return false;
                    }
                }
                else
                {
                    if (Interval.Days >= 90)
                    {
                        return true;
                    }
                    else
                    {
                        // throw new InvalidOperationException
                        //     ("intervalo de tempo de doações para o gênero feminino não pode ser inferior a 90 dias");
                        return false;
                    }
                }
            }
           
        }
        public void Delete()
        {
            this.IsDeleted=true;
        }
    }
}
