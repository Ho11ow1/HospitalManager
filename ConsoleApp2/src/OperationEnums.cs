public enum Disorder
{
    NULL = 0,
    Anxiety,
    Schizophrenia,
    Depression,
    Bipolar,
    PanicAttack
}

public enum Treatment
{
    NULL = 0,
    Medication,
    Surgery,
    Checkup
}

public enum Status
{
    NULL = 0,
    Pending,
    InProgress,
    Completed
}

public enum Cost
{
    NULL = 0,
    AnxietyTreatment = 150,
    SchizophreniaTreatment = 300,
    DepressionTreatment = 100,
    BipolarDisorderTreatment = 250,
    PanicAttackTreatment = 200
}