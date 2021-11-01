using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet float değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewFloatVariable", menuName = "GameVariables/FloatVariable")]
public class FloatVariable : GameVariable
{
    public float Value;

    ///<Summary> Float ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(float amount) => Value = amount;

    ///<Summary> FloatVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(FloatVariable amount) => Value = amount.Value;

    ///<Summary> Float ile toplama yapılmaktadır.</Summary>
    public void Increase(float amount) => Value += amount;

    ///<Summary> FloatVariable ile toplama yapılmaktadır.</Summary>
    public void Increase(FloatVariable amount) => Value += amount.Value;

    ///<Summary> Float ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(float amount) => Value -= amount;

    ///<Summary> FloatVariable ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(FloatVariable amount) => Value -= amount.Value;

    ///<Summary> Float ile çarpma yapılmaktadır.</Summary>
    public void Multiply(float multiplier) => Value *= multiplier;

    ///<Summary> FloatVariable ile çarpma yapılmaktadır.</Summary>
    public void Multiply(FloatVariable multiplier) => Value *= multiplier.Value;

    ///<Summary> Float ile bölme yapılmaktadır.</Summary>
    public void Devide(float divider) => Value /= divider;

    ///<Summary> FloatVariable ile bölme yapılmaktadır.</Summary>
    public void Devide(FloatVariable divider) => Value /= divider.Value;
}