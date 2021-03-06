using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class StorageEntity
    {
        [Key]
        [StringLength(50)]
        public string StorageId { get; set; }
        public DateTime LastUpdate { get; set; }
        public int PartialQuantity { get; set; }
        public string ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public ICollection<InOutEntity> InOuts { get; set; }
        public string WarehouseId { get; set; }
        public WarehouseEntity Warehouse { get; set; }
    }
}
