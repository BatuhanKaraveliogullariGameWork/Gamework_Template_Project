using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet Vector2 değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewVector2Variable", menuName = "GameVariables/Vector2Variable")]
public class Vector2Variable : GameVariable
{
    public Vector2 Value;
    ///<Summary> Float ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(Vector2 amount) => Value = amount;

    ///<Summary> FloatVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(Vector2Variable amount) => Value = amount.Value;

    ///<Summary> Float ile scale yapılmaktadır.</Summary>
    public void Scale(float multiplier) => Value *= multiplier;

    ///<Summary> İnt ile scale yapılmaktadır.</Summary>
    public void Scale(int multiplier) => Value *= multiplier;

    ///<Summary> FloatVariable ile scale yapılmaktadır.</Summary>
    public void Scale(FloatVariable multiplier) => Value *= multiplier.Value;

    ///<Summary> FloatReference ile scale yapılmaktadır.</Summary>
    public void Scale(FloatReference multiplier) => Value *= multiplier.Value;

    ///<Summary> IntVariable ile scale yapılmaktadır.</Summary>
    public void Scale(IntVariable multiplier) => Value *= multiplier.Value;

    ///<Summary> IntReference ile scale yapılmaktadır.</Summary>
    public void Scale(IntReference multiplier) => Value *= multiplier.Value;
}
