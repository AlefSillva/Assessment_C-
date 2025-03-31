namespace Ex02 
{
    class Program02
    {
        public static void Main(string[] args)
        {
            string meuNome = "Alef Silva";

            string nomeCifrado = cifradorDeNome(meuNome);
            Console.WriteLine(nomeCifrado);


        }

        static string cifradorDeNome(string nome)
        {
            char[] nomeArray = nome.ToCharArray();

            for (int i = 0; i < nomeArray.Length; i++)
            {
                if (char.IsLetter(nomeArray[i]))
                {
                    char letraMinuscula = char.IsUpper(nomeArray[i]) ? 'A' : 'a';
                    nomeArray[i] = (char)(letraMinuscula + (nomeArray[i] - letraMinuscula + 2) % 26);
                }
            }

            return new string(nomeArray);
        }
    }
}