﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cardealership.data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarDealershipEntities : DbContext
    {
        private static CarDealershipEntities _context;
        public CarDealershipEntities()
            : base("name=CarDealershipEntities")
        {
        }

        public static CarDealershipEntities GetContext()
        {
            if (_context == null)
            {
                _context = new CarDealershipEntities();
            }
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Автомобили> Автомобили { get; set; }
        public virtual DbSet<Категории_автомобилей> Категории_автомобилей { get; set; }
        public virtual DbSet<Марки_автомобилей> Марки_автомобилей { get; set; }
        public virtual DbSet<Покупатели> Покупатели { get; set; }
        public virtual DbSet<Продажи_автомобилей> Продажи_автомобилей { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
    }
}
