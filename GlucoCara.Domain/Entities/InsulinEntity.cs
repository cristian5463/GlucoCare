using System;

namespace GlucoCare.source.Domain.Entities
{
    public class InsulinEntity
    {
        public int Id { get; set; }
        private string nameInsulin;
        private bool individualApplication;
        private int[] typesInsulin;
        private int idUser;

        public InsulinEntity(string nameInsulin, bool individualApplication, int[] typesInsulin, int idUser)
        {
            NameInsulin = nameInsulin;
            IndividualApplication = individualApplication;
            TypesInsulin = typesInsulin;
            IdUser = idUser;
        }

        public string NameInsulin
        {
            get { return nameInsulin; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("O nome da insulina não pode ser nulo ou vazio.");
                }

                nameInsulin = value;
            }
        }

        public bool IndividualApplication
        {
            get { return individualApplication; }
            private set { individualApplication = value; }
        }

        public int[] TypesInsulin
        {
            get { return typesInsulin; }
            private set
            {
                /*if (value == null || value.Length == 0)
                {
                    throw new ArgumentException("É necessário especificar pelo menos um tipo de insulina.");
                }*/

                typesInsulin = value;
            }
        }

        public int IdUser
        {
            get { return idUser; }
            private set { idUser = value; }
        }
    }
}
