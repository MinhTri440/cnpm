

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MyPhamWeb.Context
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class MyPhamEntities : DbContext
{
    public MyPhamEntities()
        : base("name=MyPhamEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderImport> OrderImports { get; set; }

    public virtual DbSet<OrderImportDetail> OrderImportDetails { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

}

}

