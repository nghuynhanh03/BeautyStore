﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautyStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }

    public class BrandFlyweight
    {
        //Khai báo Properties
        private readonly int brandId;
        private readonly string image;
        //Constructor
        public BrandFlyweight(int brandId, string image)
        {
            this.brandId = brandId;
            this.image = image;
        }
        //Phương thức hiển thị hình ảnh thương hiệu
        public void Display()
        {
            Console.WriteLine(image);
        }
    }

    public class BrandFlyweightFactory
    {
        //Dictionnary sử dụng để lưu trữ các đối tượng đã được tạo ra
        private Dictionary<int, BrandFlyweight> brandFlyweights = new Dictionary<int, BrandFlyweight>();

        public BrandFlyweight GetBrandFlyweight(int brandId, string image)
        {
            if (!brandFlyweights.ContainsKey(brandId))
            {
                brandFlyweights[brandId] = new BrandFlyweight(brandId, image);
            }

            return brandFlyweights[brandId];
        }
    }

}
