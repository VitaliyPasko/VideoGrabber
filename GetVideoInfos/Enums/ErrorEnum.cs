using System.ComponentModel;

namespace GetVideoInfos.Enums
{
    public enum ErrorEnum
    {
        [Description("Несуществующая операция.")]
        WrongOperation = 1,
        [Description("Некорректный Id или нет доступа к интернету.")]
        WrongId
    }
}