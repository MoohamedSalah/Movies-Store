﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoviesMoo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MoviesDBconnectionstring : DbContext
    {
        public MoviesDBconnectionstring()
            : base("name=MoviesDBconnectionstring")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<MemberShipType> MemberShipType { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Rentals> Rentals { get; set; }
    
        public virtual int spSaveCustmoer(Nullable<int> id, string name, Nullable<bool> isSubscribedToNewsLetter, Nullable<int> membershipID, Nullable<System.DateTime> birthdate)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var isSubscribedToNewsLetterParameter = isSubscribedToNewsLetter.HasValue ?
                new ObjectParameter("IsSubscribedToNewsLetter", isSubscribedToNewsLetter) :
                new ObjectParameter("IsSubscribedToNewsLetter", typeof(bool));
    
            var membershipIDParameter = membershipID.HasValue ?
                new ObjectParameter("MembershipID", membershipID) :
                new ObjectParameter("MembershipID", typeof(int));
    
            var birthdateParameter = birthdate.HasValue ?
                new ObjectParameter("Birthdate", birthdate) :
                new ObjectParameter("Birthdate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSaveCustmoer", idParameter, nameParameter, isSubscribedToNewsLetterParameter, membershipIDParameter, birthdateParameter);
        }
    
        public virtual int spEditeMovies(Nullable<int> id, string name, string genre, Nullable<System.DateTime> releasDate, Nullable<System.DateTime> dateAdd, Nullable<double> numberInStock, Nullable<int> memberAvalible, byte[] moviesPhoto, string altPhoto, string docxContant)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genreParameter = genre != null ?
                new ObjectParameter("Genre", genre) :
                new ObjectParameter("Genre", typeof(string));
    
            var releasDateParameter = releasDate.HasValue ?
                new ObjectParameter("ReleasDate", releasDate) :
                new ObjectParameter("ReleasDate", typeof(System.DateTime));
    
            var dateAddParameter = dateAdd.HasValue ?
                new ObjectParameter("DateAdd", dateAdd) :
                new ObjectParameter("DateAdd", typeof(System.DateTime));
    
            var numberInStockParameter = numberInStock.HasValue ?
                new ObjectParameter("NumberInStock", numberInStock) :
                new ObjectParameter("NumberInStock", typeof(double));
    
            var memberAvalibleParameter = memberAvalible.HasValue ?
                new ObjectParameter("MemberAvalible", memberAvalible) :
                new ObjectParameter("MemberAvalible", typeof(int));
    
            var moviesPhotoParameter = moviesPhoto != null ?
                new ObjectParameter("MoviesPhoto", moviesPhoto) :
                new ObjectParameter("MoviesPhoto", typeof(byte[]));
    
            var altPhotoParameter = altPhoto != null ?
                new ObjectParameter("AltPhoto", altPhoto) :
                new ObjectParameter("AltPhoto", typeof(string));
    
            var docxContantParameter = docxContant != null ?
                new ObjectParameter("DocxContant", docxContant) :
                new ObjectParameter("DocxContant", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spEditeMovies", idParameter, nameParameter, genreParameter, releasDateParameter, dateAddParameter, numberInStockParameter, memberAvalibleParameter, moviesPhotoParameter, altPhotoParameter, docxContantParameter);
        }
    
        public virtual int spCreateMovie(Nullable<int> id, string name, string genre, Nullable<System.DateTime> releasDate, Nullable<System.DateTime> dateAdd, Nullable<double> numberInStock, Nullable<int> memberAvalible, byte[] moviesPhoto, string altPhoto, string docxContant)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var genreParameter = genre != null ?
                new ObjectParameter("Genre", genre) :
                new ObjectParameter("Genre", typeof(string));
    
            var releasDateParameter = releasDate.HasValue ?
                new ObjectParameter("ReleasDate", releasDate) :
                new ObjectParameter("ReleasDate", typeof(System.DateTime));
    
            var dateAddParameter = dateAdd.HasValue ?
                new ObjectParameter("DateAdd", dateAdd) :
                new ObjectParameter("DateAdd", typeof(System.DateTime));
    
            var numberInStockParameter = numberInStock.HasValue ?
                new ObjectParameter("NumberInStock", numberInStock) :
                new ObjectParameter("NumberInStock", typeof(double));
    
            var memberAvalibleParameter = memberAvalible.HasValue ?
                new ObjectParameter("MemberAvalible", memberAvalible) :
                new ObjectParameter("MemberAvalible", typeof(int));
    
            var moviesPhotoParameter = moviesPhoto != null ?
                new ObjectParameter("MoviesPhoto", moviesPhoto) :
                new ObjectParameter("MoviesPhoto", typeof(byte[]));
    
            var altPhotoParameter = altPhoto != null ?
                new ObjectParameter("AltPhoto", altPhoto) :
                new ObjectParameter("AltPhoto", typeof(string));
    
            var docxContantParameter = docxContant != null ?
                new ObjectParameter("DocxContant", docxContant) :
                new ObjectParameter("DocxContant", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCreateMovie", idParameter, nameParameter, genreParameter, releasDateParameter, dateAddParameter, numberInStockParameter, memberAvalibleParameter, moviesPhotoParameter, altPhotoParameter, docxContantParameter);
        }
    }
}
