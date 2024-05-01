using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class InfoContext : DbContext
{
    

    public InfoContext(DbContextOptions<InfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__employee__1299A8611F6828EE");

            entity.ToTable("employees");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.Contact)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("contact");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payments__ED1FC9EA7570E28F");

            entity.ToTable("payments");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.CardExpiry).HasColumnName("card_expiry");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("card_number");
            entity.Property(e => e.CardOwner)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("card_owner");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__policies__47DA3F0349C4D2B6");

            entity.ToTable("policies");

            entity.Property(e => e.PolicyId).HasColumnName("policy_id");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.InsurenceCompany)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("insurence_company");
            entity.Property(e => e.PolicyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policy_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Emp).WithMany(p => p.Policies)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__policies__emp_id__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
