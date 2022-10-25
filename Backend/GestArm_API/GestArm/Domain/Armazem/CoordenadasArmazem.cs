using System;
using GestArm.Domain.Shared;


namespace GestArm.Domain.Armazem
{

    public class CoordenadasArmazem : ValueObject
    {

        public int Graus { get; private set; }

        public int Minutos { get; private set; }

        public int Segundos { get; private set; }


        public CoordenadasArmazem(int graus, int minutos, int segundos)
        {

            checkGraus(graus);
            checkMinutos(minutos);
            checkSegundos(segundos);

            this.Graus = graus;
            this.Minutos = minutos;
            this.Segundos = segundos;
        }

        private void checkGraus(int graus)
        {

            if (graus < -180 && graus > 180)
            {
                throw new BusinessRuleValidationException("Graus da Coordenada deve estar entre os valores 180 e -180");
            }
        }

        private void checkMinutos(int minutos)
        {

            if (minutos < 0 && minutos > 60)
            {
                throw new BusinessRuleValidationException("Minutos da coordenadas deve estar entre os valores 0 e 60");
            }
        }

        private void checkSegundos(int segundos)
        {

            if (segundos < 0 && segundos > 60)
            {
                throw new BusinessRuleValidationException("Segundos da coordenada deve estar entre os valores 0 e 60");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Graus;
            yield return Minutos;
            yield return Segundos;
        }
    }

}