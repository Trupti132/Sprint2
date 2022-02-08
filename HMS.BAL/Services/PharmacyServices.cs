using HMS.DAL.Repository;
using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.BAL.Services
{
    class PharmacyServices
    {
        IPharmacyRepository _pharmacyRepository;
        public PharmacyServices(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }
        public void AddMedicine(Pharmacy pharmacy)
        {
            _pharmacyRepository.AddMedicine(pharmacy);
        }
        public void DeleteMedicine(int MedicineId)
        {
            _pharmacyRepository.DeleteMedicine(MedicineId);
        }
        public void GetMedicineById(int MedicineId)
        {
            _pharmacyRepository.GetMedicineById(MedicineId);
        }
        public void UpdateMedicine(Pharmacy pharmacy)
        {
            _pharmacyRepository.UpdateMedicine(pharmacy);
        }
        public IEnumerable<Pharmacy> GetMedicines()
        {
            return _pharmacyRepository.GetMedicines();


        }
    }
}
