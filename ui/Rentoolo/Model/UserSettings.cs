//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rentoolo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserSettings
    {
        public int Id { get; set; }
        public System.Guid UserId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public System.DateTime Created { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
