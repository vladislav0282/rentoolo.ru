//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rentoolo.Model
{
    using System;
    
    public partial class spGetFavorites_Result
    {
        public long Id { get; set; }
        public long AdvertId { get; set; }
        public System.DateTime CreatedFavorites { get; set; }
        public Nullable<int> Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedAdverts { get; set; }
        public Nullable<System.Guid> CreatedUserId { get; set; }
        public Nullable<double> Price { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Nullable<int> MessageType { get; set; }
    }
}