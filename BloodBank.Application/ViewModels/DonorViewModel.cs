using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.ViewModels
{
    public class DonorViewModel
    {
        public DonorViewModel(string fullName, string email,
            int age, 
            DateTime birthDate,
            string gender, double weight, 
            EBloodType bloodType,
            ERhFactor rhFactor)
        {
            FullName = fullName;
            Email = email;
            Age = age;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public EBloodType BloodType { get; private set; }
        public ERhFactor RhFactor { get; private set; }
    }
}
