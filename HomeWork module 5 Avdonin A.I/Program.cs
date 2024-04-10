{
    var userData = EnterUser();
    DisplayUserInfo(userData);
}

static (string Name, string Family, int Age, string[] Pets, int NumPets, int NumColors, string[] FavColors) EnterUser()
{
    (string Name, string Family, int Age, string[] Pets, int NumPets, int NumColors, string[] FavColors) User = (null, null, 0, null, 0, 0, null);

    Console.WriteLine(" Введите имя пользователя: ");
    User.Name = Console.ReadLine();

    Console.WriteLine(" Введите фамилию пользователя: ");
    User.Family = Console.ReadLine();

    string userAgeInput;
    int userAge;

    do
    {
        Console.WriteLine(" Введите возраст пользователя: ");
        userAgeInput = Console.ReadLine();
    }
    while (CheckNum(userAgeInput, out userAge));

    User.Age = userAge;

    Console.WriteLine(" У вас есть питомцы? (Да или Нет) ");
    var hasPets = Console.ReadLine();

    if (hasPets == "Да")
    {
        string numPetsInput;
        int numPets;

        do
        {
            Console.WriteLine(" Сколько у вас домашних питомцев? Введите количество в числовом формате: ");
            numPetsInput = Console.ReadLine();
        }
        while (CheckNum(numPetsInput, out numPets));

        User.NumPets = numPets;
        User.Pets = new string[User.NumPets];

        for (int i = 0; i < User.NumPets; i++)
        {
            Console.WriteLine($" Введите кличку вашего питомца {i + 1} из {User.NumPets}: ");
            User.Pets[i] = Console.ReadLine();
        }
    }

    string numColorsInput;
    int numColors;

    do
    {
        Console.WriteLine( "Сколько у вас любимых цветов? Введите количество в числовом формате: ");
        numColorsInput = Console.ReadLine();
    }
    while (CheckNum(numColorsInput, out numColors));

    User.NumColors = numColors;
    User.FavColors = new string[User.NumColors];

    for (int k = 0; k < User.NumColors; k++)
    {
        Console.WriteLine($" Введите любимый цвет {k + 1} из {User.NumColors}: ");
        User.FavColors[k] = Console.ReadLine();
    }

    return User;
}


static bool CheckNum(string number, out int corrNum)
{
    if (int.TryParse(number, out int intNum) && intNum > 0)
    {
        corrNum = intNum;
        return false;
    }
    else
    {
        corrNum = 0;
        return true;
    }
}

static void DisplayUserInfo((string Name, string Family, int Age, string[] Pets, int NumPets, int NumColors, string[] FavColors) user)
{
    Console.WriteLine(" Имя пользователя: " + user.Name);
    Console.WriteLine(" Фамилия пользователя: " + user.Family);
    Console.WriteLine(" Возраст пользователя: " + user.Age);

    if (user.NumPets > 0)
    {
        Console.WriteLine(" Питомцы: ");
        for (int i = 0; i < user.NumPets; i++)
        {
            Console.WriteLine($"Питомец {i + 1}: {user.Pets[i]}");
        }
    }
    else
    {
        Console.WriteLine(" У пользователя нет питомцев. ");
    }

    Console.WriteLine(" Любимые цвета: ");
    for (int i = 0; i < user.NumColors; i++)
    {
        Console.WriteLine($"Цвет {i + 1}: {user.FavColors[i]}");
    }
}

Console.WriteLine(" Нажмите клавишу 'Enter' для завершения программы ");
Console.ReadKey();