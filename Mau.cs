using Spectre.Console;

public class Mau {
    public static List<Color> danhsachmau = new List<Color> {
        Color.Red,
        Color.Green,
        Color.Yellow,
        Color.Orange1,
        Color.Aquamarine1,
        Color.Cyan,
        Color.Default
    };

    public static void tomau(string noidung, Color mau, bool xuongdong = false){
        Console.ForegroundColor = mau;
        if(xuongdong) Console.WriteLine(noidung);
        else Console.Write(noidung);
        Console.ResetColor();
    }
}