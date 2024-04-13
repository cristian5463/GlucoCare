using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Domain.Entities;
public class InsulinDoseEntity
{
    [Key] // Marcar como chave primária
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    private int idTypeInsulin;
    private decimal amount;
    private decimal correction;
    private DateTime createdAt;
    private DateTime updatedAt;

    public InsulinDoseEntity(int idTypeInsulin, decimal amount, decimal correction, DateTime createdAt) 
    {
        IdTypeInsulin = idTypeInsulin;
        Amount = amount;
        Correction = correction;
        CreatedAt = createdAt;
    }
    public int IdTypeInsulin
    {
        get { return idTypeInsulin; }
        private set
        {
            if (value == 0)
            {
                throw new ArgumentException("É necessário informar o tipo de insulina.");
            }

            idTypeInsulin = value;
        }
    }
    public decimal Amount
    {
        get { return amount; }
        private set
        {
            if (value == 0)
            {
                throw new ArgumentException("É necessário informar a quantidade.");
            }

            amount = value;
        }
    }

    public decimal Correction
    {
        get { return correction; }
        private set { correction = value; }
    }

    public DateTime CreatedAt
    {
        get { return createdAt; }
        private set { createdAt = value; }
    }

    public DateTime UpdatedAt
    {
        get { return updatedAt; }
        private set { updatedAt = DateTime.UtcNow; }
    }
}
