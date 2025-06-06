using System.Text.RegularExpressions;

public static class CpfValidator
{
    public static bool IsValidCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = Regex.Replace(cpf, "[^0-9]", "");

        if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
            return false;

        return ValidateDigits(cpf);
    }

    private static bool ValidateDigits(string cpf)
    {
        int[] weight1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] weight2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        int firstDigit = CalculateDigit(cpf, weight1);
        int secondDigit = CalculateDigit(cpf, weight2);

        return cpf[9] - '0' == firstDigit && cpf[10] - '0' == secondDigit;
    }

    private static int CalculateDigit(string cpf, int[] weight)
    {
        int sum = 0;
        for (int i = 0; i < weight.Length; i++)
            sum += (cpf[i] - '0') * weight[i];

        int remainder = sum % 11;
        return remainder < 2 ? 0 : 11 - remainder;
    }
}