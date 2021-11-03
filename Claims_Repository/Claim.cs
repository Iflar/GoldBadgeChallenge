using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    public enum TypeClaim
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public TypeClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmmount { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime DateOfIncident { get; set; }
        public bool IsValid
        {
            get
            {
                return SetValidByDate(DateOfIncident, DateOfClaim);
            }
        }

        public Claim() { }
        public Claim(int claimID, TypeClaim claimType, string description, double claimAmmount, DateTime dateOfClaim, DateTime dateOfIncedent)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmmount = claimAmmount;
            DateOfClaim = dateOfClaim;
            DateOfIncident = dateOfIncedent;
        }

        public bool SetValidByDate(DateTime dateOfincedent, DateTime dateOfClaim)
        {
            TimeSpan timeDifference = dateOfClaim - dateOfClaim;

            double differenceInDays = timeDifference.TotalDays;

            int daysBetween = Convert.ToInt32(Math.Floor(differenceInDays));

            if (daysBetween < 30)
            {
                return true;
            }

            return false;
        }
    }
}
