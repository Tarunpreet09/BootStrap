namespace Supplier.Models
{
    public class Suppliers
    {
        public Guid? Gid { get; set; }
        public string? Supplier_Name { get; set; }
        public int? Mobile_No { get; set; }
        public int? ZipCode { get; set;}       
        public string? State { get; set;}
        public string? City { get; set;}
        public string? Email { get; set;}
        public List<ItemInSupplier>? name { get; set; }
    }
}
