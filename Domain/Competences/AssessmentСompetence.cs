namespace Domain.Competences
{
    public class AssessmentСompetence
    {
        private Competence _competence;
        protected int _level;

        public string Name => _competence.Name;
        public CompetenceLevelScale Scale => _competence.Scale;
        virtual public int Level { get => _level; protected set => _level = value; }

        public AssessmentСompetence(Competence competence, int level)
        {
            _competence = competence;
            Level = level;
        }

        public bool CompetenciesCoincide(AssessmentСompetence assessmentСompetence)
        {
            return Scale.Equals(assessmentСompetence.Scale) && Name == assessmentСompetence.Name;
        }
        public bool CompetenciesCoincide(Competence competence)
        {
            return Scale.Equals(competence.Scale) && Name == competence.Name;
        }
    }
}
