using UnityEngine;

///<Summary> Bu class oyun içerisinde haberleşmeye sağlamaktadır.
///Burada bir adet int değişkeni bu classa yazılır ve onu realtime okuyan bitün classlar bu değeri set etmektedir.
///Bu haberleşmeyi variablelar ile yapmaktadır.</Summary>
///<see cref="GameVariable"/>
[CreateAssetMenu(fileName = "NewIntVariable", menuName = "GameVariables/IntVariable")]
public class IntVariable : GameVariable
{
    public int Value;

    ///<Summary> Int ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(int amount) => Value = amount;

    ///<Summary> IntVariable ile değer ataması yapılmaktadır.</Summary>
    public void SetValue(IntVariable amount) => Value = amount.Value;

    ///<Summary> Int ile toplama yapılmaktadır.</Summary>
    public void Increase(int amount) => Value += amount;

    ///<Summary> IntVariable ile toplama yapılmaktadır.</Summary>
    public void Increase(IntVariable amount) => Value += amount.Value;

    ///<Summary> Int ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(int amount) => Value -= amount;

    ///<Summary> IntVariable ile çıkarma yapılmaktadır.</Summary>
    public void Decrease(IntVariable amount) => Value -= amount.Value;

    ///<Summary> Int ile çarpma yapılmaktadır.</Summary>
    public void Multiply(int multiplier) => Value *= multiplier;

    ///<Summary> IntVariable ile çarpma yapılmaktadır.</Summary>
    public void Multiply(IntVariable multiplier) => Value *= multiplier.Value;

    ///<Summary> Int ile bölme yapılmaktadır.
    /// Eğer bölümün sonucu ondalıklı ise en yakın olan tam sayıya tamamlanır.</Summary>
    public void Devide(int divider) => Value = Mathf.RoundToInt(Value / divider);

    ///<Summary> IntVariable ile bölme yapılmaktadır.
    /// Eğer bölümün sonucu ondalıklı ise en yakın olan tam sayıya tamamlanır.</Summary>
    public void Devide(IntVariable divider) => Value = Mathf.RoundToInt(Value / divider.Value);
}