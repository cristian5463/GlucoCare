using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlucoCare.Domain.Entities
{
    public class ConfigEntity
    {
        [Key] 
        private bool _applyInsulinSnack;
        private bool _useCarbsCalc;
        public int idUser { get; set; }

        public ConfigEntity(int idUser, bool applyInsulinSnack, bool useCarbsCalc)
        {
            IdUser = idUser;
            _applyInsulinSnack = applyInsulinSnack;
            _useCarbsCalc = useCarbsCalc;
        }

        public bool ApplyInsulinSnack
        {
            get { return _applyInsulinSnack; }
            set { _applyInsulinSnack = value; }
        }

        public bool UseCarbsCalc
        {
            get { return _useCarbsCalc; }
            set { _useCarbsCalc = value; }
        }
        public int IdUser
        {
            get { return idUser; }
            private set { idUser = value; }
        }
    }
}
