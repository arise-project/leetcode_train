float ToString lost precision problem RRS feed

float f1 = 3653737.25F;
Console.Out.WriteLine(f1.ToString("F10")); // display : 3653737.0000000000
Console.Out.WriteLine(f1.ToString("E10")); // display : 3.6537372500E+006
Console.Out.WriteLine(f1.ToString("G9")); // display : 3653737.25

