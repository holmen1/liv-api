using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LivApi.Models
{
    public class Insurance
    {
        [Key]
        public int Id { get; set; }
        public int InsuranceId { get; set; }
        public int PersonalId { get; set; }
        public string Sex { get; set; }
        public double z { get; set; }
        public double GuaranteeAmount { get; set; }
        public double PaymentTime { get; set; }
        public double GuaranteeTime { get; set; }
        public string Product { get; set; }
        public string Table { get; set; }
    }
}
