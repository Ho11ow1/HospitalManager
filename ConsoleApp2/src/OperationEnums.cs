public enum OperationName
{
    NULL = 0,
    AnxietyTreatment,
    SchizophreniaTreatment,
    DepressionTreatment,
    BipolarDisorderTreatment,
    PanicAttackTreatment
}

public enum OperationType
{
    NULL = 0,
    Medicine,
    Surgery,
    Checkup
}

public enum Drugs
{
    NULL = 0,
    Xanax,
    Benadryl,
    Betaloc
}

public enum OperationStatus
{
    NULL = 0,
    Pending,
    InProgress,
    Completed
}

public enum OperationCost
{
    NULL = 0,
    AnxietyTreatment = 150,
    SchizophreniaTreatment = 300,
    DepressionTreatment = 100,
    BipolarDisorderTreatment = 250,
    PanicAttackTreatment = 200
}