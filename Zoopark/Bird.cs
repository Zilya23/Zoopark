//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoopark
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bird
    {
        public int ID_Bird { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateOfBirdth { get; set; }
        public Nullable<int> ID_Gender { get; set; }
        public Nullable<int> ID_WinteringPlace { get; set; }
        public Nullable<int> ID_FeedingRation { get; set; }
        public Nullable<int> ID_Habitat { get; set; }
        public Nullable<int> ID_Caretaker { get; set; }
        public Nullable<int> ID_Veterinarian { get; set; }
        public string Foto { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Feeding_Ration Feeding_Ration { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Habitat Habitat { get; set; }
        public virtual Wintering_Place Wintering_Place { get; set; }
    }
}