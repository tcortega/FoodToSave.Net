using System.Runtime.Serialization;

namespace FoodToSave.Net;

/// <summary>
/// <para>The segment of the merchant.</para>
/// <para>Represents the kind of goods that the merchant sells.</para>
/// </summary>
public enum MerchantSegment
{
    /// <summary>
    /// <para>Translates to <c>Cafeteria</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Cafeteria")]
    Cafeteria,

    /// <summary>
    /// <para>Translates to <c>Restaurante</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Restaurante")]
    Restaurante,

    /// <summary>
    /// <para>Translates to <c>Pizzaria</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Pizzaria")]
    Pizzaria,

    /// <summary>
    /// <para>Translates to <c>Hamburgueria</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Hamburgueria")]
    Hamburgueria,

    /// <summary>
    /// <para>Translates to <c>Culinária oriental</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Culinária oriental")]
    CulinariaOriental,

    /// <summary>
    /// <para>Translates to <c>Padaria</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Padaria")]
    Padaria,

    /// <summary>
    /// <para>Translates to <c>Sorveteria</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Sorveteria")]
    Sorveteria,

    /// <summary>
    /// <para>Translates to <c>Doceria</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Doceria")]
    Doceria,

    /// <summary>
    /// <para>Translates to <c>Hotel</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Hotel")]
    Hotel,

    /// <summary>
    /// <para>Translates to <c>Mercado</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Mercado")]
    Mercado,

    /// <summary>
    /// <para>Translates to <c>Outros</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Outros")]
    Outros,

    /// <summary>
    /// <para>Translates to <c>Conveniência</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Conveniência")]
    Conveniencia,

    /// <summary>
    /// <para>Translates to <c>Hortifruti</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Hortifruti")]
    Hortifruti,

    /// <summary>
    /// <para>Translates to <c>Bebidas</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Bebidas")]
    Bebidas,

    /// <summary>
    /// <para>Translates to <c>Açougue</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Açougue")]
    Acougue,

    /// <summary>
    /// <para>Translates to <c>Salgaderia</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Salgaderia")]
    Salgaderia,

    /// <summary>
    /// <para>Translates to <c>Comida árabe</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Comida árabe")]
    ComidaArabe,

    /// <summary>
    /// <para>Translates to <c>Comida mexicana</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Comida mexicana")]
    ComidaMexicana,

    /// <summary>
    /// <para>Translates to <c>Saudável</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Saudável")]
    Saudavel,

    /// <summary>
    /// <para>Translates to <c>Vegano</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Vegano")]
    Vegano,

    /// <summary>
    /// <para>Translates to <c>Empório</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Empório")]
    Emporio,

    /// <summary>
    /// <para>Translates to <c>Açaí</c> when serialized.</para>
    /// </summary>
    [EnumMember(Value = "Açaí")]
    Acai
}