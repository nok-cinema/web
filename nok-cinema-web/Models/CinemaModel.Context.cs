﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nok_cinema_web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CinemaEntities : DbContext
    {
        public CinemaEntities()
            : base("name=CinemaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<FOOD> FOOD { get; set; }
        public virtual DbSet<MEMBER> MEMBER { get; set; }
        public virtual DbSet<MOVIE> MOVIE { get; set; }
        public virtual DbSet<PERSON> PERSON { get; set; }
        public virtual DbSet<REVIEW> REVIEW { get; set; }
        public virtual DbSet<SEAT> SEAT { get; set; }
        public virtual DbSet<SELL> SELL { get; set; }
        public virtual DbSet<SHOWTIME> SHOWTIME { get; set; }
        public virtual DbSet<THEATRE> THEATRE { get; set; }
        public virtual DbSet<TICKET> TICKET { get; set; }
    }
}
