using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet bool değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewBoolVariable", menuName = "GameVariables/BoolVariable")]
public class BoolVariable : GameVariable
{
    public bool Value;

    ///<Summary> Bool ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(bool amount) => Value = amount;

    ///<Summary> BoolVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(BoolVariable amount) => Value = amount.Value;
}
