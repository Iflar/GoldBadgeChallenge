using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repository
{
    class ClaimMethodRepo
    {
        List<Claim> _claimDirectory = new List<Claim>();
        public bool AddClaimToDir(Claim claim)
        {
            if (claim != null)
            {
                _claimDirectory.Add(claim);
                return true;
            }
            return false;
        }
        public bool RemoveClaimFromDir(Claim claim)
        {
            if(claim != null)
            {
                _claimDirectory.Remove(claim);
                return true;
            }
            return false;
        }
        public Claim UpdateClaim(int claimID, Claim updatedClaim)
        {
            Claim oldClaim = GetClaimByID(claimID);
            if(oldClaim != null)
            {
                oldClaim.ClaimType = updatedClaim.ClaimType;
                oldClaim.Description = updatedClaim.Description;
                oldClaim.DateOfIncident = updatedClaim.DateOfIncident;
                oldClaim.DateOfClaim = updatedClaim.DateOfClaim;
                oldClaim.ClaimAmmount = updatedClaim.ClaimAmmount;
                return oldClaim;
            }
            return null;
        }
        public Claim GetClaimByID(int claimID)
        {
            foreach(Claim claim in _claimDirectory)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
        public List<Claim> GetClaims()
        {
            return _claimDirectory;
        }
    }
}
