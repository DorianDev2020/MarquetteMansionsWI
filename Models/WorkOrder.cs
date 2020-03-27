using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Marquette_Mansions.Models
{
    public class WorkOrder
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int TenantId { get; set; }
        [Display(Name = "Work Order Request")]
        public string MaintenanceOrder { get; set; }
    }
    public class WorkOrderDBContext : DbContext
    {
        public DbSet<WorkOrder> WorkOrders{ get; set; }
    }
}
