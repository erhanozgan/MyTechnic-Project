using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace myTechnicCase.Domain.Entity.Base;

// Tüm Entitler "id" lerini bu class'dan alacaklardır.
public abstract class BaseEntity<TKey>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //Primary key oluşturmak için eklenmiştir.
    [Key]
    public TKey Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<int>
{
    
}